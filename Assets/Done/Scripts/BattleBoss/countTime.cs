using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countTime : MonoBehaviour {

	public Text textTime;
	private int elapsedTime;

	void Start () {
		elapsedTime = (int)Time.time;
	}
	// Update is called once per frame
	void Update () {
		int segundos = (int)Time.time - elapsedTime;
		segundos = 3 - segundos;
		textTime.text = "" + segundos;
	}
}
