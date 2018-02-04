using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	//retoque por mi
	public GameObject spaceship;
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
    //the difference within levels that has the fire rate
    //LV 0: - 0.03
    //LV 1: - 0.01
    //LV 2: + 0.01
    //LV 3: + 0.03
    private float LevelFireRate;

    private float nextFire;
	private Quaternion calibrationQuaternion;

    private AudioSource source;

    void Start ()
	{
		CalibrateAccelerometer ();
		speed = speed + (PlayerData.playerData.speed * 10);

        source = GetComponent<AudioSource>();
        source.volume = (float)PlayerPrefs.GetInt("soundsVolume") * 0.1f;
    }
	void Update ()
	{
        switch ( PlayerPrefs.GetInt("BoltLevel") )
        {
            case 0:
                LevelFireRate = 0.03f;
                break;
            case 1:
                LevelFireRate = 0.01f;
                break;
            case 2:
                LevelFireRate = -0.01f;
                break;
            case 3:
                LevelFireRate = -0.03f;
                break;
        }
        //shooting mode = 1: automatic
        //shooting mode = 2: tap screen
        if (PlayerData.playerData.shootingMode == 1)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate + LevelFireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate + LevelFireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
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
