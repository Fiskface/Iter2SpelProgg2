using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
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

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        if(healthbarImage != null)
            healthbarImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
