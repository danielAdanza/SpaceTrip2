using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    public GameObject[] buttonAchievements;
    public Texture completedTexture;
    public RawImage[] texturesAchievements;
    public Text coinsText;
    public Text numberText;

    public void WhenAchievementsIsClicked ()
    {
        ActualizeAchievements();
        CompletedAchievements();

        //actualizando el numero de monedas
        coinsText.text = PlayerData.playerData.totalCoins + "";
    }

    public void WhenGiveRewardsIsClicked (int achievementPosition)
    {

        int coinsRewarded = 0;
        switch (achievementPosition)
        {
            case 0:
                coinsRewarded = 10;
                break;
            case 1:
                coinsRewarded = 20;
                break;
            case 2:
                coinsRewarded = 30;
                break;
            case 3:
                coinsRewarded = 40;
                break;
            case 4:
                coinsRewarded = 15;
                break;
            case 5:
                coinsRewarded = 30;
                break;
            case 6:
                coinsRewarded = 45;
                break;
            case 7:
                coinsRewarded = 25;
                break;
            case 8:
                coinsRewarded = 50;
                break;
            case 9:
                coinsRewarded = 75;
                break;
        }

        //actualizar en playerData
        PlayerData.playerData.achievementsState[achievementPosition] = 2;
        PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins + coinsRewarded;
        PlayerData.playerData.Save();

        //ocultar el botón correspondiente
        buttonAchievements[achievementPosition].SetActive(false);

        //actualizando el numero de monedas
        coinsText.text = PlayerData.playerData.totalCoins + "";
    }

    //[0] ... [3] Unlock world 1 ... 4
    //[4] ... [6] play 50,100,200 times
    //[7] ... [9] win 20,50,100 times

    //ACHIEVEMENT STATES
    //0 = LOCKED
    //1 = UNLOCKED BUT NOW REWARDED
    //2 = UNLOCKED AND REWARDED

    void ActualizeAchievements ()
    {
        

        //Logros se desbloquear mundos
        if ((PlayerData.playerData.currentlevel >= 1) && (PlayerData.playerData.achievementsState[0] == 0) )
        {
            PlayerData.playerData.achievementsState[0] = 1;
            buttonAchievements[0].SetActive(true);
        }

        if ((PlayerData.playerData.currentlevel >= 12) && (PlayerData.playerData.achievementsState[1] == 0))
        {
            PlayerData.playerData.achievementsState[1] = 1;
            buttonAchievements[1].SetActive(true);
        }

        if ((PlayerData.playerData.currentlevel >= 23) && (PlayerData.playerData.achievementsState[2] == 0))
        {
            PlayerData.playerData.achievementsState[2] = 1;
            buttonAchievements[2].SetActive(true);
        }

        if ((PlayerData.playerData.currentlevel >= 37) && (PlayerData.playerData.achievementsState[3] == 0))
        {
            PlayerData.playerData.achievementsState[3] = 1;
            buttonAchievements[3].SetActive(true);
        }

        //Logros de jugar un determinado número de partidas
        if ((PlayerData.playerData.totalmatches >= 50) && (PlayerData.playerData.achievementsState[4] == 0))
        {
            PlayerData.playerData.achievementsState[4] = 1;
            buttonAchievements[4].SetActive(true);
        }

        if ((PlayerData.playerData.totalmatches >= 100) && (PlayerData.playerData.achievementsState[5] == 0))
        {
            PlayerData.playerData.achievementsState[5] = 1;
            buttonAchievements[5].SetActive(true);
        }

        if ((PlayerData.playerData.totalmatches >= 200) && (PlayerData.playerData.achievementsState[6] == 0))
        {
            PlayerData.playerData.achievementsState[6] = 1;
            buttonAchievements[6].SetActive(true);
        }

        //Logros sobre número de victorias
        if ((PlayerData.playerData.totalvictories >= 20) && (PlayerData.playerData.achievementsState[7] == 0))
        {
            PlayerData.playerData.achievementsState[7] = 1;
            buttonAchievements[7].SetActive(true);
        }

        if ((PlayerData.playerData.totalvictories >= 50) && (PlayerData.playerData.achievementsState[8] == 0))
        {
            PlayerData.playerData.achievementsState[8] = 1;
            buttonAchievements[8].SetActive(true);
        }

        if ((PlayerData.playerData.totalvictories >= 100) && (PlayerData.playerData.achievementsState[9] == 0))
        {
            PlayerData.playerData.achievementsState[9] = 1;
            buttonAchievements[9].SetActive(true);
        }

        PlayerData.playerData.Save();

       // CompletedAchievements();
    }

    void CompletedAchievements ()
    {
        int completed = 0;

        for (int i = 0; i < PlayerData.playerData.achievementsState.Length; i++)
        {
            if (PlayerData.playerData.achievementsState[i] >= 1)
            {
                completed++;
                texturesAchievements[i].color = Color.white;
                texturesAchievements[i].texture = completedTexture;
            }
        }

        numberText.text = completed + " / 10";
    }
}
