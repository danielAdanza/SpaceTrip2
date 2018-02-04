using UnityEngine;
using System.Collections;

public class model : MonoBehaviour {

	// Use this for initialization
	public float turnSpeed = 50f;

	void Start () 
	{
	}

	void Update ()
	{
        if (PlayerData.playerData.vehicle == 5)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }

	}
}
