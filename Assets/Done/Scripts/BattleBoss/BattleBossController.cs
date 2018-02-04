using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleBossController : MonoBehaviour {
	
	public GameObject player;
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject asteroidGroup;
	public GameObject enemyGroup;
	public GameObject asteroidGroup2;
	public GameObject enemyGroup2;
	public GameObject textCount;

	public GameObject asteroidsb2n1;
	public GameObject asteroidsb2n2;
	public GameObject asteroidsb2n3;

	public Slider sliderPlayer;
	public Slider sliderEnemy;

	public Text finalText;
	public GameObject backgroundMenu;
	public GameObject FinishMenuButtons;
	public GameObject GameOverButtons;
	private int elapsedTime;
	private int battleNumber = 0;

	public GameObject redButton;
	public GameObject greenButton;

	public GameObject stars;

    public GameObject ImgVictory;
    public GameObject ImgDefeat;

    public GameObject plusPower;
    private int i = 0;
	
	void Start () {
		elapsedTime = (int)Time.time;
		battleNumber = PlayerPrefs.GetInt("battle");

		if ( (battleNumber == 1) || (battleNumber == 3) || (battleNumber == 5) )
		{
			Destroy (asteroidsb2n1);	Destroy (asteroidsb2n2);
			Destroy (asteroidsb2n3);
		}
		else if ( (battleNumber == 2) || (battleNumber == 4) || (battleNumber == 6) ) 
		{
			Destroy (asteroidGroup);	Destroy (asteroidGroup2);
			Destroy (enemyGroup);		Destroy (enemyGroup2);
		}

	}

	void Update () 
	{
        if (i == 0)
        {
            int seg = (int)Time.timeSinceLevelLoad;

            if ((battleNumber == 1) || (battleNumber == 3) || (battleNumber == 5))
            {
                EventsInLevels(seg);
            }
            else if ((battleNumber == 2) || (battleNumber == 4) || (battleNumber == 6))
            {
                EventsInLevels2(seg);
            }

            if (sliderEnemy.value == 0)
            {
                VictoryMenu();
                i = 1;
            }
            else if (sliderPlayer.value == 0)
            {
                GameOverMenu();
                i = 1;
            }
        }
	
	}

	void EventsInLevels (int seg)
	{
		if (seg == 4) 
		{
			player.SetActive(true);
			enemy.SetActive(true);
			textCount.SetActive(false);
			sliderPlayer.value = 1;
			sliderEnemy.value = 1;
		}
		
		if (seg == 7) 
		{
			asteroidGroup.SetActive(true);
		}

		if (seg == 15) 
		{
			asteroidGroup.SetActive(false);
			enemyGroup.SetActive(true);
		}

		if (seg == 21) 
		{
			enemyGroup.SetActive(false);
			asteroidGroup2.SetActive(true);
		}

		if (seg == 28) 
		{
			asteroidGroup2.SetActive(false);
			enemyGroup2.SetActive(true);
		}

		if (seg == 35) 
		{
			enemyGroup2.SetActive(true);
		}
	}

	void EventsInLevels2 (int seg)
	{
		if (seg == 4) 
		{
			player.SetActive (true);
			enemy2.SetActive (true);
			textCount.SetActive (false);
			sliderPlayer.value = 1;
			sliderEnemy.value = 1;
			//0 can not fire; 1 can fire
			PlayerPrefs.SetInt ("fire", 0);
			redButton.SetActive(true);
		}

		if ((seg == 14) || (seg == 34) || (seg == 54) || (seg == 74)) 
		{
			PlayerPrefs.SetInt ("fire", 1);
			greenButton.SetActive(true);
			redButton.SetActive(false);
		}

		if ((seg == 24) || (seg == 44) || (seg == 64) ) 
		{
			PlayerPrefs.SetInt ("fire", 0);
			greenButton.SetActive(false);
			redButton.SetActive(true);
		}

		if (seg == 17) 
		{
			asteroidsb2n1.SetActive(true);
		}

		if (seg == 37) 
		{
			asteroidsb2n2.SetActive(true);
			asteroidsb2n1.SetActive(false);
		}

		if (seg == 57) 
		{
			asteroidsb2n3.SetActive(true);
			asteroidsb2n2.SetActive(false);
		}
	}

	void VictoryMenu ()
	{
        //upgrade power ups
        plusPower.SetActive(true);
        PlayerData.playerData.superPower1 = PlayerData.playerData.superPower1 + 1;
        PlayerData.playerData.superPower2 = PlayerData.playerData.superPower2 + 1;

        player.SetActive (false);
		if ( (battleNumber == 1) || (battleNumber == 3) )
		{
			enemy.SetActive (false);
		} else if ( (battleNumber == 2) || (battleNumber == 4) )
		{
			enemy2.SetActive (false);
		}
		backgroundMenu.SetActive (true);
		stars.SetActive (true);

		if ( (battleNumber == 1) || (battleNumber == 2) ) {
			switch (PlayerData.playerData.languaje) {
			case 1:
				finalText.text = "you have completed the world " + battleNumber;
				break;
			case 2:
				finalText.text = "Has completado el mundo " + battleNumber;
				break;
			case 3:
				finalText.text = "Koncal si svet" + battleNumber;
				break;
			case 4:
				finalText.text = "vous avez complété le monde " + battleNumber;
				break;
			case 5:
				finalText.text = "ter concluído o mundo " + battleNumber;
				break;
			}
		} else 
		{
			switch (PlayerData.playerData.languaje) {
			case 1:
				finalText.text = "You have won the battle number" + battleNumber;
				break;
			case 2:
				finalText.text = "Has ganado la batalla numero " + battleNumber;
				break;
			case 3:
				finalText.text = "Zmagal si bitko stevilka " + battleNumber;
				break;
			case 4:
				finalText.text = "Vous avez gagné la bataille - " + battleNumber;
				break;
			case 5:
				finalText.text = "você ganhou a batalha - " + battleNumber;
				break;
			}
		}

        ImgVictory.SetActive(true);

		PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 3;


		if ( (battleNumber == 1) && (PlayerData.playerData.currentlevel == 11) )
		{
				PlayerData.playerData.currentlevel =  PlayerData.playerData.currentlevel + 1;
		}
		else
		if ( (battleNumber == 2) && (PlayerData.playerData.currentlevel == 22) )
		{
			PlayerData.playerData.currentlevel =  PlayerData.playerData.currentlevel + 1;
		}
		else
		if ( (battleNumber == 3) && (PlayerData.playerData.currentlevel == 29) )
		{
			PlayerData.playerData.currentlevel =  PlayerData.playerData.currentlevel + 1;
		}
		else
		if ( (battleNumber == 4) && (PlayerData.playerData.currentlevel == 36) )
		{
			PlayerData.playerData.currentlevel =  PlayerData.playerData.currentlevel + 1;
		}

		PlayerData.playerData.Save();
		FinishMenuButtons.SetActive (true);
	}

	void GameOverMenu ()
	{
		//changing player data
		PlayerData.playerData.totalmatches = PlayerData.playerData.totalmatches + 1;
		PlayerData.playerData.Save();

		player.SetActive (false);
		enemy.SetActive (false);
		enemy2.SetActive (false);
		backgroundMenu.SetActive (true);

        ImgDefeat.SetActive(true);

        GameOverButtons.SetActive (true);
	}
}
