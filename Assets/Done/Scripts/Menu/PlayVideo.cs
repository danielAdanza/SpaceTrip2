using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(PlayMovie());
		string videoString = "";
		if (PlayerPrefs.GetInt ("level") == 1) {
			videoString = "v1.mp4";
		} else if ((PlayerPrefs.GetInt ("level") == 5) || (PlayerPrefs.GetInt ("level") == 10) || (PlayerPrefs.GetInt ("level") == 16) || (PlayerPrefs.GetInt ("level") == 21)) {
			videoString = "v3.mp4";
		} else if (PlayerPrefs.GetInt ("level") == 12) {
			videoString = "v2.mp4";
		}

		Debug.Log ("- - - - "); //con full se ve en pantalla completa pero con lo del play y rewind
		Handheld.PlayFullScreenMovie(videoString, Color.blue, FullScreenMovieControlMode.Hidden);
		Debug.Log ("VIDEO PLAYED");
        SceneManager.LoadScene(3);

    }

	void Update ()
	{

	}

	/*protected IEnumerator PlayMovie()
	{
		
		Handheld.PlayFullScreenMovie("v1.mp4", Color.blue, FullScreenMovieControlMode.Full);
		Debug.Log ("- - - - ");
		yield return new WaitForSeconds(1.0f);
		
		Debug.Log ("VIDEO PLAYED");
	}*/
}
