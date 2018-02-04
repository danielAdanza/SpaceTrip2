using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class simpleAds : MonoBehaviour {

	[SerializeField] string gameID;
    public GameObject coinsPopUp;
    public GameObject coinsButton;

	void Awake () 
	{
		//true if we are in test mode
		Advertisement.Initialize (gameID, false);
	}

	public void ShowAd(string zone)
	{
		#if UNITY_EDITOR
		StartCoroutine(WaitForAd ());
		#endif
		
		if (string.Equals (zone, ""))
			zone = null;
		
		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;
		
		if (Advertisement.IsReady(zone))
			Advertisement.Show (zone, options);
	}

	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			PlayerPrefs.SetInt ("revivir",1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			Debug.Log("I swear this has never happened to me before");
			break;
		}
	}

    public void ShowAd2(string zone)
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler2;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone, options);
    }

    void AdCallbackhandler2(ShowResult result)
    {
        coinsButton.SetActive(false);

        switch (result)
        {
            case ShowResult.Finished:
                PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins + 20;
                PlayerData.playerData.Save();

                coinsPopUp.SetActive(true);
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }

    IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;
		
		while (Advertisement.isShowing)
			yield return null;
		
		Time.timeScale = currentTimeScale;
	}
}
