using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LooseLife : MonoBehaviour {

	public GameObject playerExplosion;
	public Slider sliderPlayer;

	void OnTriggerEnter (Collider other)
	{
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
            if (sliderPlayer.value > 0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                sliderPlayer.value = sliderPlayer.value - 0.25f;
            }
        }
	}
}
