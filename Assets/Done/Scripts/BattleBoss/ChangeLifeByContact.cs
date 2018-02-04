using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeLifeByContact : MonoBehaviour 
{
	public Slider sliderEnemy;
	public GameObject playerExplosion;

	void OnTriggerEnter (Collider other)
	{
		Destroy (other.gameObject);
		float value = 0.0f;
		if (PlayerPrefs.GetInt ("battle") == 1 || PlayerPrefs.GetInt ("battle") == 2) {
			value = 0.05f;
		} else if (PlayerPrefs.GetInt ("battle") == 3 || PlayerPrefs.GetInt ("battle") == 4) {
			value = 0.04f;
		} else {
			value = 0.033f;
		}
		if (sliderEnemy.value > 0) 
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			sliderEnemy.value = sliderEnemy.value - value;
		} 
	}

}
