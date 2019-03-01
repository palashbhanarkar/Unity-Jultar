// PrefControl.cs
// Jultar
// Created by Palash Bhanarkar  10/3/17


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class PrefControl : MonoBehaviour {

    public float HP;
    public float XP;
    public static PrefControl control;

    //Awake is called before Start
    void Awake()                                                                             //Check of PrefControl on awake if present use as is if not destroy present and use current
    {
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");            //for IOS

        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if(control != this) {
            Destroy(gameObject);
        }
    }

    void OnGUI()        //GUI labels for HP and XP with values
    {
        GUI.Label(new Rect(10, 10, 100, 30), "HP: " + HP);
        GUI.Label(new Rect(10, 40, 100, 30), "XP: " + XP);
    }

    public void Save() {                                                                    //Save Data
        BinaryFormatter bf = new BinaryFormatter();                                         //Encoding in Binary Format and saving to "file" located @
        FileStream file = File.Create(Application.persistentDataPath + "/player.info");    
                                                                                            //Location of Binary encoded Save file in Windows: C:\Users\Palash\AppData\LocalLow\TatrySight\Jultar\player.info
                                                                                            //Location on Mac: ~/Library/Application Support/TatrySight/Jultar/player.info
                                                                                            //Location in Android:  /Data/Data/com.TatrySight.Jultar/Files/player.info        
        PlayerData Data = new PlayerData();
        Data.HP = HP;
        Data.XP = XP;

        bf.Serialize(file, Data);                                                           //Binary encoding of data into file
        file.Close();

    }

    public void Load()                                                                      //Load Data
    {
        if(File.Exists(Application.persistentDataPath + "/player.info")){

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.info", FileMode.Open);

            PlayerData Data = (PlayerData)bf.Deserialize(file);                           //Derserialization of file
            file.Close();

            HP = Data.HP;
            XP = Data.XP;
            
        }
    }


[Serializable]
    class PlayerData {

        public float HP;
        public float XP;

    }

    	
}
