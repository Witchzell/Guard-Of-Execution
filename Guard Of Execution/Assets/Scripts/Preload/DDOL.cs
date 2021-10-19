using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a script that will prevent actions from being destroied on load of different scenes.
public class DDOL : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this); 
    }
}
