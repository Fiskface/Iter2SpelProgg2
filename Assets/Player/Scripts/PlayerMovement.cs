using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float speed = 2;
    public MousePosSO mousePos;

    private static readonly int aniMoving = Animator.StringToHash("Moving");

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FlipSprite();
    }

    private void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (direction != Vector2.zero)
        {
            animator.SetBool(aniMoving, true);
        }
        else
        {
            animator.SetBool(aniMoving, false);
        }
        direction *= speed;
        rigidbody2D.velocity = direction;
    }

    private void FlipSprite()
    {
        if (mousePos.mousePosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
