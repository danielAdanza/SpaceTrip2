using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour {

	public AudioClip musicMenus;
	public AudioClip musicLevel;
	public AudioClip musicBattle1;
	public AudioClip musicBattle2;
	private AudioSource source;

    public Slider sliderMusic;
    public Slider sliderSound;
	// Use this for initialization
	void Awake () 
	{
		source = GetComponent <AudioSource>();
        source.volume = (float)PlayerPrefs.GetInt("musicVolume") * 0.1f;

        sliderMusic.value = (float)PlayerPrefs.GetInt("musicVolume");
        sliderSound.value = (float)PlayerPrefs.GetInt("soundsVolume");
    }

	void OnLevelWasLoaded (int scene) 
	{
		if (scene == 3) 
		{
			int level = PlayerPrefs.GetInt ("level");
			//level with spaceships world 1
			if ((level == 5) || (level == 10)) 
			{
				source.clip = musicBattle1;
			} else 
			//level with spaceships world 2
			if ((level == 16) || (level == 21)) 
			{
				source.clip = musicBattle1;
			} else 
			{
				source.clip = musicLevel;
			}
			source.Play ();
		} else if (scene == 1) 
		{
			source.clip = musicMenus;
			source.Play ();
		} else if (scene == 5) 
		{
			source.clip = musicBattle2;
			source.Play ();
		}
	}

    public void ChangeVolumeMusic ()
    {
        PlayerPrefs.SetInt("musicVolume", (int)sliderMusic.value);
        source.volume = (float)PlayerPrefs.GetInt("musicVolume") * 0.1f;
    }

    public void ChangeVolumeAudio()
    {
        PlayerPrefs.SetInt("soundsVolume", (int)sliderSound.value);
    }
}
