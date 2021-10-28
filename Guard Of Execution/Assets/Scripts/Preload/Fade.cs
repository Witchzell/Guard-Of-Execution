using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
public class Fade : MonoBehaviour
{
    // dependencies
    [SerializeField] private Image deathScreen; // screen of death
    PlayerDeath kB;
    
    private void Awake()
    {
        deathScreen.enabled = false;
    }
    
    public void DeathStarter()
    {
        StartCoroutine(FadeIn());
    }

    // fade from transparent to opaque
    private IEnumerator FadeIn() 
    {
        deathScreen.enabled = true;

        // loop over 1 second || from trasnperent to opaque
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            deathScreen.color = new Color(0, 0, 0, i);
            yield return null;
        }

        kB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>(); //Unoptimised, but it works
        kB.fadeDeath = false;
    }

    public void DeathLeaver()
    {
        StartCoroutine(FadeOut());
    }

    // fate from opaque to transperent
    private IEnumerator FadeOut()
    {
            // loop over 1 second backwards || fade from opaque to transparent
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                deathScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }

            deathScreen.enabled = false;
        }
}