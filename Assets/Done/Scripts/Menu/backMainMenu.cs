using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backMainMenu : MonoBehaviour {

	public void WhenBackIsClicked ()
	{
        SceneManager.LoadScene("MainMenu");
	}

    public void WhenChangeVehicleIsClicked()
    {
        SceneManager.LoadScene("VehicleSelection");
    }
}
