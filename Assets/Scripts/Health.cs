using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int health;

    [SerializeField] private Image healthbarImage;
    [SerializeField] private TextMeshProUGUI healthbarText;
    
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
        if(healthbarImage != null)
            healthbarImage.fillAmount = (float)currentHealth / maxHealth;
        if (healthbarText != null)
        {
            healthbarText.text = $"{currentHealth} / {maxHealth}";
        }
    }
}
