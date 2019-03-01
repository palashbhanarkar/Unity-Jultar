// Profil.cs
// Jultar
// Created by Palash Bhanarkar  13/3/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Profile : MonoBehaviour 
{
    public InputField username;

	private static string playerName;

	public static string PlayerName {
		get {
			return playerName;
		}
	}

    void Awake()
    {
		Load ();
    }
    
    public void OnSubmit()
    {
        
		Profile.playerName = username.text;
        
       // Name = username.text;
		Debug.Log(playerName);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerName.info");

        
        Data playerData = new Data();
		playerData.Name = playerName;

		bf.Serialize(file, playerData);
        file.Close();

    }

	private void Load()                                                                      //Load Data
	{
		if(File.Exists(Application.persistentDataPath + "/PlayerName.info")){

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerName.info", FileMode.Open);

			Data playerData = (Data)bf.Deserialize(file);                           //Derserialization of file
			file.Close();

			Profile.playerName = playerData.Name;
			Debug.Log (Profile.playerName);

		}
	}

    [System.Serializable]

    class Data {
        
        public string Name;

    }

}

