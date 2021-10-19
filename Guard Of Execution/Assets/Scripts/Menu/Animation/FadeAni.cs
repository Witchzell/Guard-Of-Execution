using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAni : MonoBehaviour
{
    // https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
    public Text tex;
    public getOut gO; //Referencing the gatOut script
   
    private void Awake()
    {
        StartCoroutine(FadeText());
    }
 
    private IEnumerator FadeText()
    {
        while(gO.beGone != false) //Ensuring that the animation will stop once this is hidden
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                tex.color = new Color(1, 1, 1, i);
                yield return null;
            }
        
            // fade from transparent to opaque
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                tex.color = new Color(1, 1, 1, i);
                yield return null;
            }
            
            yield return null;
        }
    }
}
