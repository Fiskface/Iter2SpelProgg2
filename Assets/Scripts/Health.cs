using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int health;

    [SerializeField] private Image healthbarImage;
    
    private void Start()
    {
        health = maxHealth;
        UpdateHealthbar(health, maxHealth);
    }

    public void changeHealth(int amount)
    {
        health = Mathf.Clamp(health += amount, 0, maxHealth);
        UpdateHealthbar(health, maxHealth);
    }
    
    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        healthbarImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
