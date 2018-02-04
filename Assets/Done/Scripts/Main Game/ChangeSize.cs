using UnityEngine;
using System.Collections;

public class ChangeSize : MonoBehaviour {

    public int mode;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<Transform>().localScale.x < 3 && mode == 0)
        {
            GetComponent<Transform>().localScale += new Vector3(0.03f, 0.03f, 0.03f);
        }

        if (GetComponent<Transform>().localScale.x > 1.2 && mode == 1)
        {
            GetComponent<Transform>().localScale += new Vector3(-0.01f, -0.01f, -0.01f);
        }

    }
}
