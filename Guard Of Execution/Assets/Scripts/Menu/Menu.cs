using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [SerializeField] public int Next_Level;

    Scene_Manager levelReciver; //This will give the level to the Scene Manager

    public void StartGame()
    {
        Scene_Manager.Level = Next_Level;

        levelReciver = GameObject.FindGameObjectWithTag("Manager").GetComponent<Scene_Manager>();
        levelReciver.LoadOtherScene();
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
