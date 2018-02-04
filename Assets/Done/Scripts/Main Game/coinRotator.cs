using UnityEngine;
using System.Collections;

public class coinRotator : MonoBehaviour
{
    private Done_GameController gameController;
    public float speedRotator;
    public float speedMovement;

    public int coinValue;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speedRotator);
            transform.position -= new Vector3(0, 0, speedMovement);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameController.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
