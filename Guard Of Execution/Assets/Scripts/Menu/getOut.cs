using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getOut : MonoBehaviour
{
    public bool beGone = true;
    public GameObject menu;
    
    private void Update()
    {
        if(Input.anyKey)
        {
            menu.SetActive(false);
            beGone = false;
        }
    }
}
