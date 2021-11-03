using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
public class Fade : MonoBehaviour
{
    //Dependencies
    [Header("Dependencies")]
    [SerializeField] private Image deathScreen; // screen of death
    PlayerDeath pD;
    public bool fadeDeath = false;
    private bool cont = false;
    
    private void Awake()
    {
        deathScreen.enabled = false;
    }
    
    public void DeathStarter()
    {
        StartCoroutine(FadeIn());
    }

    //Fade from transparent to opaque
    private IEnumerator FadeIn() 
    {
        deathScreen.enabled = true;

        //Loop over 1 second || from trasnperent to opaque
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            //Set color with i as alpha
            deathScreen.color = new Color(0, 0, 0, i);

            if(i <= 1)
            {
                cont = true;
            }
            yield return null;
        }
        
        yield return new WaitUntil(() => cont = true);
        cont = false;
        fadeDeath = true;
        pD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
        pD.load = true;
        Debug.Log("FadeIn");
    }

    public void DeathLeaver()
    {
        StartCoroutine(FadeOut());
    }

    //Fade from opaque to transperent
    private IEnumerator FadeOut()
    {
        Debug.Log("FadeOut");

            yield return new WaitUntil(() => fadeDeath == true);

            // loop over 1 second backwards || fade from opaque to transparent
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                deathScreen.color = new Color(0, 0, 0, i);

                if(i >= 0)
                {
                    cont = true;
                }
                yield return null;
            }

            fadeDeath = false;
            deathScreen.enabled = false;
        }
}