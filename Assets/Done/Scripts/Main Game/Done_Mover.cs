using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
    //this int will express the movement mode being in the following way
    //mode 0: move only down
    //mode 1: making waves
    //mode 2: random movement
    public int mode;
    private double xPosition;
    private float velocity = 0.025f;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
        xPosition = GetComponent<Transform>().position.x;
	}

    void Update ()
    {
        if (Time.timeScale != 0)
        {
            //si quieres que ondule
            if (mode == 1)
            {
                //Si sobrepasa el límite de la izquierda se multiplica por menos uno
                if (xPosition - 1.0f >= GetComponent<Transform>().position.x)
                {
                    velocity = velocity * -1f;
                }

                //Si sobrepasa el límite de la derecha también
                if (xPosition + 1.0f <= GetComponent<Transform>().position.x)
                {
                    velocity = velocity * -1f;
                }

                //por otra parte hay que ir moviendo el asteroide en la dirección correcta
                GetComponent<Transform>().position += new Vector3(velocity, 0.0f, 0.0f);
            }

            //si quieres que valla en dirección aleatoria

            if (mode == 2)
            {
                if (xPosition <= 0)
                {
                    GetComponent<Transform>().position += new Vector3(0.015f, 0.0f, 0.0f);
                }
                else
                {
                    GetComponent<Transform>().position += new Vector3(-0.015f, 0.0f, 0.0f);
                }
            }
        }
    }
}
