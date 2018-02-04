using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public GameObject coin;
    public GameObject scoreText;
	public int scoreValue;
	private Done_GameController gameController;
    public int lifes;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

    void Update ()
    {
        if (PlayerPrefs.GetInt("SP1") == 1)
        {
            if (gameObject.tag == "Enemy")
            {
                AsteroidDestroid();
            }
        }
    }

	void OnTriggerEnter (Collider other)
	{
        if( (other.tag != "Coin") && (other.tag != "BoltUp") )
        {
            if (other.tag == "shoot")
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (other.tag == "Boundary" || other.tag == "Enemy")
            {
                return;
            }

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }

            if (gameController != null)
            {
                Destroy(other.gameObject);

                //si el asteroide no queda destruído simplemente quitarle una vida
                if (lifes > 0 )
                {
                    if (other.name == "Sphere")
                    {
                        AsteroidDestroid();
                    }
                    else
                    {
                        lifes--;
                    }
                        
                }
                //de no ser así ...
                else
                {
                    AsteroidDestroid();
                }

            }
        }
		
	}

    void AsteroidDestroid ()
    {
        //crear la moneda, añadir el score y mostrarlo por pantalla
        Instantiate(coin, transform.position, transform.rotation);
        scoreText.GetComponent<TextMesh>().text = "+" + scoreValue;
        Instantiate(scoreText, transform.position, scoreText.transform.rotation);

        if (gameController.missionLevel == false)
        {
            gameController.AddScore(scoreValue);
        }
        else
        {
            gameController.AddScoreMision();
        }

        Destroy(gameObject);
    }
}