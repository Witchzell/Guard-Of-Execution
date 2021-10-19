using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearAni : MonoBehaviour
{
    public int timer = 0; //Timer for the animation to start
    public Text tex;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); //Getting the component that allows for the audio
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        yield return new WaitForSeconds(timer);
        audioSource.Play();
        tex.enabled = true;

        // fade from transparent to opaque
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            tex.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}

