using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Indicator : MonoBehaviour
{

    [SerializeField] public int Next_Level;

    Scene_Manager levelReciver; //This will give the level to the Scene Manager

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Scene_Manager.Level = Next_Level;

            levelReciver = GameObject.FindGameObjectWithTag("Manager").GetComponent<Scene_Manager>();
            levelReciver.LoadOtherScene();
        }
    }
}
