// SwitchScene.cs
// Jultar
// Created by Palash Bhanarkar  10/3/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_To_Lobby : MonoBehaviour {

    void Awake()
    {
        SceneManager.LoadScene("Lobby");
    }

}
