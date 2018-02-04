using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour 
{
	public GameObject loadingImage;
	public Slider loadingBar;
	private AsyncOperation async;
	public GameObject backgroundMenu;
	public GameObject instructionsLv1;
	public GameObject instructionsLv5;
	public GameObject instructionsLv11;
	public GameObject instructionsLv22;

    //this array is the maximum score in Levels
    public int[] maxScoreLevels;

    //new objects for popup
    public Text levelText;
    public GameObject popUpLevelMenu;
    public GameObject storeObject;
    public RawImage star1;
    public RawImage star2;
    public RawImage star3;
    //objects for the popup
    public GameObject scoreEntry1;
    public GameObject scoreEntry2;
    public GameObject scoreEntry3;
    public GameObject scoreEntry4;
    public Texture[] avatarImg;
    public RawImage[] scoreImgs;
    public Text[] scoreNames;
    public Text[] scoreScores;
    public Text playText;
    public Text descriptionText;

    public Text starsText;

    public GameObject noAdsSection;

    void Start ()
    {
        if (PlayerData.playerData.totalStarts < 150)
            starsText.text = PlayerData.playerData.totalStarts + "/150";
        else
            starsText.text = "150/150";

        if ( PlayerPrefs.GetString("noAds").Equals("NO") )
        {
            noAdsSection.SetActive(false);
        }
    }

    //first of all we load the popUpMenu
    public void LoadPopUp (int level)
    {
        //the first thing that it does is to set the level and the revival in the playerSettings
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("revivir", 0);

        //getting the score
        int previousScore = PlayerData.playerData.scoreinlevels[level - 1];

        if ( (level == 5) || (level == 10) || (level == 16) || (level == 21) || (level == 27) || (level == 28) || (level == 34) || (level == 35) || (level == 41) || (level == 42) || (level == 48) || (level == 49))
        {
            if (previousScore == 0)
            {
                star1.GetComponent<RawImage>().color = Color.gray;
                star2.GetComponent<RawImage>().color = Color.gray;
                star3.GetComponent<RawImage>().color = Color.gray;
            }

            //create offline ranking for missions
            CreateRankingOffLineSeconds(level);
        }
        else
        {
            if (previousScore < (maxScoreLevels[level] / 4))
            {
                star1.GetComponent<RawImage>().color = Color.gray;
                star2.GetComponent<RawImage>().color = Color.gray;
                star3.GetComponent<RawImage>().color = Color.gray;
            }
            else if (previousScore < (maxScoreLevels[level] / 2))
            {
                star1.GetComponent<RawImage>().color = Color.white;
                star2.GetComponent<RawImage>().color = Color.gray;
                star3.GetComponent<RawImage>().color = Color.gray;
            }
            else if (previousScore < (maxScoreLevels[level] * 3 / 4))
            {
                star1.GetComponent<RawImage>().color = Color.white;
                star2.GetComponent<RawImage>().color = Color.white;
                star3.GetComponent<RawImage>().color = Color.gray;
            }
            else
            {
                star1.GetComponent<RawImage>().color = Color.white;
                star2.GetComponent<RawImage>().color = Color.white;
                star3.GetComponent<RawImage>().color = Color.white;
            }

            //change the offline ranking
            CreateRankingOffLine(level);
        }
        

        

        //change the languaje and text depending on the level
        switch  (PlayerData.playerData.languaje)
        {
            case 1:
                levelText.text = "Level " + level;
                if ((level == 5) || (level == 10) || (level == 16) || (level == 21) || (level == 27) || (level == 28) || (level == 34) || (level == 35) || (level == 41) || (level == 42) || (level == 48) || (level == 49))
                {descriptionText.text = "objective \n Destroy the \n enemy spaceships"; }
                playText.text = "Play";
                break;
            case 2:
                levelText.text = "Nivel " + level;
                if ((level == 5) || (level == 10) || (level == 16) || (level == 21) || (level == 27) || (level == 28) || (level == 34) || (level == 35) || (level == 41) || (level == 42) || (level == 48) || (level == 49))
                { descriptionText.text = "Objetivo \n Destruir a las \n naves enemigas"; }
                else
                { descriptionText.text = "Objetivo \n \n disparar a todo!"; }
                playText.text = "Jugar";
                break;
            case 3:
                levelText.text = "Raven " + level;
                if ((level == 5) || (level == 10) || (level == 16) || (level == 21) || (level == 27) || (level == 28) || (level == 34) || (level == 35) || (level == 41) || (level == 42) || (level == 48) || (level == 49))
                { descriptionText.text = "ciljna \n \n uničiti sovražne ladje"; }
                else
                { descriptionText.text = "ciljna \n \n jih vse ustreliti!"; }
                playText.text = "igrajo";
                break;
            case 4:
                levelText.text = "niveau " + level;
                if ((level == 5) || (level == 10) || (level == 16) || (level == 21) || (level == 27) || (level == 28) || (level == 34) || (level == 35) || (level == 41) || (level == 42) || (level == 48) || (level == 49))
                { descriptionText.text = "cible \n détruire les \n vaisseaux ennemis"; }
                else
                { descriptionText.text = "cible \n \n tirer tous!"; }
                playText.text = "jouer";
                break;
            case 5:
                levelText.text = "jogar " + level;
                if ((level == 5) || (level == 10) || (level == 16) || (level == 21) || (level == 27) || (level == 28) || (level == 34) || (level == 35) || (level == 41) || (level == 42) || (level == 48) || (level == 49))
                { descriptionText.text = "alvo \n destruir navios \n inimigos"; }
                else
                { descriptionText.text = "alvo \n \n matá-los todos!"; }
                playText.text = "jouer";
                break;

        }

        popUpLevelMenu.SetActive(true);
        backgroundMenu.SetActive(true);
    }

    //here it prepairs everything in order to load the scene and to make different comprobations
    //if you have this level unlocked or if yuo need to load instructions for example
	public void LoadScene ()
	{
        //first it tracks the level that you are loading
        int level = PlayerPrefs.GetInt("level");

        //then it checks if you need instructions
        if ( (level == 1) || (level == 5) )
        {
            popUpLevelMenu.SetActive(false);

            if (level == 1)
            {
                LoadInstructions();
            }
            else if (level == 5)
            {
                LoadInstructions2();
            }
        }
        else
        {
            if (level > PlayerData.playerData.currentlevel)
            {
            }
            else
            {
                LoadSceneRaw(level);
            }
        }

        
		
	}

    public void LoadSceneRaw(int level)
    {
         
        loadingImage.SetActive(true);
        if ((level == 1) || (level == 5) || (level == 10) || (level == 12) || (level == 16) || (level == 21))
        {
             StartCoroutine(LoadLevelWithBar(6));
        }
        else
        {
            StartCoroutine(LoadLevelWithBar(3));
        }        
    }

    public void LoadBattle (int level)
	{
        if (level > PlayerData.playerData.currentlevel)
        {
        }
        else
        {
            loadingImage.SetActive(true);
            PlayerPrefs.SetInt("battle", level);
            StartCoroutine(LoadLevelWithBar(5));
        }
	}

	IEnumerator LoadLevelWithBar (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}

	public void LoadInstructions ()
	{
       backgroundMenu.SetActive(true);
       instructionsLv1.SetActive(true);
	}

	public void LoadInstructions2 ()
	{
        if (5 > PlayerData.playerData.currentlevel)
        {
        }
        else
        {
            backgroundMenu.SetActive(true);
            instructionsLv5.SetActive(true);
        }
	}

	public void LoadInstructions3 ()
	{
        if (11 > PlayerData.playerData.currentlevel)
        {
        }
        else
        {
            backgroundMenu.SetActive(true);
            instructionsLv11.SetActive(true);
        }
	}

	public void LoadInstructions4 ()
	{
        if (22 > PlayerData.playerData.currentlevel)
        {
        }
        else
        {
            backgroundMenu.SetActive(true);
            instructionsLv22.SetActive(true);
        }
	}

    public void LoadStore()
    {
        WhenCloseIsClicked();

        backgroundMenu.SetActive(true);
        storeObject.SetActive(true);
    }

    public void WhenCloseIsClicked ()
    {
        backgroundMenu.SetActive(false);
        instructionsLv1.SetActive(false);
        instructionsLv5.SetActive(false);
        instructionsLv11.SetActive(false);
        instructionsLv22.SetActive(false);
        popUpLevelMenu.SetActive(false);
        storeObject.SetActive(false);
    }

    public void CreateRankingOffLine (int level)
    {
        int previousScore = PlayerData.playerData.scoreinlevels[level - 1];
        int maxScore = maxScoreLevels[level];

        //el primero de la persona ficticia tiene un 85% del score máximo
        //el segundo tiene un 70 %
        //el tercero tiene un 45%

        //en el caso de que el jugador sea el primero

        float scoref1 = maxScore * 0.85f;
        float scoref2 = maxScore * 0.70f;
        float scoref3 = maxScore * 0.45f;

        int score1, score2, score3;

        score1 = (int) scoref1;
        score2 = (int)scoref2;
        score3 = (int)scoref3;

        if (previousScore >= maxScore * 0.85)
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[3];
            scoreImgs[1].texture = avatarImg[2];
            scoreImgs[2].texture = avatarImg[1];
            scoreImgs[3].texture = avatarImg[0];

            //cambiar el nombre
            scoreNames[0].text = "you   ";
            scoreNames[1].text = "apolo";
            scoreNames[2].text = "ravana";
            scoreNames[3].text = "marín";

            //cambiar el score
            scoreScores[0].text = previousScore + "  ";
            scoreScores[1].text = score1 + "  ";
            scoreScores[2].text = score2 + "  ";
            scoreScores[3].text = score3 + "  ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.grey;
            scoreEntry2.GetComponent<Image>().color = Color.white;
            scoreEntry3.GetComponent<Image>().color = Color.white;
            scoreEntry4.GetComponent<Image>().color = Color.white;

        }
        //si el jugador es el segundo
        else if (previousScore >= maxScore * 0.70)
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[2];
            scoreImgs[1].texture = avatarImg[3];
            scoreImgs[2].texture = avatarImg[1];
            scoreImgs[3].texture = avatarImg[0];

            //cambiar el nombre
            scoreNames[0].text = "apolo";
            scoreNames[1].text = "you   ";
            scoreNames[2].text = "ravana";
            scoreNames[3].text = "marín";

            //cambiar el score
            scoreScores[0].text = score1 + "  ";
            scoreScores[1].text = previousScore + "  ";
            scoreScores[2].text = score2 + "  ";
            scoreScores[3].text = score3 + "  ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.white;
            scoreEntry2.GetComponent<Image>().color = Color.grey;
            scoreEntry3.GetComponent<Image>().color = Color.white;
            scoreEntry4.GetComponent<Image>().color = Color.white;
        }
        //si el jugador es el segundo
        else if (previousScore >= maxScore * 0.45)
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[2];
            scoreImgs[1].texture = avatarImg[1];
            scoreImgs[2].texture = avatarImg[3];
            scoreImgs[3].texture = avatarImg[0];

            //cambiar el nombre
            scoreNames[0].text = "apolo";
            scoreNames[1].text = "ravana";
            scoreNames[2].text = "you   ";
            scoreNames[3].text = "marín";

            //cambiar el score
            scoreScores[0].text = score1 + "  ";
            scoreScores[1].text = score2 + "  ";
            scoreScores[2].text = previousScore + "  ";
            scoreScores[3].text = score3 + "  ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.white;
            scoreEntry2.GetComponent<Image>().color = Color.white;
            scoreEntry3.GetComponent<Image>().color = Color.grey;
            scoreEntry4.GetComponent<Image>().color = Color.white;
        }
        //si el jugador es el segundo
        else
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[2];
            scoreImgs[1].texture = avatarImg[1];
            scoreImgs[2].texture = avatarImg[0];
            scoreImgs[3].texture = avatarImg[3];

            //cambiar el nombre
            scoreNames[0].text = "apolo";
            scoreNames[1].text = "ravana";
            scoreNames[2].text = "marín";
            scoreNames[3].text = "you   ";

            //cambiar el score
            scoreScores[0].text = score1 + "  ";
            scoreScores[1].text = score2 + "  ";
            scoreScores[2].text = score3 + "  ";
            scoreScores[3].text = previousScore + "  ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.white;
            scoreEntry2.GetComponent<Image>().color = Color.white;
            scoreEntry3.GetComponent<Image>().color = Color.white;
            scoreEntry4.GetComponent<Image>().color = Color.grey;
        }
    }

    public void CreateRankingOffLineSeconds(int level)
    {
        int previousScore = PlayerData.playerData.scoreinlevels[level - 1];
        int maxScore = 0;
        int score1 = 0, score2 = 0, score3 = 0;

        if (level < 12)
        {
            maxScore = 16;
            score1 = 8;
            score2 = 12;
            score3 = 16;
        }
        else if (level < 24)
        {
            maxScore = 24;
            score1 = 12;
            score2 = 18;
            score3 = 24;
        }
        else if (level < 36)
        {
            maxScore = 36;
            score1 = 24;
            score2 = 28;
            score3 = 36;
        }
        else
        {
            maxScore = 36;
            score1 = 28;
            score2 = 32;
            score3 = 38;
        }

        if ( (previousScore < score1) && (previousScore != 0) )
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[3];
            scoreImgs[1].texture = avatarImg[2];
            scoreImgs[2].texture = avatarImg[1];
            scoreImgs[3].texture = avatarImg[0];

            //cambiar el nombre
            scoreNames[0].text = "you   ";
            scoreNames[1].text = "apolo";
            scoreNames[2].text = "ravana";
            scoreNames[3].text = "marín";

            //cambiar el score
            scoreScores[0].text = previousScore + " (s.) ";
            scoreScores[1].text = score1 + " (s.) ";
            scoreScores[2].text = score2 + " (s.) ";
            scoreScores[3].text = score3 + " (s.) ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.grey;
            scoreEntry2.GetComponent<Image>().color = Color.white;
            scoreEntry3.GetComponent<Image>().color = Color.white;
            scoreEntry4.GetComponent<Image>().color = Color.white;

        }
        //si el jugador es el segundo
        else if ((previousScore < score2) && (previousScore != 0))
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[2];
            scoreImgs[1].texture = avatarImg[3];
            scoreImgs[2].texture = avatarImg[1];
            scoreImgs[3].texture = avatarImg[0];

            //cambiar el nombre
            scoreNames[0].text = "apolo";
            scoreNames[1].text = "you   ";
            scoreNames[2].text = "ravana";
            scoreNames[3].text = "marín";

            //cambiar el score
            scoreScores[0].text = score1 + " (s.) ";
            scoreScores[1].text = previousScore + " (s.) ";
            scoreScores[2].text = score2 + " (s.) ";
            scoreScores[3].text = score3 + " (s.) ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.white;
            scoreEntry2.GetComponent<Image>().color = Color.grey;
            scoreEntry3.GetComponent<Image>().color = Color.white;
            scoreEntry4.GetComponent<Image>().color = Color.white;
        }
        //si el jugador es el segundo
        else if ((previousScore < score3) && (previousScore != 0))
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[2];
            scoreImgs[1].texture = avatarImg[1];
            scoreImgs[2].texture = avatarImg[3];
            scoreImgs[3].texture = avatarImg[0];

            //cambiar el nombre
            scoreNames[0].text = "apolo";
            scoreNames[1].text = "ravana";
            scoreNames[2].text = "you   ";
            scoreNames[3].text = "marín";

            //cambiar el score
            scoreScores[0].text = score1 + " (s.) ";
            scoreScores[1].text = score2 + " (s.) ";
            scoreScores[2].text = previousScore + " (s.) ";
            scoreScores[3].text = score3 + " (s.) ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.white;
            scoreEntry2.GetComponent<Image>().color = Color.white;
            scoreEntry3.GetComponent<Image>().color = Color.grey;
            scoreEntry4.GetComponent<Image>().color = Color.white;
        }
        //si el jugador es el segundo
        else
        {
            //cambiar la imagen
            scoreImgs[0].texture = avatarImg[2];
            scoreImgs[1].texture = avatarImg[1];
            scoreImgs[2].texture = avatarImg[0];
            scoreImgs[3].texture = avatarImg[3];

            //cambiar el nombre
            scoreNames[0].text = "apolo";
            scoreNames[1].text = "ravana";
            scoreNames[2].text = "marín";
            scoreNames[3].text = "you   ";

            //cambiar el score
            scoreScores[0].text = score1 + " (s.) ";
            scoreScores[1].text = score2 + " (s.) ";
            scoreScores[2].text = score3 + " (s.) ";
            scoreScores[3].text = previousScore + " (s.) ";

            //ahora voy a colorear de azul el que seas tú
            scoreEntry1.GetComponent<Image>().color = Color.white;
            scoreEntry2.GetComponent<Image>().color = Color.white;
            scoreEntry3.GetComponent<Image>().color = Color.white;
            scoreEntry4.GetComponent<Image>().color = Color.grey;
        }
    }
}
