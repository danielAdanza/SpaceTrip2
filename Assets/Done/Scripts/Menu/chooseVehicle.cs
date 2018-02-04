using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseVehicle : MonoBehaviour {

	public GameObject v0;
	public GameObject v1;
	public GameObject v2;
	public GameObject v3;
    public GameObject v4;
    public GameObject v5;

    public GameObject backgroundPop;
	public GameObject vehicleObject;

	public Text skin4;
	public Text skin5;
	public Text skin6;
    public Text skin7;
    public Text skin11;
    public Text skin12;
    public Text skin13;
    public Text skin14;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    public void Start ()
    {
        int texture = PlayerData.playerData.vehicleTexture;
        ChooseVehicle (PlayerData.playerData.vehicle);
        PlayerData.playerData.vehicleTexture = texture;
    }

	public void ChooseVehicle (int vehicle)
	{
        // loading the values for height thin and speed
        slider1.value = PlayerData.playerData.vehicleThin;
        slider2.value = PlayerData.playerData.vehicleHeight;
        slider3.value = PlayerData.playerData.speed * 0.2f;

        if (vehicle == 0) 
		{
			backgroundPop.SetActive (false);
			vehicleObject.SetActive (false);
			
			PlayerData.playerData.vehicle = vehicle;
			PlayerData.playerData.vehicleTexture = 0;

			v0.SetActive(true);

			if (PlayerData.playerData.purchaseSkeen[0]== 0)
			{skin4.text = "X";}
            else
            { skin4.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[1]== 0)
			{skin5.text = "X";}
            else
            { skin5.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[2]== 0)
			{skin6.text = "X";}
            else
            { skin6.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[3] == 0)
            { skin7.text = "X"; }
            else
            { skin7.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[4] == 0)
            { skin11.text = "X"; }
            else
            { skin11.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[5] == 0)
            { skin12.text = "X"; }
            else
            { skin12.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[6] == 0)
            { skin13.text = "X"; }
            else
            { skin13.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[7] == 0)
            { skin14.text = "X"; }
            else
            { skin14.text = ""; }
        } 
		else if(vehicle == 1) 
		{
			if (PlayerData.playerData.purchaseVehicle2 == 1)
			{
				backgroundPop.SetActive (false);
				vehicleObject.SetActive (false);
				
				PlayerData.playerData.vehicle = vehicle;
				PlayerData.playerData.vehicleTexture = 0;

				v1.SetActive(true);

                if (PlayerData.playerData.purchaseSkeen[8] == 0)
                { skin4.text = "X"; }
                else
                { skin4.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[9] == 0)
                { skin5.text = "X"; }
                else
                { skin5.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[10] == 0)
                { skin6.text = "X"; }
                else
                { skin6.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[11] == 0)
                { skin7.text = "X"; }
                else
                { skin7.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[12] == 0)
                { skin11.text = "X"; }
                else
                { skin11.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[13] == 0)
                { skin12.text = "X"; }
                else
                { skin12.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[14] == 0)
                { skin13.text = "X"; }
                else
                { skin13.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[15] == 0)
                { skin14.text = "X"; }
                else
                { skin14.text = ""; }
            }
		} 
		else if(vehicle == 2) 
		{
			if (PlayerData.playerData.purchaseVehicle3 == 1)
			{
				backgroundPop.SetActive (false);
				vehicleObject.SetActive (false);
				
				PlayerData.playerData.vehicle = vehicle;
				PlayerData.playerData.vehicleTexture = 0;

				v2.SetActive(true);

                if (PlayerData.playerData.purchaseSkeen[16] == 0)
                { skin4.text = "X"; }
                else
                { skin4.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[17] == 0)
                { skin5.text = "X"; }
                else
                { skin5.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[18] == 0)
                { skin6.text = "X"; }
                else
                { skin6.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[19] == 0)
                { skin7.text = "X"; }
                else
                { skin7.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[20] == 0)
                { skin11.text = "X"; }
                else
                { skin11.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[21] == 0)
                { skin12.text = "X"; }
                else
                { skin12.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[22] == 0)
                { skin13.text = "X"; }
                else
                { skin13.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[23] == 0)
                { skin14.text = "X"; }
                else
                { skin14.text = ""; }
            }
		}
		else if (vehicle == 3) 
		{
			backgroundPop.SetActive (false);
			vehicleObject.SetActive (false);
			
			PlayerData.playerData.vehicle = vehicle;
			PlayerData.playerData.vehicleTexture = 0;

            if (PlayerData.playerData.purchaseSkeen[24] == 0)
            { skin4.text = "X"; }
            else
            { skin4.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[25] == 0)
            { skin5.text = "X"; }
            else
            { skin5.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[26] == 0)
            { skin6.text = "X"; }
            else
            { skin6.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[27] == 0)
            { skin7.text = "X"; }
            else
            { skin7.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[28] == 0)
            { skin11.text = "X"; }
            else
            { skin11.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[29] == 0)
            { skin12.text = "X"; }
            else
            { skin12.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[30] == 0)
            { skin13.text = "X"; }
            else
            { skin13.text = ""; }

            if (PlayerData.playerData.purchaseSkeen[31] == 0)
            { skin14.text = "X"; }
            else
            { skin14.text = ""; }

            v3.SetActive(true);
		}
        else if (vehicle == 4)
        {
            if (PlayerData.playerData.purchaseVehicle4 == 1)
            {
                backgroundPop.SetActive(false);
                vehicleObject.SetActive(false);

                PlayerData.playerData.vehicle = vehicle;
                PlayerData.playerData.vehicleTexture = 0;

                if (PlayerData.playerData.purchaseSkeen[32] == 0)
                { skin4.text = "X"; }
                else
                { skin4.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[33] == 0)
                { skin5.text = "X"; }
                else
                { skin5.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[34] == 0)
                { skin6.text = "X"; }
                else
                { skin6.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[35] == 0)
                { skin7.text = "X"; }
                else
                { skin7.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[36] == 0)
                { skin11.text = "X"; }
                else
                { skin11.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[37] == 0)
                { skin12.text = "X"; }
                else
                { skin12.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[38] == 0)
                { skin13.text = "X"; }
                else
                { skin13.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[39] == 0)
                { skin14.text = "X"; }
                else
                { skin14.text = ""; }

                v4.SetActive(true);
            }

            
        }
        else if (vehicle == 5)
        {
            if (PlayerData.playerData.purchaseVehicle5 == 1)
            {
                backgroundPop.SetActive(false);
                vehicleObject.SetActive(false);

                PlayerData.playerData.vehicle = vehicle;
                PlayerData.playerData.vehicleTexture = 0;

                if (PlayerData.playerData.purchaseSkeen[40] == 0)
                { skin4.text = "X"; }
                else
                { skin4.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[41] == 0)
                { skin5.text = "X"; }
                else
                { skin5.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[42] == 0)
                { skin6.text = "X"; }
                else
                { skin6.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[43] == 0)
                { skin7.text = "X"; }
                else
                { skin7.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[44] == 0)
                { skin11.text = "X"; }
                else
                { skin11.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[45] == 0)
                { skin12.text = "X"; }
                else
                { skin12.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[46] == 0)
                { skin13.text = "X"; }
                else
                { skin13.text = ""; }

                if (PlayerData.playerData.purchaseSkeen[47] == 0)
                { skin14.text = "X"; }
                else
                { skin14.text = ""; }

                v5.SetActive(true);
            }

            
        }
    }

	public void changeVehicle ()
	{
		v0.SetActive(false);
		v1.SetActive(false);
		v2.SetActive(false);
		v3.SetActive(false);
        v4.SetActive(false);
        v5.SetActive(false);

        backgroundPop.SetActive (true);
		vehicleObject.SetActive (true);
	}

	public void backFunction ()
	{
		PlayerData.playerData.Save ();
        SceneManager.LoadScene(1);
	}
}
