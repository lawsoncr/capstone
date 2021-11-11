using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float CurrentHealth;
    public float maxHealth = 50;
    public GameObject healthBarUI;
    public Slider slider;
    EnemyAI Enemy;

    void Start(){
        Enemy = FindObjectOfType<EnemyAI>();
        slider.value = (CurrentHealth / maxHealth);
    }

    void Update(){
        CurrentHealth = Enemy.health;
        slider.value = (CurrentHealth / maxHealth);

        if(CurrentHealth < maxHealth){
            healthBarUI.SetActive(true);
        }
    }
}