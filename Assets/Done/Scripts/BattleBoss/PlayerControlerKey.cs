using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControlerKey : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	private Quaternion calibrationQuaternion;

	void Start ()
	{
		CalibrateAccelerometer ();
		speed = speed + (PlayerData.playerData.speed * 10);
	}

	void Update ()
	{
        // shooting mode = 1: automatic
        // shooting mode = 2: tap screen
        if (PlayerData.playerData.shootingMode == 1)
        {
            if (Time.time > nextFire)
            {
                if ((PlayerPrefs.GetInt("battle") == 2) && (PlayerPrefs.GetInt("fire") == 0))
                {
                    //here you can not shoot
                }
                else
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                if ((PlayerPrefs.GetInt("battle") == 2) && (PlayerPrefs.GetInt("fire") == 0))
                {
                    //here you can not shoot
                }
                else
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    GetComponent<AudioSource>().Play();
                }
            }
        }
	}

	void FixedUpdate ()
	{
		//moving with computer or web
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		//moving with phones
		Vector3 accelerationRaw = Input.acceleration;
		Vector3 acceleration = FixAcceleration (accelerationRaw);
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);
		
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);

        if (PlayerData.playerData.vehicle == 5)
        {
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(90.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }
        else
        {
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }

        //GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	//Used to calibrate the Iput.acceleration input
	void CalibrateAccelerometer () 
	{
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}
	
	//Get the 'calibrated' value from the Input
	Vector3 FixAcceleration (Vector3 acceleration) 
	{
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}
}
