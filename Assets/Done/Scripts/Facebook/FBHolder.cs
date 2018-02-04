using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using System.Linq;
using System;

public class FBHolder : MonoBehaviour 
{
	public GameObject loggedIn;			//the object that contains all the elements that will show when the user loggs in
	public GameObject notLoggedIn;		//the object that contains all the elements that will show when the user is not logged in
	//public GameObject userImage;		//the object that shows the image of the user
	//public GameObject userName;			// the object that shows the name of the user

	private List<object> scoresList = null;
	private Dictionary <string, string> profile = null;
	public GameObject scoreEntryPanel;
	public GameObject scoreScrollList;
	public GameObject scoreScrollView;
	public RawImage background;
	public GameObject settings;
	public GameObject languajes;
	public GameObject credits;
	public GameObject playerData;
    public GameObject moreApps;
    public GameObject achievements;
    public GameObject FBPopUp;

    void Awake ()
	{
        //In the beginning it will check if you are already logged in or not
        if (FB.IsLoggedIn)
        {
            //if you are already log in, then it shows the correct buttons
            DealWithFBMenus(true);
        }
        else
        {
            //else it starts the inizialization parameters
            FB.Init(SetInit, OnHideUnity);
        }
        
	}

	private void SetInit ()
	{

	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) 
		{
			Time.timeScale = 0;
		} else 
		{
			Time.timeScale = 1;
		}
	}

	public void FBLoggin ()
	{
		FB.Login ("email,publish_actions", AuthCallback);
	}

	void AuthCallback (FBResult result)
	{
		if (FB.IsLoggedIn) {
			DealWithFBMenus(true);
		} else {
			DealWithFBMenus(false);
		}
	}

	void DealWithFBMenus (bool isloggedIn)
	{
		if (isloggedIn) 
		{
			loggedIn.SetActive (true);
			notLoggedIn.SetActive (false);

			//get profile profile picture and user name
			FB.API(Util.GetPictureURL("me",128,128), Facebook.HttpMethod.GET, DealWithProfilePicture );

			FB.API( "/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName );


		} else 
		{
			loggedIn.SetActive (false);
			notLoggedIn.SetActive (true);
		}
	}

	void DealWithProfilePicture (FBResult result)
	{
		if (result.Error != null) 
		{
			Debug.Log("we found problems getting the profile picture");

			FB.API(Util.GetPictureURL("me",128,128), Facebook.HttpMethod.GET, DealWithProfilePicture );
		}

		//Image userAvatar = userImage.GetComponent<Image> ();
		//userAvatar.sprite = Sprite.Create (result.Texture, new Rect(0,0,128,128), new Vector2(0,0) );
	}

	void DealWithUserName (FBResult result)
	{
		if (result.Error != null) 
		{
			Debug.Log("we found problems getting the profile picture");
			
			FB.API( "/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName );
		}

		profile = Util.DeserializeJSONProfile (result.Text);

		//Text message = userName.GetComponent<Text> ();
		//message.text = "Hello, " +  profile["first_name"];
	}

	public void ShareWithFriends ()
	{
		string message = "";
		string message2 = "";
		
		switch (PlayerData.playerData.languaje) 
		{
		case 1: //english
			message = "I am Playing SPACE TRIP 2!! come and join";
			message2 = "Invite your friends to join you";
			break;
		case 2: //spanish
			message = "estoy jugando a SPACE TRIP 2!!, quieres unirte?";
			message2 = "invita a tus amigos a jugar";
			break;
		case 3:  //slovene
			message = "Igram SPACE TRIP 2!! pridite in se pridružite!";
			message2 = "Povabite svoje prijatelje, da se vam pridružijo";
			break;
        case 4:  //french
            message = "Je joue SPACE TRIP 2!! venez rejoindre";
            message2 = "invitee vos amis à vous rejoindre";
            break;    
        case 5:  //portuguese
            message = "estou jogando SPACE TRIP 2!!. Venha e participe";
            message2 = "convide seus amigos para acompanhá-lo";
            break;
        }

		FB.Feed (
			//the message that will appear in the facebook post
			linkCaption: message2,
			//the link of the picture that has to be in the server
			picture: "https://ksr-ugc.imgix.net/assets/012/722/855/d66f626e8bd456e0ae78effc4302b8b1_original.png?w=1024&h=576&fit=fill&bg=000000&v=1465768833&auto=format&q=92&s=f3ffa21ce542f198b03ad1c42de4810a",
			//the text that they will see
			linkName: message,
            //that should be the link to google play
            //link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")
            link: "https://play.google.com/store/apps/details?id=adanzaapps.space.trip2"
        );
	}

    public void InviteFriends ()
	{
		string message = "";
        string message2 = "";

        switch (PlayerData.playerData.languaje)
        {
            case 1: //english
                message = "I am Playing SPACE TRIP 2!! come and join";
                message2 = "Invite your friends to join you";
                break;
            case 2: //spanish
                message = "!!estoy jugando al SPACE TRIP 2!!, quieres unirte?";
                message2 = "invita a tus amigos a jugar";
                break;
            case 3:  //slovene
                message = "Igram SPACE TRIP 2!! pridite in se pridružite!";
                message2 = "Povabite svoje prijatelje, da se vam pridružijo";
                break;
            case 4:  //french
                message = "Je joue SPACE TRIP 2!! venez rejoindre";
                message2 = "invitee vos amis à vous rejoindre";
                break;
            case 5:  //portuguese
                message = "¡¡estou jogando SPACE TRIP 2!!. Venha e participe";
                message2 = "convide seus amigos para acompanhá-lo";
                break;
        }

        FB.AppRequest(
            message: message,
            title: message2
       );
	}

    public void QueryScores ()
	{
		scoreScrollView.SetActive (true);
		FB.API ("/app/scores?fields=score,user.limit(30)", Facebook.HttpMethod.GET, ScoresCallBack);
	}

	private void ScoresCallBack (FBResult result)
	{
		background.gameObject.SetActive (true);

		scoresList = Util.DeserializeScores (result.Text);

		foreach (Transform child in scoreScrollList.transform) 
		{
			GameObject.Destroy (child.gameObject);
		}
		foreach (object score in scoresList)
		{
			var entry = (Dictionary<string,object>) score;
			var user = (Dictionary<string,object>) entry["user"];

			GameObject scorePanel;
			scorePanel = Instantiate (scoreEntryPanel) as GameObject;
			scorePanel.transform.parent = scoreScrollList.transform;

			Transform ThisScoreName = scorePanel.transform.Find ("FriendName");
			Transform ThisScoreScore = scorePanel.transform.Find("FriendScore");
			Text ScoreName = ThisScoreName.GetComponent<Text>();
			Text ScoreScore = ThisScoreScore.GetComponent<Text>();

			ScoreName.text = user["name"].ToString();
			ScoreScore.text = entry["score"].ToString();

			Transform TheUserAvatar = scorePanel.transform.Find("FriendAvatar");
			Image userAvatar = TheUserAvatar.GetComponent<Image>();

			FB.API(Util.GetPictureURL(user["id"].ToString(),128,128), Facebook.HttpMethod.GET,delegate(FBResult PictureResult) {
			if (PictureResult.Error != null)
			{
				Debug.Log(PictureResult.Error);
			}
			else
			{
				userAvatar.sprite = Sprite.Create (PictureResult.Texture, new Rect(0,0,128,128),new Vector2(0,0));
			}
		} );
		}
	}

	public void SetScores ()
	{
		var scoreData = new Dictionary <string,string> ();
		scoreData ["score"] = PlayerData.playerData.totalscore.ToString();

        PlayerPrefs.SetInt ("mode",1);

		FB.API ("/me/scores", Facebook.HttpMethod.POST, delegate(FBResult result) {
			Debug.Log("score submit result: "+ result.Text);
	}, scoreData);
	}

	public void DisapearScore ()
	{
		background.gameObject.SetActive (false);
		scoreScrollView.SetActive (false);

			foreach (Transform child in scoreScrollList.transform) 
			{	GameObject.Destroy (child.gameObject);}

		if ( PlayerPrefs.GetInt ("mode") == 2 ) 
		{
			settings.gameObject.SetActive(false);
		}
		else if ( PlayerPrefs.GetInt ("mode") == 3 ) 
		{
			languajes.gameObject.SetActive(false);
		}
		else if ( PlayerPrefs.GetInt ("mode") == 4 ) 
		{
			credits.gameObject.SetActive(false);
		}
		else if ( PlayerPrefs.GetInt ("mode") == 5 ) 
		{
			playerData.gameObject.SetActive(false);
		}
        else if (PlayerPrefs.GetInt("mode") == 6)
        {
            moreApps.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("mode") == 7)
        {
            achievements.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("mode") == 8)
        {
            FBPopUp.gameObject.SetActive(false);
        }
    }

    public void InviteFriendsPopup ()
    {
        //primero de todo ver si estás logeado
        if (FB.IsLoggedIn == true)
        {
            //si lo estás entonces invita a tus amigos directamente
            InviteFriends();
        }
        else
        {
            //si no primero logeate y luego si ya estás logeado entonces invitar a los amigos
            FBLoggin();

            if (FB.IsLoggedIn == true)
            {
                InviteFriends();
            }
        }
    }
}
