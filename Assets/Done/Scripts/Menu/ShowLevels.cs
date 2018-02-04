using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System;
using System.Linq;
using System.Collections.Generic;

public class ShowLevels : MonoBehaviour {

    //instructions
    //public GameObject backgroundMenu;
    //levels

    public Text[] levels;

	void Awake () 
	{
        ChangeTextLevels();
    }

    void ChangeTextLevels ()
    {
        int level = PlayerData.playerData.currentlevel;

        level = level - 1;

        for (int i = level;i < levels.Length;i++)
        {
            levels[i].text = "";
        }
    }
}
