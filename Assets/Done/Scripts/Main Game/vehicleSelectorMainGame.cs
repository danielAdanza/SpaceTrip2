using UnityEngine;
using System.Collections;

public class vehicleSelectorMainGame : MonoBehaviour {

	public GameObject vehicle1;
	public GameObject vehicle2;
	public GameObject vehicle3;
	public GameObject vehicle4;
    public GameObject vehicle5;
    public GameObject vehicle6;

    void Start () 
	{

		if (PlayerData.playerData.vehicle == 0)
        {
			Destroy(vehicle2);
			Destroy(vehicle3);
			Destroy(vehicle4);
            Destroy(vehicle5);
            Destroy(vehicle6);
            vehicle1.SetActive (true);
			vehicle1.transform.localScale = new Vector3 (0.7f + (PlayerData.playerData.vehicleThin / 2), (PlayerData.playerData.vehicleHeight/2) + 1f, 1.5f - (PlayerData.playerData.vehicleThin/2) );
		}
        else if (PlayerData.playerData.vehicle == 1)
        {
			Destroy(vehicle1);
			Destroy(vehicle2);
            Destroy(vehicle4);
            Destroy(vehicle5);
            Destroy(vehicle6); ;
			vehicle3.SetActive (true);
			vehicle3.transform.localScale = new Vector3 (0.75f + (PlayerData.playerData.vehicleThin / 2), (PlayerData.playerData.vehicleHeight/2) + 0.75f, 1f - (PlayerData.playerData.vehicleThin/2) );

		}
        else if (PlayerData.playerData.vehicle == 2)
        {
			Destroy(vehicle1);
			Destroy(vehicle3);
			Destroy(vehicle4);
            Destroy(vehicle5);
            Destroy(vehicle6);
            vehicle2.SetActive (true);
			vehicle2.transform.localScale = new Vector3 (0.5f + (PlayerData.playerData.vehicleThin / 2), (PlayerData.playerData.vehicleHeight/2) + 0.5f, 1f - (PlayerData.playerData.vehicleThin/2) );
		}
        else if (PlayerData.playerData.vehicle == 3)
        {
			Destroy(vehicle1);
			Destroy(vehicle2);
			Destroy(vehicle3);
            Destroy(vehicle5);
            Destroy(vehicle6);
            vehicle4.SetActive (true);
			vehicle4.transform.localScale = new Vector3 (9f + (PlayerData.playerData.vehicleThin * 6), (PlayerData.playerData.vehicleHeight * 6) + 9f, 15f - (PlayerData.playerData.vehicleThin * 6) );
		}
        else if (PlayerData.playerData.vehicle == 4)
        {
            Destroy(vehicle1);
            Destroy(vehicle2);
            Destroy(vehicle3);
            Destroy(vehicle4);
            Destroy(vehicle6);
            vehicle5.SetActive(true);
            vehicle5.transform.localScale = new Vector3(0.2f + (PlayerData.playerData.vehicleThin * 0.2f), (PlayerData.playerData.vehicleHeight * 0.2f) + 0.2f, 0.4f - (PlayerData.playerData.vehicleThin * 0.2f));
        }
        else if (PlayerData.playerData.vehicle == 5)
        {
            Destroy(vehicle1);
            Destroy(vehicle2);
            Destroy(vehicle3);
            Destroy(vehicle4);
            Destroy(vehicle5);
            vehicle6.SetActive(true);
            vehicle6.transform.localScale = new Vector3(0.3f + (PlayerData.playerData.vehicleThin * 0.2f), (PlayerData.playerData.vehicleHeight * 0.2f) + 0.3f, 0.5f - (PlayerData.playerData.vehicleThin * 0.2f));
        }

    }

}
