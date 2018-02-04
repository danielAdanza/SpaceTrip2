using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class languajeLevelMenu : MonoBehaviour {

    //instructions
	public Text instrucciones1;
	public Text instrucciones2;
	public Text instrucciones3;
	public Text instrucciones4;
	public Text descInst1;
	public Text descInst2;
	public Text descInst3;
	public Text descInst4;

    public Text changeVehicle;
    public Text freeCoins;

    //store
    public Text storeText;
    public Text fiveBombs;
    public Text fiveShields;
    public Text tenBoth;
    public Text noAds;
    public Text buyIt1;
    public Text buyIt2;
    public Text buyIt3;
    public Text buyIt4;

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
		instrucciones1.text = "instrucciones";
		instrucciones2.text = "instrucciones";
		instrucciones3.text = "Batalla!";
		instrucciones4.text = "Batalla!";
		descInst1.text = "Toca la pantalla para disparar \n mueve tu móvil o tablet para mover tu nave espacial \n evita los asteroides y dispara les para ganar mas puntos";
		descInst2.text = "los botones azul oscuro en el menu son misiones especiales en donde tendras que disparar un número de naves enemigas para ganar";
		descInst3.text = "Tu objetivo es conseguir que el enemigo se quede sin vida disparandolo todo lo que puedas \n Evita los obstaculos y los disparos de la nave enemiga";
		descInst4.text = "Dificultad adicional para esta batalla \n arriba a la izquierda habrá un botón , solo podrás disparar al enemigo cuando este de color verde";

        changeVehicle.text = "cambiar vehículo";
        freeCoins.text = "20 \n monedas \n gratis";

        //store
        storeText.text = "tienda";
        fiveBombs.text = "5 bombas";
        fiveShields.text = "5 escudos";
        tenBoth.text = "+10 bombas \n+10 escudos \nsin anuncios";
        noAds.text = "sin anuncios \npopup";
        buyIt1.text = "comprar";
        buyIt2.text = "comprar";
        buyIt3.text = "comprar";
        buyIt4.text = "comprar";
    }

	public void changeToSlovene ()
	{
		instrucciones1.text = "navodila";
		instrucciones2.text = "navodila";
		instrucciones3.text = "bitka";
		instrucciones4.text = "bitka";
		descInst1.text = "dotakni se zaslona za streljanje \n nagni svojo napravo, da premaknes vesoljsko ladjo \n izogni se asteroidom in jih vstreli za vec tock";
		descInst2.text = "Temno modri gumbi so posebni ravni službenih. \n \n Tu boste morali ustreliti številne sovražne vesoljske ladje za zmago";
		descInst3.text = "Tvoja naloga je, da unicis sovrazno ladjo, tako da streljas koliko lahko. \n Izogibaj se sovraznikovim strelom ter oviram";
		descInst4.text = "Dodatna tezavnost za to bitko \n Na sovraznika lahko streljas samo, ko se v zgornjem levem kotu zaslona pojavi zelen gumb. Ko je gumb rdec ne mores streljati.";

        changeVehicle.text = "sprememba vozilo";
        freeCoins.text = "20 \n sladniko \n nagrade";

        //store
        storeText.text = "shranite";
        fiveBombs.text = "5 bombe";
        fiveShields.text = "5 ščitov";
        tenBoth.text = "+10 bombe \n+10 ščitov \nsin anuncios";
        noAds.text = "brez pojavnih \noglasov";
        buyIt1.text = "kupiti";
        buyIt2.text = "kupiti";
        buyIt3.text = "kupiti";
        buyIt4.text = "kupiti";
    }

	public void changeToFrench ()
	{
		instrucciones1.text = "instructions";
		instrucciones2.text = "instructions";
		instrucciones3.text = "bataille!";
		instrucciones4.text = "bataille!";	
		descInst1.text = "Touchez l'écran pour tirer \n Déplacez votre mobile ou tablette pour déplacer votre vaisseau spatial \n éviter les astéroïdes et tirer pour gagner plus de points";
		descInst2.text = "Les boutons bleus foncés sont des niveaux de missions spéciales \n \n ici vous aurez à tirer un certain nombre de vaisseaux spatiaux ennemis pour gagner";
		descInst3.text = "Votre but est d'obtenir que l'ennemi est sans vie montgolfière tout ce que vous pouvez \n Éviter les obstacles et les coups de l'ennemi de navire";
		descInst4.text = "Difficulté supplémentaire pour cette bataille \n ci-dessus à gauche, il y aura un bouton, vous pouvez seulement tirer l'ennemi quand vert est";

        changeVehicle.text = "changement véhicule";
        freeCoins.text = "20 \n pièces \n libres";

        //store
        storeText.text = "magasin";
        fiveBombs.text = "5 bombes";
        fiveShields.text = "5 Boucliers";
        tenBoth.text = "+10 bombes \n+10 Boucliers \nsupprimer popup";
        noAds.text = "supprimer les \npop-up";
        buyIt1.text = "comprar";
        buyIt2.text = "comprar";
        buyIt3.text = "comprar";
        buyIt4.text = "comprar";
    }

	public void changeToPortuguese ()
	{
		instrucciones1.text = "instruções";
		instrucciones2.text = "instruções";
		instrucciones3.text = "batalha!";
		instrucciones4.text = "batalha!";	
		descInst1.text = "Toque na tela para disparar \n move o seu celular ou tablet para mover a sua nave espacial \n evitar asteróides e atirar para ganhar mais pontos";
		descInst2.text = "Os botões azuis escuras são níveis especiais de missão \n \n aqui você terá que disparar uma série de naves inimigas para ganhar";
		descInst3.text = "Seu objetivo é fazer com que o inimigo é executado fora da vida atirando-o tudo o que puder \n Evite obstáculos e tiro o navio inimigo";
		descInst4.text = "Dificuldade adicional para esta batalha \n acima ala esquerda será um botão, você só pode atirar no inimigo quando verde";

        changeVehicle.text = "veículo mudança";
        freeCoins.text = "20 \n moedas \n gratis";

        //store
        storeText.text = "loja";
        fiveBombs.text = "5 bombas";
        fiveShields.text = "5 escudos";
        tenBoth.text = "+10 bombas \n+10 escudos \nsem anúncios";
        noAds.text = "sem anúncios \nemergentes";
        buyIt1.text = "comprar";
        buyIt2.text = "comprar";
        buyIt3.text = "comprar";
        buyIt4.text = "comprar";
    }
}
