using UnityEngine;
using System.Collections;

public class BuyVehicles : MonoBehaviour 
{
	public GameObject buttonBuy1;
	public GameObject buttonBuy2;
    public GameObject buttonBuy3;
    public GameObject buttonBuy4;

    // Use this for initialization
    void Start () 
	{
		if (PlayerData.playerData.purchaseVehicle2 == 1) 
		{
			buttonBuy1.SetActive(false);
		}

		if (PlayerData.playerData.purchaseVehicle3 == 1) 
		{
			buttonBuy2.SetActive(false);
		}

        if (PlayerData.playerData.purchaseVehicle4 == 1)
        {
            buttonBuy3.SetActive(false);
        }

        if (PlayerData.playerData.purchaseVehicle5 == 1)
        {
            buttonBuy4.SetActive(false);
        }
    }

	public void BuyVehicle2 ()
	{
		if (PlayerData.playerData.totalCoins >= 800)
		{
			PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins - 800;
			PlayerData.playerData.purchaseVehicle2 = 1;
			PlayerData.playerData.Save ();
			buttonBuy1.SetActive(false);
		}
	}

	public void BuyVehicle3 ()
	{
		if (PlayerData.playerData.totalCoins >= 1000)
		{
			PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins - 1000;
			PlayerData.playerData.purchaseVehicle3 = 1;
			PlayerData.playerData.Save ();
			buttonBuy2.SetActive(false);
		}
	}

    public void BuyVehicle4()
    {
        if (PlayerData.playerData.totalCoins >= 1200)
        {
            PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins - 1200;
            PlayerData.playerData.purchaseVehicle4 = 1;
            PlayerData.playerData.Save();
            buttonBuy3.SetActive(false);
        }
    }

    public void BuyVehicle5()
    {
        if (PlayerData.playerData.totalCoins >= 1400)
        {
            PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins - 1400;
            PlayerData.playerData.purchaseVehicle5 = 1;
            PlayerData.playerData.Save();
            buttonBuy4.SetActive(false);
        }
    }
}
