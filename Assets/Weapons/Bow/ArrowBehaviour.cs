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
        if(TryGetComponent<TargetBehaviour>(out TargetBehaviour target))
        {
            target.hit(damage);
        }
        Destroy(gameObject);
    }
}
