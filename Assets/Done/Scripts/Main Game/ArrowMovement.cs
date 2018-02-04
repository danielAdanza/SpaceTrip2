using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArrowMovement : MonoBehaviour {

    private string orientation = "";
    public float speedRotator;
    private float x = 0f, z = 0f;
    public GameObject UIinfo;

    // Use this for initialization
    void Start ()
    {
        int position = Random.Range(0,2);

        Destroy(gameObject, 5);

        float xPosition = Random.Range(5.6f,6.6f);
        float yPosition = Random.Range(-1.0f, 1.0f);

        if (position == 0)
        {

            orientation = "left";
            GetComponent<Rigidbody>().position = new Vector3(-xPosition,yPosition,5f);        
        }
        else
        {
            orientation = "right";
            GetComponent<Rigidbody>().position = new Vector3(xPosition, yPosition, 5f);
        }
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speedRotator);

            if (transform.position.z > -5f)
                z = -0.028f;

            if ((orientation == "left") && (transform.position.x < 6.5f))
                x = 0.022f;

            if ((orientation == "right") && (transform.position.x > -6.5f))
                x = -0.022f;

            GetComponent<Transform>().position += new Vector3(x, 0.0f, z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.GetInt("BoltLevel") < 4)
            {
                PlayerPrefs.SetInt("BoltLevel", PlayerPrefs.GetInt("BoltLevel") + 1);

                string message = "";
                switch (PlayerData.playerData.languaje)
                {
                    case 1:
                        message = "weapon level: "+ PlayerPrefs.GetInt("BoltLevel");
                        break;
                    case 2:
                        message = "arma nivel: " + PlayerPrefs.GetInt("BoltLevel");
                        break;
                    case 3:
                        message = "stopnja orožje: " + PlayerPrefs.GetInt("BoltLevel");
                        break;
                    case 4:
                        message = "niveau d'arme: " + PlayerPrefs.GetInt("BoltLevel");
                        break;
                    case 5:
                        message = "nível de arma: " + PlayerPrefs.GetInt("BoltLevel");
                        break;
                }

                UIinfo.GetComponent<TextMesh>().text = message;
                Instantiate(UIinfo);
                Destroy(gameObject);
            }
        }
    }

}
