
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D rb2d;
    private Animator animator;
   
    public float velocidadMovimiento = 5f;
  

    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        Vector2 mov = new Vector2(movimientoH, 0);
        GetComponent<Rigidbody2D>().velocity = mov * velocidadMovimiento;
       
    }

   
    }

    
