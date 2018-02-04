using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour 
{

	public void WhenMainMenuIsClicked ()
	{
		Time.timeScale = 1;
        SceneManager.LoadScene(1);
	}

	public void WhenRestartIsClicked ()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
