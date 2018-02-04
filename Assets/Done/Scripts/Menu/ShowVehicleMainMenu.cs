using UnityEngine;
using System.Collections;

public class ShowVehicleMainMenu : MonoBehaviour
{
    public GameObject vehicle1;
    public GameObject vehicle2;
    public GameObject vehicle3;
    public GameObject vehicle4;
    public GameObject vehicle5;
    public GameObject vehicle6;

    // Use this for initialization
    void Start () {

	    switch (PlayerData.playerData.vehicle)
        {
            case 0:
                vehicle1.SetActive(true);
                break;
            case 1:
                vehicle3.SetActive(true);
                break;
            case 2:
                vehicle2.SetActive(true);
                break;
            case 3:
                vehicle4.SetActive(true);
                break;
            case 4:
                vehicle6.SetActive(true);
                break;
            case 5:
                vehicle5.SetActive(true);
                break;
        }
	}
	
}
