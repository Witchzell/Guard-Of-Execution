using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    Scene_Manager levelReciver;
    public static bool GamePaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 1) //Making sure you cant open menu in main menu
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Resume() //Resume time when menu is closed
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Stop() //Stops time when menu is open
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void GoToMenu()
    {
        Scene_Manager.Level = 1;

        levelReciver = GameObject.FindGameObjectWithTag("Manager").GetComponent<Scene_Manager>(); //Gross coding
        levelReciver.LoadOtherScene();
        pauseMenu.SetActive(false);
    }
}