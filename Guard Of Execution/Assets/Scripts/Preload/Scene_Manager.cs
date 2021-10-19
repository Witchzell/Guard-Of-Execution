using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    [Header("Loading Screen")] 
    [SerializeField] private Slider loadingBarSlider;
    [SerializeField] private Text loadingPercentText;
    [SerializeField] private GameObject loadingScreen;

    public static int Level = 0;

    private void Awake()
    {
        SceneManager.LoadScene(1); //This will bring the user to scene 1 instead of the preload scene
    }

    public void LoadOtherScene()
    {
        // Debug.Log(Level);
        StartCoroutine(LoadScene(Level));
    }

    private IEnumerator LoadScene(int index) //This is the the loading if the different levels
    {
        AsyncOperation LoadingData = SceneManager.LoadSceneAsync(index);

        loadingScreen.SetActive(true);
        Time.timeScale = 0f;

        while(!LoadingData.isDone)
        {
            float loadingProgress = Mathf.Clamp(LoadingData.progress / 0.9f, 0, 1);
            loadingBarSlider.value = loadingProgress;
            loadingPercentText.text = $"Loading: {Mathf.RoundToInt(loadingProgress*100)}%";
            
            yield return null;
        }

        Time.timeScale = 1f;
        loadingScreen.SetActive(false);
    }
}
