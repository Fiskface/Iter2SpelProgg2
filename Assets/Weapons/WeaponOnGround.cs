using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponOnGround : MonoBehaviour
{
    public GameObjectSO activeWeapon;

    private float timer;
    private BoxCollider2D bx;
    private WeaponBehaviour wb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Awake()
    {
        bx = GetComponent<BoxCollider2D>();
        wb = GetComponent<WeaponBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            LayerMask mask = LayerMask.GetMask("Map");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                Vector3.down, 0.3f, mask);
            
            timer -= Time.deltaTime;
            if (hit.collider == null)
                transform.position += 2 * Time.deltaTime * Vector3.down;
        }
    }

    private void OnEnable()
    {
        bx.enabled = true;
        wb.enabled = false;
        transform.up = Vector3.right;
    }

    private void OnDisable()
    {
        bx.enabled = false;
        wb.enabled = true;
    }

    public void DropWeapon()
    {
        transform.position = player.transform.position;
        timer = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && timer <= 0)
        {
            var previousWeapon = activeWeapon.gObject.GetComponent<WeaponOnGround>();
            previousWeapon.enabled = true;
            previousWeapon.DropWeapon();

            enabled = false;
        }
    }
}
