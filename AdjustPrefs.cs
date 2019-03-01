// AdjustPrefs.cs
// Jultar
// Created by Palash Bhanarkar  10/3/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPrefs : MonoBehaviour {

    void OnGUI()                                                    //Dift. GUI Buttons to inc, dec HP and XP as well as Save and Load prefs to and fetch from file respectively.
    {
        if(GUI.Button(new Rect(10, 100, 100, 30), "HP up")){
            PrefControl.control.HP += 20;
        }

        if (GUI.Button(new Rect(10, 140, 100, 30), "HP down")){
            PrefControl.control.HP -= 20;
        }

        if (GUI.Button(new Rect(10, 180, 100, 30), "XP up")){
            PrefControl.control.XP += 50;
        }

        if (GUI.Button(new Rect(10, 220, 100, 30), "XP down")){
            PrefControl.control.XP -= 50;
        }

        if (GUI.Button(new Rect(10, 260, 100, 30), "Save")){
            PrefControl.control.Save();
            Debug.Log("Data saved successfully");
        }

        if (GUI.Button(new Rect(10, 300, 100, 30), "Load")){
            PrefControl.control.Load();
        }
    }
}
