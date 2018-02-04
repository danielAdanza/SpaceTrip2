using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeNumberStars : MonoBehaviour {

	public Text stars;
	
	// Update is called once per frame
	void Update () 
	{
		stars.text = "" + PlayerData.playerData.totalCoins;
	}
}
