using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float horizontal;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
    }
}
