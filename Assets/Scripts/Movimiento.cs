using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spRd;
    private Animator animator;

    public float velMov = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        Vector2 movi = new Vector2(movimientoH, 0);
        GetComponent<Rigidbody2D>().velocity = movi * velMov;
        walk(movimientoH);
    }

    private void GiroHorizontal(float movimientoH)
    {
        if (movimientoH > 0)
        {
            spRd.flipX = false;
        }
        else if (movimientoH < 0)
        {
            spRd.flipY = true;
        }
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
}



