using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;

    [SerializeField] private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        direction *= speed;
        direction *= Time.deltaTime;
        transform.position = new Vector3(transform.position.x + direction.x, transform.position.y + direction.y);
    }
}
