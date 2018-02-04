using UnityEngine;
using System.Collections;
//added for serialization
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour {

	public static PlayerData playerData;
	//it includes the last level that the player has passed
	public int currentlevel;
    public int currentHerolevel;
    //the maximum score that the player has in each level
    public int[] scoreinlevels;
	//the total accumulative score that the player has
	public int totalscore;
	public int totalStarts;
	public int totalmatches;
	public int totalvictories;
    public int totalCoins;
    public int languaje;
	//vehicle things;
	//from 0 to 4 for the different selected skin
	public int vehicleTexture;
	// value float that goes till 0 to 1 and that will affect the final model shape
	public float vehicleThin;
	public float vehicleHeight;
	//the vehicle speed
	public int speed;
	public int vehicle;
	//purchases
    public int purchaseVehicle2;
    public int purchaseVehicle3;
	public int purchaseVehicle4;
	public int purchaseVehicle5;
	public int[] purchaseSkeen;
    public int[] achievementsState;
    public int shootingMode;
    public int publicity;
    public int superPower1;
    public int superPower2;

    void Awake () 
	{
		scoreinlevels = new int [100];
        purchaseSkeen = new int [48];
        achievementsState = new int[20];

		if (playerData == null) 
		{
			DontDestroyOnLoad (gameObject);
			playerData = this;
		} else 
		{
			Destroy(gameObject);
		}
		this.Load ();
	}

	//funciona con todo excepto con web
	public void Save ( )
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath +  "/playerdata.dat");

		Player player = new Player (playerData.totalCoins, playerData.currentlevel,playerData.currentHerolevel,playerData.scoreinlevels,playerData.totalscore,playerData.totalStarts,playerData.totalmatches, 
		                            playerData.totalvictories,playerData.languaje,playerData.vehicleTexture,playerData.vehicleThin,playerData.vehicleHeight,playerData.speed,
		                            playerData.vehicle, playerData.purchaseVehicle2, playerData.purchaseVehicle3,playerData.purchaseVehicle4,playerData.purchaseVehicle5,
		                            playerData.achievementsState,playerData.purchaseSkeen,playerData.shootingMode,playerData.publicity,playerData.superPower1,playerData.superPower2);
		bf.Serialize (file,player);
		file.Close ();
	}

	public void Load ( )
	{
		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath +  "/playerdata.dat", FileMode.Open);
			Player player = (Player) bf.Deserialize(file);
			file.Close();

			playerData.totalCoins = player.totalCoins;
			playerData.currentlevel = player.currentlevel;
            playerData.currentHerolevel = player.currentHerolevel;
            playerData.scoreinlevels = player.scoreinlevels;
			playerData.totalscore = player.totalscore;
			playerData.totalStarts = player.totalStarts;
			playerData.totalmatches = player.totalmatches;
			playerData.totalvictories = player.totalvictories;
			playerData.languaje = player.languaje;
			playerData.vehicleTexture = player.vehicleTexture;
			playerData.vehicleThin = player.vehicleThin;
			playerData.vehicleHeight = player.vehicleHeight;
			playerData.speed = player.speed;
			playerData.vehicle = player.vehicle;
            playerData.purchaseVehicle2 = player.purchaseVehicle2;
            playerData.purchaseVehicle3 = player.purchaseVehicle3;
			playerData.purchaseVehicle4 = player.purchaseVehicle4;
			playerData.purchaseVehicle5 = player.purchaseVehicle5;
            playerData.achievementsState = player.achievementState;
            playerData.purchaseSkeen = player.purchaseSkeen;
            playerData.shootingMode = player.shootingMode;
            playerData.publicity = player.publicity;
            playerData.superPower1 = player.superPower1;
            playerData.superPower2 = player.superPower2;

        }
	}

}

[Serializable]
class Player
{
	public Player (int totalCoins, int currentlevel, int currentHerolevel, int[] scoreinlevels, int totalscore, int totalStarts, int totalmatches, int totalvictories, 
                   int languaje, int vehicleTexture, float vehicleThin, float vehicleHeight, int speed, int vehicle,
                   int purchaseVehicle2, int purchaseVehicle3, int purchaseVehicle4, int purchaseVehicle5,
                   int [] achievementState, int [] purchaseSkeen,int shootingMode, int publicity, int superPower1, int superPower2)
	{
		this.totalCoins = totalCoins;
		this.currentlevel = currentlevel;
        this.currentHerolevel = currentHerolevel;
        this.scoreinlevels = scoreinlevels;
		this.totalscore = totalscore;
		this.totalStarts = totalStarts;
		this.totalmatches = totalmatches;
		this.totalvictories = totalvictories;
		this.totalvictories = totalvictories;
		this.languaje = languaje;
		this.vehicleTexture = vehicleTexture;
		this.vehicleThin = vehicleThin;
		this.vehicleHeight = vehicleHeight;
		this.speed = speed;
		this.vehicle = vehicle;
        this.purchaseVehicle2 = purchaseVehicle2;
        this.purchaseVehicle3 = purchaseVehicle3;
		this.purchaseVehicle4 = purchaseVehicle4;
		this.purchaseVehicle5 = purchaseVehicle5;
        this.purchaseSkeen = purchaseSkeen;
        this.achievementState = achievementState;
        this.shootingMode = shootingMode;
        this.publicity = publicity;
        this.superPower1 = superPower1;
        this.superPower2 = superPower2;

    }
	
	public int totalCoins;
	public int currentlevel;
    public int currentHerolevel;
    public int[] scoreinlevels;
	public int totalscore;
	public int totalStarts;
	public int totalmatches;
	public int totalvictories;
	public int languaje;
	public int vehicleTexture;
	public float vehicleThin;
	public float vehicleHeight;
	public int speed;
	public int vehicle;
    public int purchaseVehicle2;
    public int purchaseVehicle3;
	public int purchaseVehicle4;
	public int purchaseVehicle5;
    public int[] achievementState;
    public int[] purchaseSkeen;
    public int shootingMode;
    public int publicity;
    public int superPower1;
    public int superPower2;


}
