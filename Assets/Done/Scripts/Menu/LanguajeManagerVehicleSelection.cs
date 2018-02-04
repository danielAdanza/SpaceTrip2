using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguajeManagerVehicleSelection : MonoBehaviour 
{
	//buttons footer
	public Text changeVehicleButton;
	//texto para las barritas
	public Text textshort;
	public Text texthight;
	public Text textwidth;
	public Text textheigth;
	public Text textspeed;
	//texto para comprar las skins
	public Text skindialog;
	public Text skinprice;
    //texto para cambiar los stats
    public Text bolt;
    public Text speed;
    public Text shape;


	void Start () 
	{
		if (PlayerData.playerData.languaje == 2) 
		{
			changeToSpanish();
		}
		if (PlayerData.playerData.languaje == 3) 
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
		changeVehicleButton.text = "cambiar";
		textshort.text = "bajo";
		texthight.text = "alto";
		textwidth.text = "esbelto";
		textheigth.text = "ancho";
		textspeed.text = "veloc.";
		skindialog.text = "¿quieres comprar la skin seleccionada?";
		skinprice.text = "PRECIO: 50";
        bolt.text = "rayo";
        speed.text = "velocidad";
        shape.text = "forma";
	}
	
	public void changeToSlovene ()
	{
		changeVehicleButton.text = "spremeni";
		textshort.text = "kratko";
		texthight.text = "visoko";
		textwidth.text = "dolgo";
		textheigth.text = "sirse";
		textspeed.text = "hitrost";
		skindialog.text = "hoces kupiti izbrano barvo?";
		skinprice.text = "CENA: 50";
        bolt.text = "laser";
        speed.text = "hitrost";
        shape.text = "oblika";
    }

	public void changeToFrench ()
	{
		changeVehicleButton.text = "changement";
		textshort.text = "faible";
		texthight.text = "élevé";
		textwidth.text = "mince";
		textheigth.text = "largeur";
		textspeed.text = "vitesse";
		skindialog.text = "vous voulez acheter la peau sélectionné?";
		skinprice.text = "PRIX: 50";
        bolt.text = "boulon";
        speed.text = "la vitesse";
        shape.text = "forme";
    }

	public void changeToPortuguese ()
	{
		changeVehicleButton.text = "mudança";
		textshort.text = "baixo";
		texthight.text = "alto";
		textwidth.text = "fino";
		textheigth.text = "largura";
		textspeed.text = "veloc.";
		skindialog.text = "você quer comprar a pele selecionado?";
		skinprice.text = "PREÇO: 50";
        bolt.text = "parafuso";
        speed.text = "velocidade";
        shape.text = "forma";
    }

}
