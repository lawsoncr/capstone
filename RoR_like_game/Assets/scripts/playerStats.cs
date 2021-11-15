using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public float totalPoints = 0f;
    public float killReward = 10f;
    public float CurrentHealth;
    EnemyAI Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = FindObjectOfType<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Enemy.health;
        if(CurrentHealth <= 0){
            totalPoints = totalPoints + killReward;
        }
    }
}
