// SwitchScene.cs
// Jultar
// Created by Palash Bhanarkar  10/3/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    public string sceneToLoad;

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 50, 100, 30), "Current Scene: " + (SceneManagerHelper.ActiveSceneName));      //Simple Label "Current Scene" showing the active scene

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 750, 100, 40), "Load Scene: " + (sceneToLoad)))                          //The scene to be Loaded is shown on the button label
        {

            Application.LoadLevel(sceneToLoad);         //Respective scene with variable sceneToLoad string type is loaded on click "Load Scene"(Enter parameter in inspector for the Scene you want to Load)
                                                        //Scene to be present in Assets/Scenes folderS
        }
    }

    void Awake()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
