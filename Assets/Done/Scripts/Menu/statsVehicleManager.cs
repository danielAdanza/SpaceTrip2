using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class statsVehicleManager : MonoBehaviour
{
    //GameObjects for closing the popup
    public GameObject vehiclePopup;
    public GameObject statsPopup;
    public GameObject purchasesPopup;

    //stats vehicles
    public Texture[] vehicleImages;
    public RawImage imgVehicle;

    //sliders Stats
    public Slider sliderBolt;
    public Slider sliderSpeed;
    public Slider sliderShape;

    public Canvas canvas;

    public void WhenCloseIsClicked ()
    {
        vehiclePopup.SetActive(false);
        statsPopup.SetActive(false);
        purchasesPopup.SetActive(false);

        canvas.GetComponent<chooseVehicle>().ChooseVehicle(PlayerData.playerData.vehicle);
    }

    public void WhenStatsIsClicked (int vehicleSelected)
    {
        statsPopup.SetActive(true);
        int vehicleStats;
        if (vehicleSelected == -1)
        { vehicleStats = PlayerData.playerData.vehicle; }
        else
        { vehicleStats = vehicleSelected; }
        

        imgVehicle.texture = vehicleImages[vehicleStats];

        switch (vehicleStats)
        {
            case 0:
                sliderBolt.value = 0.6f;
                sliderSpeed.value = 0.8f;
                sliderShape.value = 0.33f;
                break;
            case 1:
                sliderBolt.value = 1.0f;
                sliderSpeed.value = 0.95f;
                sliderShape.value = 0.33f;
                break;
            case 2:
                sliderBolt.value = 0.4f;
                sliderSpeed.value = 0.8f;
                sliderShape.value = 0.72f;
                break;
            case 3:
                sliderBolt.value = 0.6f;
                sliderSpeed.value = 0.80f;
                sliderShape.value = 0.72f;
                break;
            case 4:
                sliderBolt.value = 0.6f;
                sliderSpeed.value = 0.65f;
                sliderShape.value = 0.66f;
                break;
            case 5:
                sliderBolt.value = 1.0f;
                sliderSpeed.value = 0.95f;
                sliderShape.value = 0.33f;
                break;
        }
    }
}
