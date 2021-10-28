using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Respawn Area")]
    public Transform respawnPos; //This is the respawn position
    public bool fadeDeath = false;
    Fade Fade; //Fade effect linking

    [Header("Health")]
    public int maxHp = 10;
    public int hp;

    private void Awake()
    {
        hp = maxHp;
        transform.position = respawnPos.position; //Bring the object to the respawn position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillBox") //Checking if the object has the tag "Killbox"
        {
            StartCoroutine(Until());
        }
    }

    private void Update()
    {
        if(hp == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            hp = maxHp; //
        }
    }

    public IEnumerator Until()
    {
        fadeDeath = true;

        Fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>(); //Unoptimised, but it works
        Fade.DeathStarter();                                                  //This way cause it is in DDOL

        yield return new WaitWhile(() => fadeDeath == false);

        Fade.DeathLeaver();
        hp = 0;
    }
}
