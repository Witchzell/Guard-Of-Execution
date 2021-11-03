using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Respawn Area")]
    public Transform respawnPos; //This is the respawn position
    Fade Fade; //Fade effect linking
    public bool load = false; //Allow for a smooth transiction

    [Header("Health")]
    public int maxHp = 10;
    public int newHp;
    public int hp;

    private void Awake()
    {
        hp = maxHp;
        newHp = hp;
        transform.position = respawnPos.position; //Bring the object to the respawn position
        Fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>(); //Unoptimised, but it works
                                                                              //This way cause it is in DDOL
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillBox") //Checking if the object has the tag "Killbox"
        {
            hp = 0;
        }
    }

    private void Update()
    {
        if(hp == 0)
        {
            StartCoroutine(Restart());
            hp = maxHp; //Setting hp to max hp
        }
    }

    private IEnumerator Restart()
    {
        Fade.DeathStarter();
        yield return new WaitUntil(() => load == true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Fade.DeathLeaver();
        load = false;
    }
}
