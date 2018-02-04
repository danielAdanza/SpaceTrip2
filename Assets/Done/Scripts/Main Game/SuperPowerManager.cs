using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuperPowerManager : MonoBehaviour {

    //shooting rain object
    public GameObject ShootingRain;
    //buttons for the super abilities
    public GameObject buttonSP1;
    public GameObject buttonSP2;
    //text which express the number of super abilities left
    public Text textSP1;
    public Text textSP2;
    //the sferes of the different vehicles
    public GameObject[] vehicles;
    float time = 0f;


    void Start ()
    {
        DesactivateButtons();

        if (PlayerPrefs.GetInt("SP1") == 1)
        {
            PlayerPrefs.SetInt("SP1", 0);
        }
    }

    //SP1 = 0; then disactivated
    //SP1 = 1; activated
    public void SuperPower1Activated ()
    {
        PlayerPrefs.SetInt("SP1",1);

        int i = PlayerData.playerData.vehicle;

        switch (i)
        {
            case 0:
                i = 0;
                break;
            case 1:
                i = 2;
                break;
            case 2:
                i = 1;
                break;
            case 3:
                i = 3;
                break;
            case 4:
                i = 5;
                break;
            case 5:
                i = 4;
                break;
        }

        Instantiate(ShootingRain, vehicles[i].transform.position, ShootingRain.transform.rotation);
        PlayerData.playerData.superPower1 = PlayerData.playerData.superPower1 - 1;

        buttonSP1.SetActive(false);

        time = Time.time + 3.0f;
    }

    //SP2 = 0; then disactivated
    //SP2 = 1; activated

    //vehicle variable values
    //v = 0 => vehicle 0
    //v = 1 => vehicle 2
    //v = 2 => vehicle 1
    //v = 3 => vehicle 3
    //v = 4 => vehicle 4
    //v = 5 => vehicle 5
    public void SuperPower2Activated()
    {
        PlayerData.playerData.superPower2 = PlayerData.playerData.superPower2 - 1;

        int i = PlayerData.playerData.vehicle;

        switch (i)
        {
            case 0:
                vehicles[0].SetActive(true);
                break;
            case 1:
                vehicles[2].SetActive(true);
                break;
            case 2:
                vehicles[1].SetActive(true);
                break;
            case 3:
                vehicles[3].SetActive(true);
                break;
            case 4:
                vehicles[5].SetActive(true);
                break;
            case 5:
                vehicles[4].SetActive(true);
                break;
        }

        buttonSP2.SetActive(false);
    }

    public void DesactivateButtons ()
    {
        if (PlayerData.playerData.superPower1 == 0)
        { buttonSP1.SetActive(false); }
        else
        { textSP1.text = PlayerData.playerData.superPower1 + ""; }

        if (PlayerData.playerData.superPower2 == 0)
        { buttonSP2.SetActive(false); }
        else
        { textSP2.text = PlayerData.playerData.superPower2 + ""; }
    }
}
