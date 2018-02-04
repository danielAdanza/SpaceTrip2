using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleBossLanguajeManager : MonoBehaviour {

	//game over
	public Text mainMenu;
	public Text restart;
	public Text exit;
	//finish game
	public Text mainMenu2;
	//pause buttons
	public Text play;
	public Text mainMenu3;
	public Text exit3;

	// Use this for initialization
	void Start () 
	{
		
		if (PlayerData.playerData.languaje == 2) 
		{
			changeToSpanish();
		}
		else if (PlayerData.playerData.languaje == 3) 
		{
			changeToSlovene ();
		}
		else if (PlayerData.playerData.languaje == 4) 
		{
			changeToFrench ();
		}
		else if (PlayerData.playerData.languaje == 5) 
		{
			changeToPortuguese ();
		}
	
	}
	
	public void changeToSpanish ()
	{
		//game over
		mainMenu.text = "menu principal";
		restart.text = "volver a intentar";
		exit.text = "salir";
		//finish game
		mainMenu2.text = "menu principal";
		//pause buttons
		play.text = "jugar";
		mainMenu3.text = "menu principal";
		exit3.text = "salir";
	}

	public void changeToSlovene ()
	{
		//game over
		mainMenu.text = "glavni meni";
		restart.text = "ponovno zaženi";
		exit.text = "izhod";
		//finish game
		mainMenu2.text = "glavni meni";
		//pause buttons
		play.text = "igraj";
		mainMenu3.text = "glavni meni";
		exit3.text = "izhod";
	}

	public void changeToFrench ()
	{
		//game over
		mainMenu.text = "menu principal";
		restart.text = "vréessayer";
		exit.text = "Sortie";
		//finish game
		mainMenu2.text = "menu principal";
		//pause buttons
		play.text = "jouer";
		mainMenu3.text = "menu principal";
		exit3.text = "Sortie";
	}

	public void changeToPortuguese ()
	{
		//game over
		mainMenu.text = "menu principal";
		restart.text = "tentar novamente";
		exit.text = "Saída";
		//finish game
		mainMenu2.text = "menu principal";
		//pause buttons
		play.text = "jugar";
		mainMenu3.text = "menu principal";
		exit3.text = "Saída";
	}
}
