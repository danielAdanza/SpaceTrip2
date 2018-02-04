using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour {

	public GameObject settingsSection;
	public GameObject languajesSection;
	public GameObject creditsSection;
	public GameObject playerDataSection;
    public GameObject moreAppsSection;
    public GameObject AchievementsSection;
    public GameObject background;
    public GameObject FBPopUp;

    public Slider normalSlider;
    public Slider heroSlider;
    public Slider victoriesSlider;
    public Slider achievementsSlider;
    public Slider vehiclesSlider;

    public void Start ()
    {
        if (Random.Range(0f,10.0f) <= 2.0f )
        {
            if (PlayerData.playerData.languaje != 0)
            {
                goToFBPopUp();
            }
        }
    }

	public void changeScene ()
	{
        SceneManager.LoadScene(2);
	}

	public void changeSceneEditVehicle ()
	{
        SceneManager.LoadScene(4);
    }

	//mode 0 menu principal
	//mode 1 friends score
	//mode 2 settings
	//mode 3 languajes
	//mode 4 credits
	//mode 5 player Data

	public void goToSettings ()
	{
		PlayerPrefs.SetInt ("mode",2);
		background.SetActive (true);
		settingsSection.SetActive (true);
	}

	public void goToLanguajes ()
	{
		PlayerPrefs.SetInt ("mode",3);
		languajesSection.SetActive (true);
		settingsSection.SetActive (false);
	}

	public void goToCredits ()
	{
		PlayerPrefs.SetInt ("mode",4);
		creditsSection.SetActive (true);
		settingsSection.SetActive (false);
	}

	public void goToPlayerData ()
	{
		PlayerPrefs.SetInt ("mode",5);
		playerDataSection.SetActive (true);
		settingsSection.SetActive (false);

        normalSlider.value = PlayerData.playerData.currentlevel;
        heroSlider.value = PlayerData.playerData.currentlevel;

        if (PlayerData.playerData.totalvictories == 0)
        {
            victoriesSlider.value = PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches;
        }

        int value = 2;
        if (PlayerData.playerData.purchaseVehicle2 == 1)
        {   value++;  }

        if (PlayerData.playerData.purchaseVehicle3 == 1)
        { value++; }

        if (PlayerData.playerData.purchaseVehicle4 == 1)
        { value++; }

        if (PlayerData.playerData.purchaseVehicle5 == 1)
        { value++; }

        vehiclesSlider.value = value;
        value = 0;

        for (int i= 0;i < PlayerData.playerData.achievementsState.Length - 1;i++)
        {
            if (PlayerData.playerData.achievementsState[i] != 0)
            {   value++;  }
        }

        achievementsSlider.value = value;

    }

    public void goToMoreApps()
    {
        PlayerPrefs.SetInt("mode", 6);
        background.SetActive(true);
        moreAppsSection.SetActive(true);
    }

    public void goToAchievements()
    {
        PlayerPrefs.SetInt("mode", 7);
        background.SetActive(true);
        AchievementsSection.SetActive(true);
    }

    public void goToFBPopUp()
    {
        PlayerPrefs.SetInt("mode", 8);
        background.SetActive(true);
        FBPopUp.SetActive(true);
    }

    public void goOut ()
	{
		Application.Quit ();
	}

    //it opens an specified url passed by parameter
    //it is used in the more apps section
    public void openUrl (string url)
    {
        Application.OpenURL(url);
    }

    public void shareGame()
    {
        //creating the strings that will be shared
        string subject = "";
        string body = "";

        if (PlayerData.playerData.languaje == 1)
        {
            subject = "I am playing Space Trip!";
            body = "Hey there I am playing Space Trip. Wanna join? https://goo.gl/UiS62s";
        }
        else if (PlayerData.playerData.languaje == 2)
        {
            subject = "Estoy jugando a Space Trip!";
            body = "Qué tal? Estoy jugando a Space Trip. Quieres unirte? https://goo.gl/UiS62s";
        }
        else if (PlayerData.playerData.languaje == 3)
        {
            subject = "Igral sem vesoljsko pot!";
            body = "Hej tam sem igral Space Trip. Se želite pridružiti? https://goo.gl/UiS62s";
        }
        else if (PlayerData.playerData.languaje == 4)
        {
            subject = "Je joue à Space Trip!";
            body = "Salut, je joue à Space Trip. Veux rejoindre? https://goo.gl/UiS62s";
        }
        else if (PlayerData.playerData.languaje == 5)
        {
            subject = "Eu estou jogando Space Trip!";
            body = "Ei, estou jogando no Space Trip. Quer se juntar? https://goo.gl/UiS62s";
        }

        //execute the below lines if being run on a Android device
#if UNITY_ANDROID
        //Refernece of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        //Refernece of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        currentActivity.Call("startActivity", intentObject);
#endif
    }
}
