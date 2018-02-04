using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour {

	public GameObject loadingImage;
	public Slider loadingBar;
	private AsyncOperation async;

	// Use this for initialization
	void Start () 
	{
        //advertisements 1 allowed , 0 it means not allowed;
        PlayerPrefs.SetInt("musicVolume", 8);
        PlayerPrefs.SetInt("soundsVolume", 6);
        LoadScene (1);
	}

	public void LoadScene (int level)
	{
		loadingImage.SetActive (true);
		PlayerPrefs.SetInt ("level",level);
		StartCoroutine(LoadLevelWithBar(1));
	}
	
	IEnumerator LoadLevelWithBar (int level)
	{
        async = SceneManager.LoadSceneAsync(level);
		//async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}
}
