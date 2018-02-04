using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vehicleEditorSpecialEmi : MonoBehaviour {

	public GameObject vehicleSkin;
	public Slider slider1;
	public Slider slider2;
	public Slider slider3;

    public Color32 color;

	// Update is called once per frame
	void Update () 
	{
       color = new Color32(255, 255, 255, 1);
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

        vehicleSkin.GetComponent<Renderer> ().material.color = color;
		vehicleSkin.transform.localScale = new Vector3 (100.0f + (slider2.value * 50.0f), (slider1.value* 50.0f) + 100.0f, 150.0f - (slider2.value * 50.0f));
	}
}
