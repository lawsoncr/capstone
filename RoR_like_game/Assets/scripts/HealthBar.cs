using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image Health;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    ThirdPersonMovement Player;

    private void Start(){
        Health = GetComponent<Image>();
        Player = FindObjectOfType<ThirdPersonMovement>();
    }

    private void Update(){
        CurrentHealth = Player.health;
        Health.fillAmount = CurrentHealth / MaxHealth;
    }
}
