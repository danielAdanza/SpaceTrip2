using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VehicleEditor : MonoBehaviour
{

	public GameObject vehicle;
	public Slider slider1;
	public Slider slider2;
	public Slider slider3;

	public GameObject purchasePopup;
	public GameObject objectVehicleInpurchase;
	public GameObject vehiclePopup;

	//purchasepopup stuffs
	public GameObject v1;
	public GameObject v2;
	public GameObject v3;

    public Canvas canvas;
    public GameObject warningText;

    void Update () 
	{
        //0 WHITE => (255, 255, 255, 1)                 //6 DARK GREEN => (55, 119, 28, 1)
        //1 NEGRO => (47, 47, 47, 1)                    //7 ORANGE => (255, 194, 70, 1)
        //2 GREEN => (151, 255, 168,1)                  //8 PINK => (255, 154, 239, 1)
        //3 RED => (252, 101, 101, 1)                   //9 dark BROWN => (102, 60, 3, 1)
        //4 light BLUE => (129, 188, 255, 1)            //10 PURPLE => (114, 72, 161, 1)
        //5 GREY => (94, 94, 94, 1)                     //11 YELLOW => (246, 255, 111, 1)

        //12 dark BLUE => (87, 121, 255, 1)             //13 dark RED => (153, 0, 0, 1)

        Color32 color = new Color32(255, 255, 255, 1);
        switch (PlayerData.playerData.vehicleTexture)
        {
            case 1:
                color = new Color32(47, 47, 47, 1);
                break;
            case 2:
                color = new Color32(151, 255, 168, 1);
                break;
            case 3:
                color = new Color32(252, 101, 101, 1);
                break;
            case 4:
                color = new Color32(129, 188, 255, 1);
                break;
            case 5:
                color = new Color32(94, 94, 94, 1);
                break;
            case 6:
                color = new Color32(55, 119, 28, 1);
                break;
            case 7:
                color = new Color32(255, 194, 70, 1);
                break;
            case 8:
                color = new Color32(255, 154, 239, 1);
                break;
            case 9:
                color = new Color32(102, 60, 3, 1);
                break;
            case 10:
                color = new Color32(114, 72, 161, 1);
                break;
            case 11:
                color = new Color32(246, 255, 111, 1);
                break;
            case 12:
                color = new Color32(87, 121, 255, 1);
                break;
            case 13:
                color = new Color32(153, 0, 0, 1);
                break;
        }

        if (PlayerData.playerData.vehicle == 0) {
            vehicle.GetComponent<Renderer>().material.color = color;
            vehicle.transform.localScale = new Vector3(0.7f + slider2.value, slider1.value + 1.5f, 3.1f - slider2.value);
        } else if (PlayerData.playerData.vehicle == 1) {
			//in an special script
		} else if (PlayerData.playerData.vehicle == 2) {
            vehicle.GetComponent<Renderer>().material.color = color;
            transform.localScale = new Vector3 (1f + slider2.value, slider1.value + 1f, 2f - slider2.value);
		}
		else if (PlayerData.playerData.vehicle == 3) {
            vehicle.GetComponent<Renderer>().material.color = color;
            transform.localScale = new Vector3 (15f + (slider2.value * 10), (slider1.value * 10) + 15f, 25f - (slider2.value * 10));
		}
        else if (PlayerData.playerData.vehicle == 4)
        {
            vehicle.GetComponent<Renderer>().material.color = color;
            transform.localScale = new Vector3(0.4f + (slider2.value * 0.2f), (slider1.value * 0.2f) + 0.4f, 0.6f - (slider2.value * 0.2f));
        }
        else if (PlayerData.playerData.vehicle == 5)
        {
            vehicle.GetComponent<Renderer>().material.color = color;
            transform.localScale = new Vector3(0.5f + (slider2.value * 0.2f), (slider1.value * 0.2f) + 0.5f, 0.7f - (slider2.value * 0.2f));
        }
    }

    public void ChangeVehicleSkeen (int num)
	{
        int num2 = num;
        int i = PlayerData.playerData.vehicle * 8;
        if (num < 7)
        { num2 = num2 - 3; }
        else
        { num2 = num2 - 6; }
        i = i + num2;

        if ( (num == 0) || (num == 1) || (num == 2) || (num == 7) || (num == 8) || (num == 9))
        {
            PlayerData.playerData.vehicleTexture = num;
        }
        else if (PlayerData.playerData.purchaseSkeen[i] == 1)
        {
            PlayerData.playerData.vehicleTexture = num;
        }
        else
        {
            PlayerPrefs.SetInt("purchaseSkeen", i);
            PlayerPrefs.SetInt("Skeen", num);
            purchasePopup.SetActive(true);
        }
    }

	public void ChangeShape ()
	{ 
		if (PlayerData.playerData.vehicle == 0) 
		{
			vehicle.transform.localScale = new Vector3 (0.7f + slider2.value, slider1.value + 1.5f, 3.1f - slider2.value);
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		} 
		else if (PlayerData.playerData.vehicle == 1) 
		{
			vehicle.transform.localScale = new Vector3 (2.5f + (slider2.value), (slider1.value) + 2.5f, 3.5f - (slider2.value) );
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		}
		else if (PlayerData.playerData.vehicle == 2) 
		{
			vehicle.transform.localScale = new Vector3 (1.5f + slider2.value, slider1.value + 1.5f, 2.5f - slider2.value);
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		}
		else if (PlayerData.playerData.vehicle == 3) 
		{
			vehicle.transform.localScale = new Vector3 (15f + (slider2.value * 10), (slider1.value * 10) + 15f, 25f - (slider2.value * 10));
			PlayerData.playerData.vehicleThin = slider2.value;
			PlayerData.playerData.vehicleHeight = slider1.value;
		}
        else if (PlayerData.playerData.vehicle == 4)
        {
            vehicle.transform.localScale = new Vector3(0.4f + (slider2.value * 0.2f), (slider1.value * 0.2f) + 0.4f, 0.6f - (slider2.value * 0.2f));
            PlayerData.playerData.vehicleThin = slider2.value;
            PlayerData.playerData.vehicleHeight = slider1.value;
        }
        else if (PlayerData.playerData.vehicle == 5)
        {
            vehicle.transform.localScale = new Vector3(0.5f + (slider2.value * 0.2f), (slider1.value * 0.2f) + 0.5f, 0.7f - (slider2.value * 0.2f));
            PlayerData.playerData.vehicleThin = slider2.value;
            PlayerData.playerData.vehicleHeight = slider1.value;
        }
    }

	public void changePlusVelocity ()
	{
		if (PlayerData.playerData.speed < 5) 
		{
			PlayerData.playerData.speed = PlayerData.playerData.speed + 1;
			slider3.value = slider3.value + 0.2f;
		}
	}

	public void changeMinusVelocity ()
	{
		if (PlayerData.playerData.speed > 0) 
		{
			PlayerData.playerData.speed = PlayerData.playerData.speed - 1;
			slider3.value = slider3.value - 0.2f;
		}
	}

	public void noclicked ()
	{
        warningText.SetActive(false);
        purchasePopup.SetActive (false);
	}

	public void yesclicked ()
	{
		if (PlayerData.playerData.totalCoins > 50) 
		{
			PlayerData.playerData.purchaseSkeen[PlayerPrefs.GetInt("purchaseSkeen")] = 1;
			PlayerData.playerData.totalCoins = PlayerData.playerData.totalCoins - 50;

            canvas.GetComponent<chooseVehicle>().ChooseVehicle(PlayerData.playerData.vehicle);
            PlayerData.playerData.vehicleTexture = PlayerPrefs.GetInt("Skeen");

            purchasePopup.SetActive(false);
            PlayerData.playerData.Save();
		}
        else
        {
            warningText.SetActive(true);
        }
	}

}
