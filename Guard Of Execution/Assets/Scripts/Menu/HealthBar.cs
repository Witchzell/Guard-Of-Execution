using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    [SerializeField] private PlayerDeath PlayerDeath;

    private void Awake()
    {
        healthBar.enabled = true;
        healthBar.maxValue = PlayerDeath.maxHp;
        healthBar.value = PlayerDeath.hp;
    }

    private void Update()
    {
        healthBar.value = PlayerDeath.hp;
        if(PlayerDeath.hp == 0)
        {
            healthBar.enabled = false;
        }
    }
}