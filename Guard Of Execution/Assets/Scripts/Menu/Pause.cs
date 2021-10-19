using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    Scene_Manager levelReciver;
    public static bool GamePaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 1)
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

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Stop()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void GoToMenu()
    {
        Scene_Manager.Level = 1;

        levelReciver = GameObject.FindGameObjectWithTag("Manager").GetComponent<Scene_Manager>();
        levelReciver.LoadOtherScene();
        pauseMenu.SetActive(false);
    }
}