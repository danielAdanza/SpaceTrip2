using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class languajeMainGame : MonoBehaviour {

	public Text restart;
	public Text mainMenu;
	public Text nextLevel;
	public Text freeStar;
	public Text share;
	//pausemenu
	public Text exit;
	public Text mainmenu;
	public Text goBack;
    public Text shootingText;


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
            changeToFrench();
        }
        else if (PlayerData.playerData.languaje == 5)
        {
            changeToPortuguese();
        }
    }
	
	public void changeToSpanish ()
	{
		restart.text = "volver a intentar";
		mainMenu.text = "menú principal";
		nextLevel.text = "siguiente nivel";
		freeStar.text = "1 vida gratis";
		share.text = "compartir";
		exit.text = "salir";
		mainmenu.text = "menu principal";
		goBack.text = "jugar";
        shootingText.text = "¿disparo automático?";

    }

	public void changeToSlovene ()
	{
		restart.text = "ponovno zaženi";
		mainMenu.text = "glavni meni";
		nextLevel.text = "naslednja stopnja";
		freeStar.text = "brezplačno življenje";
		share.text = "stol";
		mainmenu.text = "glavni meni";
		exit.text = "izhod";
		goBack.text = "igraj";
        shootingText.text = "Samodejno streljanje?";
    }

	public void changeToFrench ()
	{
		restart.text = "réessayer";
		mainMenu.text = "menu principal";
		nextLevel.text = "prochain niveau";
		freeStar.text = "1 vie libre";
		share.text = "partager";
		exit.text = "laisser";
		mainmenu.text = "menu principal";
		goBack.text = "jouer";
        shootingText.text = "¿Tir automatique?";
    }

	public void changeToPortuguese ()
	{
		restart.text = "tente novamente";
		mainMenu.text = "menu principal";
		nextLevel.text = "próximo nível";
		freeStar.text = "1 vida livre";
		share.text = "compartilhar";
		exit.text = "deixar";
		mainmenu.text = "menu principal";
		goBack.text = "jogar";
        shootingText.text = "¿disparo automático?";
    }
}
