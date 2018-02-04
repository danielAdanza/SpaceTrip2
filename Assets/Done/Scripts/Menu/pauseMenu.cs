using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {

	public Text pauseText;
	public GameObject button;
	public GameObject pausedObject;
	public GameObject background;
    public GameObject ShootingQuestion;

    public void Start ()
    {
        if (PlayerData.playerData.shootingMode == 0)
        {
            ShowOnlyShootingQuestion();
        }
    }
	public void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			onPauseClicked ();
		}
	}

	public void onPauseClicked ()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;

			switch (PlayerData.playerData.languaje) 
			{
			  case 1:
				pauseText.text = "GAME PAUSED";
				break;
			  case 2:
				pauseText.text = "JUEGO EN PAUSA";
				break;
			  case 3:
				pauseText.text = "PAUZA";
				break;
			  case 4:
				pauseText.text = "GAME PAUSED";
				break;
			  case 5:
				pauseText.text = "GAME PAUSED";
				break;
			}
			background.SetActive (true);
			pausedObject.SetActive (true);
            ShootingQuestion.SetActive(true);

		}
		else
		{
			Time.timeScale = 1;
			pauseText.text = "";
			background.SetActive (false);
			pausedObject.SetActive (false);
            ShootingQuestion.SetActive(false);
        }
	}

	public void WhenExitIsClicked ()
	{
		Application.Quit ();
	}

    public void ShowOnlyShootingQuestion ()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        background.SetActive(true);
        ShootingQuestion.SetActive(true);
    }

    public void YesClicked ()
    {
        //change elements in the interface
        pauseText.text = "";
        background.SetActive(false);
        pausedObject.SetActive(false);
        ShootingQuestion.SetActive(false);
        //save the corrected values in playerData
        PlayerData.playerData.shootingMode = 1;
        PlayerData.playerData.Save();
        //change timeScale
        Time.timeScale = 1;
    }

    public void NoClicked()
    {
        //change elements in the interface
        pauseText.text = "";
        background.SetActive(false);
        pausedObject.SetActive(false);
        ShootingQuestion.SetActive(false);
        //save the corrected values in playerData
        PlayerData.playerData.shootingMode = 2;
        PlayerData.playerData.Save();
        //change timeScale
        Time.timeScale = 1;
    }
}
