using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

    public Texture[] myTextures;// = new Texture[7];
	public GameObject background1;
	public GameObject background2;
	public RawImage planet;
	private int level;

	void Start () 
	{
		level = PlayerPrefs.GetInt ("level");
        int i = 0; //this will contain the position in the array for the background image

        switch (level)
        {
            //WORLD 1
            case 1:
                i = 6;
            break;
            case 2:
                i = 6;
            break;
            case 3:
                i = 0;
            break;
            case 4:
                i = 0;
            break;
            case 5:
                i = 5;
            break;
            case 6:
                i = 6;
            break;
            case 7:
                i = 6;
            break;
            case 8:
                i = 0;
            break;
            case 9:
                i = 0;
            break;
            case 10:
                i = 5;
            break;
            //WORLD 2
            case 12:
                i = 7;
            break;
            case 13:
                i = 7;
            break;
            case 14:
                i = 1;
            break;
            case 15:
                i = 1;
            break;
            case 16:
                i = 5;
            break;
            case 17:
                i = 7;
            break;
            case 18:
                i = 7;
            break;
            case 19:
                i = 1;
            break;
            case 20:
                i = 1;
            break;
            case 21:
                i = 5;
            break;
            //WORLD 3
            case 23:
                i = 8;
                break;
            case 24:
                i = 8;
                break;
            case 25:
                i = 2;
                break;
            case 26:
                i = 2;
                break;
            case 27:
                i = 5;
                break;
            case 28:
                i = 5;
                break;
            case 30:
                i = 8;
                break;
            case 31:
                i = 8;
                break;
            case 32:
                i = 2;
                break;
            case 33:
                i = 2;
                break;
            case 34:
                i = 5;
                break;
            case 35:
                i = 5;
                break;
            //WORLD 4
            case 37:
                i = 9;
                break;
            case 38:
                i = 9;
                break;
            case 39:
                i = 3;
                break;
            case 40:
                i = 3;
                break;
            case 41:
                i = 5;
                break;
            case 42:
                i = 5;
                break;
            case 44:
                i = 9;
                break;
            case 45:
                i = 9;
                break;
            case 46:
                i = 3;
                break;
            case 47:
                i = 3;
                break;
            case 48:
                i = 5;
                break;
            case 49:
                i = 5;
                break;
            //DEFAULT
            default:
                i = 0;
                break;
        }

        //changing the backgrounds
		background1.GetComponent<Renderer> ().material.mainTexture = myTextures [i];
		background2.GetComponent<Renderer> ().material.mainTexture = myTextures [i];

	}
}
