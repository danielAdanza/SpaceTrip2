using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	//level differences within the number of asteroids, the time distance within them and so on
	private int level;
	private int hazardCount;
	private float spawnWait;
	private float startWait;
	private float waveWait;
	private int numberWaves;
	private int maxscore;
	//interface objects
	public Text scoreText;
	public Text coinsText;
	public Text totalScoreText;
	//buttons
	public GameObject restartButton;
	public GameObject mainMenuButton;
	public GameObject nextLevelButton;
	public GameObject lifesButton;
	public GameObject shareButton;
	public GameObject backgroundImage;
	public RawImage star1;
	public RawImage star2;
	public RawImage star3;
	public GameObject pauseButton;
	//variables for game over and score
	private bool gameOver;
	private int score = 0;
    private int coins = PlayerData.playerData.totalCoins;
    public GameObject victoryImage;
    public GameObject defeatImage;
    public GameObject totalCoinsText;
    public GameObject totalWeaponLevelText;
	//for the different languajes
	string total = "";
    public GameObject playerManager;
    //variables for special levels with spaceships
    public GameObject frameCoins;
    public GameObject frameSpaceShips;
    public bool missionLevel = false;
    private int missionSpaceships = 0;
    public Text missionScore;
    private float time, initialTime;
    public Text timeText;

    public bool gameFinish = false;
    public GameObject pluBomb;

    public int alreadyGotCoins = 0;
	
	void Start ()
	{
		level = PlayerPrefs.GetInt ("level");
		CreateLevelSettings (level);
		gameOver = false;
        totalScoreText.text = "";
        initialTime = Time.time;
        time = 0;
        alreadyGotCoins = PlayerData.playerData.totalCoins;

        if (missionLevel == true)
        {   timeText.text = "0"; }

        if (missionLevel == false)
        {   UpdateScore(); }
        else
        {   UpdateScoreMissions(); }
		
		coinsText.text = "" + coins;
		
		StartCoroutine (SpawnWaves ());
		
		switch (PlayerData.playerData.languaje) 
		{
		    case 1:
			    total = "total";
			    break;
		    case 2:
			    total = "total";
			    break;
		    case 3:
			    total = "skupno";
			    break;
		    case 4:
			    total = "total";
			    break;
		    case 5:
			    total = "total";
			    break;
		}

        PlayerPrefs.SetInt("BoltLevel", 0);

        totalCoinsText.SetActive(false);
        totalWeaponLevelText.SetActive(false);
	}
	
    void Update ()
    {
        if ( (missionLevel == true) && (Time.time >= time + 1f) && (gameFinish == false) )
        {
            //code something
            time = Time.time - initialTime;
            timeText.text = "" + (int) time;
        }
    }

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (numberWaves > 0)
		{
			numberWaves--;
			for (int i = 0; i < hazardCount; i++)
			{
				int hazardNumber = 0;
				if (PlayerPrefs.GetInt ("level") <= 22)
				{
					hazardNumber = CreateHazardLevel(level);
				}
				else
				{
					hazardNumber = CreateHazardLevel2();
				}
				GameObject hazard = hazards [hazardNumber];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

                if ( (missionLevel == true) && (missionSpaceships == 0) )
                {
                    i = hazardCount;
                    numberWaves = 0;
                }

                if (PlayerPrefs.GetInt("SP1") == 1)
                {
                    PlayerPrefs.SetInt("SP1", 0);
                }
			}
			yield return new WaitForSeconds (waveWait);

            gameFinish = true;

            if ( (missionLevel == true) && (missionSpaceships > 0) )
            {
                gameOver = true;
            }
			
			if (gameOver)
			{
				backgroundImage.SetActive(true);
                restartButton.SetActive(true);
				mainMenuButton.SetActive(true);
				lifesButton.SetActive(true);
				break;
			}
		}

		GameFinished ();
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

    public void AddScoreMision()
    {
        if (missionSpaceships != 0)
        {
            missionSpaceships = missionSpaceships - 1;
            UpdateScoreMissions();
        }
        
    }

    void UpdateScore ()
	{
		scoreText.text = "" + score;
	}

    void UpdateScoreMissions()
    {
        missionScore.text = "" + missionSpaceships;
    }

    public void AddCoins(int newCoinsValue)
    {
        coins += newCoinsValue;
        UpdateCoins();
    }

    void UpdateCoins()
    {
        coinsText.text = "" + coins;
        AddScore(5);
    }

    //right after the death a couple of things happen
    public void GameOver ()
	{
        defeatImage.SetActive(true);
        pauseButton.SetActive (false);
        gameOver = true;
		PlayerData.playerData.totalmatches = PlayerData.playerData.totalmatches + 1;
        PlayerData.playerData.totalCoins = coins;
        PlayerData.playerData.Save();
    }

	public void GameFinished ()
	{
		pauseButton.SetActive (false);
        playerManager.SetActive(false);

        totalCoinsText.GetComponent<Text>().text = (PlayerData.playerData.totalCoins - alreadyGotCoins) + "";
        totalCoinsText.SetActive(true);

        totalWeaponLevelText.GetComponent<Text>().text = PlayerPrefs.GetInt("BoltLevel") + "";
        totalWeaponLevelText.SetActive(true);

        if (gameOver == false) {

            victoryImage.SetActive(true);

            PlayerPrefs.SetInt ("revivir", 0);

            victoryImage.SetActive(true);
			backgroundImage.SetActive (true);

			star1.gameObject.SetActive (true);
			star2.gameObject.SetActive (true);
			star3.gameObject.SetActive (true);

            if (missionLevel == false)
            {
                if (score < maxscore * 3 / 10)
                {
                    star1.color = Color.black;
                    star1.CrossFadeAlpha(0.5f, 1f, true);
                }
                else
                {
                    if (PlayerData.playerData.scoreinlevels[level - 1] < score)
                    {
                        PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 1;
                    }
                    
                }

                if (score < maxscore * 6 / 10)
                {
                    star2.color = Color.black;
                    star2.CrossFadeAlpha(0.5f, 1f, true);
                }
                else {
                    if (PlayerData.playerData.scoreinlevels[level - 1] < score)
                    {
                        PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 1;
                    }
                }

                if (score < maxscore * 9 / 10)
                {
                    star3.color = Color.black;
                    star3.CrossFadeAlpha(0.5f, 1f, true);
                }
                else {
                    if (PlayerData.playerData.scoreinlevels[level - 1] < score)
                    {
                        PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 1;
                    }
                }
            }
            else
            {
                if (PlayerData.playerData.scoreinlevels[level - 1] == 0)
                    PlayerData.playerData.totalStarts = PlayerData.playerData.totalStarts + 3;
            }

			//actualizando los datos en el objeto playerData
			PlayerData.playerData.totalmatches = PlayerData.playerData.totalmatches + 1;
			PlayerData.playerData.totalvictories = PlayerData.playerData.totalvictories + 1;
            PlayerData.playerData.totalCoins = coins;

            if (missionLevel == false)
            {
                PlayerData.playerData.totalscore = PlayerData.playerData.totalscore + score;
                if (PlayerData.playerData.scoreinlevels[level - 1] < score)
                {
                    PlayerData.playerData.scoreinlevels[level - 1] = score;
                }

                totalScoreText.text = " + (" + score + ") " + total + " " + PlayerData.playerData.totalscore;
            }
            else
            {
                PlayerData.playerData.totalscore = PlayerData.playerData.totalscore + (int)time;
                if ( (PlayerData.playerData.scoreinlevels[level - 1] > (int) time ) || ( PlayerData.playerData.scoreinlevels[level - 1] == 0) )
                {
                    PlayerData.playerData.scoreinlevels[level - 1] = (int)time;
                }

                totalScoreText.text = " + (" + (int)time + " s. ) " + total + " " + PlayerData.playerData.totalscore;
            }

			if (level == PlayerData.playerData.currentlevel) {
				PlayerData.playerData.currentlevel = PlayerData.playerData.currentlevel + 1;

                if (level == 5 || level == 10)
                {
                    pluBomb.SetActive(true);
                    PlayerData.playerData.superPower1 = PlayerData.playerData.superPower1 + 1;
                }
			}
			PlayerData.playerData.Save ();


			
			mainMenuButton.SetActive (true);
			if ( (level != 4) && (level != 9) && (level != 10) && (level != 15) && (level != 20) )
			{	
				nextLevelButton.SetActive (true);
			}
			shareButton.SetActive (true);
		}
		else 
		{
			//if it enters here the player have lost

            //in the case of normal levels
            if (missionLevel == false)
            {
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.SetInt("numberWaves", numberWaves);
            }
            else
            {
                PlayerPrefs.SetInt("scoreMission", missionSpaceships);
                PlayerPrefs.SetInt("numberWaves", numberWaves);
                PlayerPrefs.SetInt("timePassed", (int) time);
            }
		}

	}

	public void RestartGame () 
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void NextGame () 
	{
		PlayerPrefs.SetInt ("level",PlayerPrefs.GetInt ("level") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void MainMenu () 
	{
		Time.timeScale = 1;
        SceneManager.LoadScene("LevelMenu");
	}

	public void Share () 
	{
		if (FB.IsLoggedIn) 
		{
			FB.Feed (
				    //the message that will appear in the facebook post
				    linkCaption: "I passed the level" + level + " in SPACE TRIP! would you do it better?",
				    //the link of the picture that has to be in the server
				    picture: "https://ksr-ugc.imgix.net/assets/012/722/855/d66f626e8bd456e0ae78effc4302b8b1_original.png?w=1024&h=576&fit=fill&bg=000000&v=1465768833&auto=format&q=92&s=f3ffa21ce542f198b03ad1c42de4810a",
				    //the text that they will see
				    linkName: "Check it out",
				    //that should be the link to google play
				    link: "https://play.google.com/store/apps/details?id=adanzaapps.space.trip2"
                );
		}
		else 
		{
			FB.Login ("email,publish_actions", AuthCallback);
		}
	}

	void AuthCallback (FBResult result)
	{
		if (!FB.IsLoggedIn) 
		{
			Debug.Log ("the login did not work");
		}
	}

	void CreateLevelSettings (int level)
	{
		startWait = 1f;			waveWait = 3f;
		switch (level)
		{
			case 1:
				hazardCount = 5;		numberWaves = 8;		spawnWait = 1f;
				maxscore = 560;
				break;
			case 2:
				hazardCount = 6;		numberWaves = 8;		spawnWait = 1f;
				maxscore = 672;
				break;
			case 3:
				hazardCount = 7;		numberWaves = 8;		spawnWait = 1f;
				maxscore = 784;
				break;
			case 4:
				hazardCount = 8;		numberWaves = 7;		spawnWait = 0.95f;
				maxscore = 896;
				break;
			case 5:
				hazardCount = 5;		numberWaves = 8;		spawnWait = 0.95f;
				maxscore = 800;         missionLevel = true;    missionSpaceships = 4;
                break;
			case 6:
				hazardCount = 9;		numberWaves = 5;		spawnWait = 0.95f;
				maxscore = 630;
				break;
			case 7:
				hazardCount = 10;		numberWaves = 9;		spawnWait = 0.9f;
				maxscore = 1260;
				break;
			case 8:
				hazardCount = 11;		numberWaves = 9;		spawnWait = 0.9f;
				maxscore = 1386;
				break;
			case 9:
				hazardCount = 12;		numberWaves = 8;		spawnWait = 0.9f;
				maxscore = 1512;
				break;
			case 10:
				hazardCount = 8;		numberWaves = 8;		spawnWait = 0.9f;
				maxscore = 896;         missionLevel = true;    missionSpaceships = 5;
                break;
			//second world
			case 12:
				hazardCount = 10;		numberWaves = 10;		spawnWait = 0.85f;
				maxscore = 1400;
				break;
			case 13:
				hazardCount = 11;		numberWaves = 10;		spawnWait = 0.85f;
				maxscore = 1540;
				break;
			case 14:
				hazardCount = 12;		numberWaves = 10;		spawnWait = 0.85f;
				maxscore = 1680;
				break;
			case 15:
				hazardCount = 13;		numberWaves = 9;		spawnWait = 0.85f;
				maxscore = 1820;
				break;
			case 16:
				hazardCount = 6;		numberWaves = 10;		spawnWait = 0.85f;
				maxscore = 1200;        missionLevel = true;    missionSpaceships = 6;
                break;
			case 17:
				hazardCount = 14;		numberWaves = 11;		spawnWait = 0.8f;
				maxscore = 2156;
				break;
			case 18:
				hazardCount = 15;		numberWaves = 11;		spawnWait = 0.8f;
				maxscore = 2310;
				break;
			case 19:
				hazardCount = 16;		numberWaves = 11;		spawnWait = 0.8f;
				maxscore = 2464;
				break;
			case 20:
				hazardCount = 17;		numberWaves = 10;		spawnWait = 0.8f;
				maxscore = 2618;
				break;
			case 21:
				hazardCount = 9;		numberWaves = 11;		spawnWait = 0.8f;
				maxscore = 1366;        missionLevel = true;    missionSpaceships = 7;
                break;
			//third world
			case 23:
				hazardCount = 12;		numberWaves = 12;		spawnWait = 0.75f;
				maxscore = 2016;
				break;
			case 24:
				hazardCount = 13;		numberWaves = 12;		spawnWait = 0.75f;
				maxscore = 2184;
				break;
			case 25:
				hazardCount = 14;		numberWaves = 12;		spawnWait = 0.75f;
				maxscore = 2352;
				break;
			case 26:
				hazardCount = 15;		numberWaves = 11;		spawnWait = 0.75f;
				maxscore = 2520;
				break;
			case 27:
				hazardCount = 5;		numberWaves = 11;		spawnWait = 0.75f;
				maxscore = 1100;        missionLevel = true;    missionSpaceships = 8;
                break;
			case 28:
				hazardCount = 8;		numberWaves = 11;		spawnWait = 0.75f;
				maxscore = 1760;        missionLevel = true;    missionSpaceships = 9;
                break;
			case 30:
				hazardCount = 17;		numberWaves = 12;		spawnWait = 0.7f;
				maxscore = 2856;
				break;
			case 31:
				hazardCount = 18;		numberWaves = 12;		spawnWait = 0.7f;
				maxscore = 3024;
				break;
			case 32:
				hazardCount = 19;		numberWaves = 12;		spawnWait = 0.7f;
				maxscore = 3192;
				break;
			case 33:
				hazardCount = 20;		numberWaves = 11;		spawnWait = 0.7f;
				maxscore = 3360;
				break;
			case 34:
				hazardCount = 10;		numberWaves = 11;		spawnWait = 0.7f;
				maxscore = 2200;        missionLevel = true;    missionSpaceships = 9;
                break;
			case 35:
				hazardCount = 12;		numberWaves = 11;		spawnWait = 0.7f;
				maxscore = 2640;        missionLevel = true;    missionSpaceships = 10;
                break;
			//fourth world
			case 37:
				hazardCount = 13;		numberWaves = 10;		spawnWait = 0.7f;
				maxscore = 1820;
				break;
			case 38:
				hazardCount = 14;		numberWaves = 10;		spawnWait = 0.7f;
				maxscore = 1960;
				break;
			case 39:
				hazardCount = 15;		numberWaves = 10;		spawnWait = 0.7f;
				maxscore = 2100;
				break;
			case 40:
				hazardCount = 16;		numberWaves = 9;		spawnWait = 0.7f;
				maxscore = 2240;
				break;
			case 41:
				hazardCount = 15;		numberWaves = 10;		spawnWait = 0.7f;
				maxscore = 3000;        missionLevel = true;    missionSpaceships = 10;
                break;
			case 42:
				hazardCount = 16;		numberWaves = 10;		spawnWait = 0.7f;
				maxscore = 3200;        missionLevel = true;    missionSpaceships = 11;
                break;
			case 44:
				hazardCount = 17;		numberWaves = 10;		spawnWait = 0.7f;
				maxscore = 2380;
				break;
			case 45:
				hazardCount = 18;		numberWaves = 10;		spawnWait = 0.65f;
				maxscore = 2520;
				break;
			case 46:
				hazardCount = 19;		numberWaves = 10;		spawnWait = 0.65f;
				maxscore = 2660;
				break;
			case 47:
				hazardCount = 20;		numberWaves = 9;		spawnWait = 0.65f;
				maxscore = 2800;
				break;
			case 48:
				hazardCount = 17;		numberWaves = 10;		spawnWait = 0.65f;
				maxscore = 3400;        missionLevel = true;    missionSpaceships = 11;
                break;
			case 49:
				hazardCount = 18;		numberWaves = 10;		spawnWait = 0.65f;
				maxscore = 3600;        missionLevel = true;    missionSpaceships = 12;
                break;
		}

        if (missionLevel == true)
        {
            frameCoins.SetActive(false);
            frameSpaceShips.SetActive(true);

            //mirando si ha revivido o no
            //0 no ha revivido y 1 si
            int survival = PlayerPrefs.GetInt("revivir");
            if (survival == 1)
            {
                missionSpaceships = PlayerPrefs.GetInt("scoreMission");
                numberWaves = PlayerPrefs.GetInt("numberWaves");
                time = PlayerPrefs.GetInt("timePassed");
            }
            else
            {
                score = 0;
            }
        }
        else
        {
            //mirando si ha revivido o no
            //0 no ha revivido y 1 si
            int survival = PlayerPrefs.GetInt("revivir");
            if (survival == 1)
            {
                score = PlayerPrefs.GetInt("score");
                numberWaves = PlayerPrefs.GetInt("numberWaves");
            }
            else
            {
                score = 0;
            }
        }
		
	}
	
	int CreateHazardLevel (int level)
	{
        //it will always create a random number
		int random = Random.Range (0,11);
        //that is the final position of the array
		int final = 0;
		switch (level)
		{
            //WORLD 1
            case 1:
                if (random < 6)
                { final = 12; }
                break;
            case 2: case 3:
                if (random > 7)
                { final = 1; }
                else if (random > 4)
                {final = 12;}
				break;
			case 4:
                if (random > 8)
                { final = 1; }
                else if (random > 4)
                { final = 12; }
                else
                { final = 3; }
                break;
            case 5: case 10:
				final = 3;
				break;
			case 6:
				if (random > 5)
				{final = 2;}
                else
                { final = 13; }
				break;
			case 7:
                if(random > 5)
                { final = 2; }
                else
                { final = 14; }
                break;
			case 8:
                if (random > 5)
                { final = 13; }
                else
                { final = 14; }
                break;
            case 9:
                if (random > 8)
                { final = 2; }
                else if (random > 3)
                { final = 14; }
                else
                { final = 3; }
                break;
            //WORLD 2
            case 12:
                if (random < 6)
                { final = 4; }
                else
                { final = 5; }
                break;
            case 13: case 14:
                if (random > 7)
                { final = 4; }
                else if (random > 4)
                { final = 5; }
                else
                {  }
                break;
            case 15:
                if (random > 8)
                { final = 1; }
                else if (random > 4)
                { final = 12; }
                else
                { final = 7; }
                break;
            case 16: case 21:
                final = 7;
                break;
            case 17:
                if (random > 5)
                { final = 6; }
                else
                { final = 13; }
                break;
            case 18:
                if (random > 5)
                { final = 6; }
                else
                { final = 15; }
                break;
            case 19:
                if (random > 5)
                { final = 13; }
                else
                { final = 15; }
                break;
            case 20:
                if (random > 7)
                { final = 7; }
                else if (random > 3)
                { final = 13; }
                else
                { final = 15; }
                break;

        }

		return final;
	}

	int CreateHazardLevel2 ()
	{
		int random = Random.Range (0,11);
		int final;
		final = 8;
		int level = PlayerPrefs.GetInt ("level");

		if ((level > 36) && (level < 51)) 
		{
			final = random;
		}

		switch (level) 
		{
            //WORLD 3
			case 23:
                if (random > 6)
                { final = 0; }
                else
                { final = 16; }
                break;
			case 24:
                if (random > 6)
                { final = 12; }
                else
                { final = 16; }
                break;
			case 25:  case 26:
                if (random > 7)
                { final = 16; }
                else if (random > 4)
                { final = 12; }
                else
                { final = 0; }
				break;
			case 27: case 28:
				final = 11;
				break;
			case 30:
				if (random > 5)
				{ final = 6; }
				else
				{ final = 17; }
				break;
			case 31:
				if (random > 5)
				{ final = 17; }
				else
				{ final = 15; }
				break;
			case 32:  case 33:
				if (random > 7)
				{ final = 17; }
				else if (random > 4)
				{ final = 15; }
                else
                { final = 6; }
				break;
			case 34:  case 35:
                final = 11;
                break;
            //WORLD 4
            case 37:
                if (random > 6)
                { final = 18; }
                else
                { final = 19; }
                break;
            case 38:
                if (random > 6)
                { final = 18; }
                else
                { final = 16; }
                break;
            case 39: case 40:
                if (random > 7)
                { final = 16; }
                else if (random > 4)
                { final = 18; }
                else
                { final = 19; }
                break;
            case 41:  case 42:  case 48:  case 49:
                if (random > 7)
                { final = 3; }
                else if (random > 4)
                { final = 7; }
                else
                { final = 11; }
                break;
            case 44:
                if (random > 5)
                { final = 6; }
                else
                { final = 17; }
                break;
            case 45:
                if (random > 5)
                { final = 17; }
                else
                { final = 15; }
                break;
            case 46:  case 47:
                if (random > 7)
                { final = 17; }
                else if (random > 4)
                { final = 15; }
                else
                { final = 6; }
                break;
        }

		return final;
	}
}