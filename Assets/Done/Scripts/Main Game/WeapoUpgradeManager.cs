using UnityEngine;
using System.Collections;

public class WeapoUpgradeManager : MonoBehaviour {

    private int seg;
    public GameObject arrow;
    //in order to spawn only one arrow
    private int arrowsMax = 4;

    int randomNumber1 = 0, randomNumber2 = 0, randomNumber3 = 0, randomNumber4 = 0;
    // Use this for initialization
    void Start () {
        randomNumber1 = Random.Range(2, 10);
        randomNumber2 = Random.Range(13, 20);
        randomNumber3 = Random.Range(23, 30);
        randomNumber4 = Random.Range(33, 45);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time != 0)
        {
            seg = (int)Time.timeSinceLevelLoad;

            if ((seg == randomNumber1) && arrowsMax == 4)
            {
                Instantiate(arrow);
                arrowsMax--;
            }
            else if ((seg == randomNumber2) && arrowsMax == 3)
            {
                Instantiate(arrow);
                arrowsMax--;
            }
            else if ((seg == randomNumber3) && arrowsMax == 2)
            {
                Instantiate(arrow);
                arrowsMax--;
            }
            else if ((seg == randomNumber4) && arrowsMax == 1)
            {
                Instantiate(arrow);
                arrowsMax--;
            }
        }
        
    }
}
