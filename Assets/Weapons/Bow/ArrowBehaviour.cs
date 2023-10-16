using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    public int damage = 1;

    public bool allied;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<TargetBehaviour>(out TargetBehaviour target))
        {
            if (allied == target.allied) return;
            target.hit(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
