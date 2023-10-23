using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int amount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.changeHealth(amount);
            Destroy(gameObject);
        }
    }
}
