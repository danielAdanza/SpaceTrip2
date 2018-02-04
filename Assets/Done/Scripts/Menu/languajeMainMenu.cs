using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class languajeMainMenu : MonoBehaviour 
{
	public Text scores;
	public Text invite;
	public Text achievements;
	public Text play;
	public Text editVehicle;
	public Text settings;
	public Text getFreeStars;
	public Text credits;
	public Text playerInfo;
	public Text languajes;
	//credits section
	public Text companyProducer;
	public Text director;
	public Text vehicleModeler;
	public Text baseGame;
	public Text music;
	//player data section
	public Text level1;
	public Text level2;
	public Text score;
	public Text matches;
	public Text stars;
	public Text victories;
    public Text coins;
    public Text achievem;
    public Text vehicles;
    //more apps section
    public Text IHaveNever;
    //public Text commingSoon1;
    //public Text commingSoon2;
    //public Text commingSoon3;
    //achievementsSection
    public Text achievementsText1;
    public Text achievementsText2;
    public Text achievementsText3;
    public Text achievementsText4;
    public Text achievementsText5;
    public Text achievementsText6;
    public Text achievementsText7;
    public Text achievementsText8;
    public Text achievementsText9;
    public Text achievementsText10;
    //facebook popup section
    public Text inviteFriendsText;
    public Text inviteButton;

    public Text followUs;

    public GameObject background;
	public GameObject languajesSection;

	//0 = not set
	//1 = english
	//2 = spanish;
	//3 = slovene;
	//4 = french
	//5 = portuguese

	void Start () 
	{
		if (PlayerData.playerData.languaje == 0) 
		{
			PlayerPrefs.SetInt ("mode", 3);
			background.SetActive (true);
			languajesSection.SetActive (true);
		} 
		else if (PlayerData.playerData.languaje == 1) 
		{
            changeToEnglish ();
        } 
		else if (PlayerData.playerData.languaje == 2) 
		{
			changeToSpanish ();
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

	public void changeToEnglish ()
	{
		PlayerData.playerData.languaje = 1;
		PlayerData.playerData.Save();
		
		scores.text = "scores";
		invite.text = "invite";
		achievements.text = "achievements";
		play.text = "play";
		editVehicle.text = "Edit Vehicle";
		settings.text = "options";
		getFreeStars.text = "more apps";
		credits.text = "credits";
		playerInfo.text = "player info";
		languajes.text = "languajes";

		companyProducer.text = "company producer:";
		director.text = "director & programmer:";
		vehicleModeler.text = "Vehicle designer:";
		baseGame.text = "base game:";
		music.text = "music producer:";
        level1.text = "normal- " + PlayerData.playerData.currentlevel;
        level2.text = "hero- " + PlayerData.playerData.currentlevel;
        score.text = "score- "+ PlayerData.playerData.totalscore;
		matches.text = "stages- " + PlayerData.playerData.totalmatches;
		stars.text = "stars- "+ PlayerData.playerData.totalStarts;

        coins.text = "coins-" + PlayerData.playerData.totalCoins;
        achievem.text = "achievem.";
        vehicles.text = "vehicles";

        if ((PlayerData.playerData.totalvictories == 0) || (PlayerData.playerData.totalmatches == 0))
        {
            victories.text = "vict- 0 % ";
        }
        else
        {
            victories.text = "vict- " + PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
        }

        IHaveNever.text = "I have never";
        //commingSoon1.text = "coming soon";
        //commingSoon2.text = "coming soon";
        //commingSoon3.text = "coming soon";

        achievementsText1.text = "Unlock world 1";
        achievementsText2.text = "Unlock world 2";
        achievementsText3.text = "Unlock world 3";
        achievementsText4.text = "Unlock world 4";
        achievementsText5.text = "Play 50 times";
        achievementsText6.text = "Play 100 times";
        achievementsText7.text = "Play 200 times";
        achievementsText8.text = "Win 20 times";
        achievementsText9.text = "Win 50 times";
        achievementsText10.text = "Win 100 times";

        inviteFriendsText.text = "playing is better \n with friends \n \n why don't you invite \n them to play?";
        inviteButton.text = "invite \n friends";

        followUs.text = "follow us:";
    }

	public void changeToSpanish ()
	{
		PlayerData.playerData.languaje = 2;
		PlayerData.playerData.Save();

		scores.text = "ranking";
		invite.text = "invitar";
		achievements.text = "logros";
		play.text = "jugar";
		editVehicle.text = "Editar Vehículo";
		settings.text = "opciones";
		getFreeStars.text = "mas apps";
		credits.text = "créditos";
		playerInfo.text = "datos del jugador";
		languajes.text = "idiomas";
		companyProducer.text = "empresa productora:";
		director.text = "director y programador:";
		vehicleModeler.text = "diseñadores de vehiculo:";
		baseGame.text = "base del juego:";
		music.text = "productor musical:";

        level1.text = "normal- " + PlayerData.playerData.currentlevel;
        level2.text = "héroe- " + PlayerData.playerData.currentlevel;
        score.text = "Puntuacion- "+ PlayerData.playerData.totalscore;
		matches.text = "partidas- " + PlayerData.playerData.totalmatches;
		stars.text = "estrellas- "+ PlayerData.playerData.totalStarts;

        coins.text = "monedas-" + PlayerData.playerData.totalCoins;
        achievem.text = "logros.";
        vehicles.text = "vehículos";

        if ( (PlayerData.playerData.totalvictories == 0) || (PlayerData.playerData.totalmatches == 0) )
        {
            victories.text = "vict- 0 % ";
        }
        else
        {
            victories.text = "vict- " + PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
        }

        

        IHaveNever.text = "Yo nunca";
        //commingSoon1.text = "proximamente";
        //commingSoon2.text = "proximamente";
        //commingSoon3.text = "proximamente";

        achievementsText1.text = "Desbloquea \n el mundo 1";
        achievementsText2.text = "Desbloquea \n el mundo 2";
        achievementsText3.text = "Desbloquea \n el mundo 3";
        achievementsText4.text = "Desbloquea \n el mundo 4";
        achievementsText5.text = "Juega 50 veces";
        achievementsText6.text = "Juega 100 veces";
        achievementsText7.text = "Juega 200 veces";
        achievementsText8.text = "Gana 20 veces";
        achievementsText9.text = "Gana 50 veces";
        achievementsText10.text = "Gana 100 veces";

        inviteFriendsText.text = "Jugar es mejor \n con amigos \n \n ¿Por qué no les invitas \n a jugar?";
        inviteButton.text = "invitar \n amigos";

        followUs.text = "Síguenos:";
    }

	public void changeToSlovene ()
	{
		PlayerData.playerData.languaje = 3;
		PlayerData.playerData.Save();
		
		scores.text = "rezultati";
		invite.text = "povabi";
		achievements.text = "dosežki";
		play.text = "igra";
		editVehicle.text = "spremeni vozilo";
		settings.text = "možnosti";
		getFreeStars.text = "vec aplikacij";
		credits.text = "krediti";
		playerInfo.text = "podatki o igralcu";
		languajes.text = "jeziki";
		companyProducer.text = "razvijalec:";
		director.text = "vodja in programer:";
		vehicleModeler.text = "oblikovalec vozil:";
		baseGame.text = "osnova igre:";
		music.text = "glasbeni producent:";

        level1.text = "normalni- " + PlayerData.playerData.currentlevel;
        level2.text = "herojski- " + PlayerData.playerData.currentlevel;
        score.text = "ocena- " + PlayerData.playerData.totalscore;
        matches.text = "tekme- " + PlayerData.playerData.totalmatches;
        stars.text = "zvezde- " + PlayerData.playerData.totalStarts;

        coins.text = "kovanci-" + PlayerData.playerData.totalCoins;
        achievem.text = "dosežki.";
        vehicles.text = "vozila";

        if ((PlayerData.playerData.totalvictories == 0) || (PlayerData.playerData.totalmatches == 0))
        {
            victories.text = "zmage- 0 % ";
        }
        else
        {
            victories.text = "zmage- " + PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
        }

        IHaveNever.text = "Jaz nisem nikoli";
        //commingSoon1.text = "prihaja kmalu";
        //commingSoon2.text = "prihaja kmalu";
        //commingSoon3.text = "prihaja kmalu";

        achievementsText1.text = "odklepanje \n svet 1";
        achievementsText2.text = "odklepanje \n svet 2";
        achievementsText3.text = "odklepanje \n svet 3";
        achievementsText4.text = "odklepanje \n svet 4";
        achievementsText5.text = "igrajo 50 krat";
        achievementsText6.text = "igrajo 100 krat";
        achievementsText7.text = "igrajo 200 krat";
        achievementsText8.text = "zmaga 20 krat";
        achievementsText9.text = "zmaga 50 krat";
        achievementsText10.text = "zmaga 100 krat";

        inviteFriendsText.text = "Igrati bolje \n s prijatelji \n \n zakaj ne povabite \n da igrajo?";
        inviteButton.text = "povabi \n prijatelje";

        followUs.text = "sledi nam:";
    }

	public void changeToFrench ()
	{
		PlayerData.playerData.languaje = 4;
		PlayerData.playerData.Save();
		
		scores.text = "classement";
		invite.text = "inviter";
		achievements.text = "réalisations";
		play.text = "jouer";
		editVehicle.text = "modifier véhicule";
		settings.text = "paramètres";
		getFreeStars.text = "plus d'applications";
		credits.text = "crédits";
		playerInfo.text = "Info joueur";
		languajes.text = "idiomes";
		
		companyProducer.text = "société de production:";
		director.text = "directeur & programm. :";
		vehicleModeler.text = "designer du véhicule:";
		baseGame.text = "jeu basé:";
		music.text = "producteur de musique:";

        level1.text = "normal- " + PlayerData.playerData.currentlevel;
        level2.text = "hero- " + PlayerData.playerData.currentlevel;
        score.text = "score- " + PlayerData.playerData.totalscore;
        matches.text = "matchs- " + PlayerData.playerData.totalmatches;
        stars.text = "étoile: " + PlayerData.playerData.totalStarts;

        coins.text = "monnaie-" + PlayerData.playerData.totalCoins;
        achievem.text = "réalisat.";
        vehicles.text = "Véhicules";

        if ((PlayerData.playerData.totalvictories == 0) || (PlayerData.playerData.totalmatches == 0))
        {
            victories.text = "vict- 0 % ";
        }
        else
        {
            victories.text = "vict- " + PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
        }

        IHaveNever.text = "Je n'ai jamais";
        //commingSoon1.text = "arrive bientôt";
        //commingSoon2.text = "arrive bientôt";
        //commingSoon3.text = "arrive bientôt";

        achievementsText1.text = "déverrouiller \n le monde 1";
        achievementsText2.text = "déverrouiller \n le monde 2";
        achievementsText3.text = "déverrouiller \n le monde 3";
        achievementsText4.text = "déverrouiller \n le monde 4";
        achievementsText5.text = "joué 50 fois";
        achievementsText6.text = "joué 100 fois";
        achievementsText7.text = "joué 200 fois";
        achievementsText8.text = "gagne 20 fois";
        achievementsText9.text = "gagne 50 fois";
        achievementsText10.text = "gagne 100 fois";

        inviteFriendsText.text = "le jeu est mieux \n avec des amis \n \n Pourquoi ne pas les \n inviter à jouer?";
        inviteButton.text = "inviter \n personnes";

        followUs.text = "Suivez-nous:";
    }

	public void changeToPortuguese ()
	{
		PlayerData.playerData.languaje = 5;
		PlayerData.playerData.Save();
		
		scores.text = "posição";
		invite.text = "convidar";
		achievements.text = "conquistas";
		play.text = "jogar";
		editVehicle.text = "editar veículo";
		settings.text = "opções";
		getFreeStars.text = "mais aplicações";
		credits.text = "créditos";
		playerInfo.text = "dados do jogador";
		languajes.text = "línguas";
		companyProducer.text = "empresa de produção:";
		director.text = "diretor e programador:";
		vehicleModeler.text = "projetistas de veículos:";
		baseGame.text = "jogo base:";
		music.text = "produtor musical:";

        level1.text = "normal- " + PlayerData.playerData.currentlevel;
        level2.text = "héroe- " + PlayerData.playerData.currentlevel;
        score.text = "ponto- " + PlayerData.playerData.totalscore;
        matches.text = "partidas- " + PlayerData.playerData.totalmatches;
        stars.text = "estrelas: " + PlayerData.playerData.totalStarts;

        coins.text = "moedas-" + PlayerData.playerData.totalCoins;
        achievem.text = "realiza.";
        vehicles.text = "veículos";

        if ((PlayerData.playerData.totalvictories == 0) || (PlayerData.playerData.totalmatches == 0))
        {
            victories.text = "vitó- 0 % ";
        }
        else
        {
            victories.text = "vitó- " + PlayerData.playerData.totalvictories * 100 / PlayerData.playerData.totalmatches + " % ";
        }

        IHaveNever.text = "eu nunca";
        //commingSoon1.text = "em breve";
        //commingSoon2.text = "em breve";
        //commingSoon3.text = "em breve";

        achievementsText1.text = "desbloqueia \n o mundo 1";
        achievementsText2.text = "desbloqueia \n o mundo 2";
        achievementsText3.text = "desbloqueia \n o mundo 3";
        achievementsText4.text = "desbloqueia \n o mundo 4";
        achievementsText5.text = "jogou 50 vezes";
        achievementsText6.text = "jogou 100 vezes";
        achievementsText7.text = "jogou 200 vezes";
        achievementsText8.text = "ganha 20 vezes";
        achievementsText9.text = "ganha 50 vezes";
        achievementsText10.text = "ganha 100 vezes";

        inviteFriendsText.text = "jogo é melhor \n com amigos \n \n por que não convidá-los \n a jogar?";
        inviteButton.text = "convidar \n amigos";

        followUs.text = "Siga-nos:";
    }

}
