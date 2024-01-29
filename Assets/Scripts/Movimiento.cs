using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    

    public float velMov = 25f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        Vector2 movi = new Vector2(movimientoH, 0);
        GetComponent<Rigidbody2D>().velocity = movi * velMov;
        walk(movimientoH);
    }

    private void walk(float movimientoH)
    {
        if (movimientoH != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        //body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        spriteRenderer.flipX = body.velocity.x < 0f;
    }
}



