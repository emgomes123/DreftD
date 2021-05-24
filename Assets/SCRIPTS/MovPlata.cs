using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlata : MonoBehaviour
{
    public float velocidade = 3f;
    public Rigidbody2D rb;

    public float esquerda = -30f;
    public float direita = -10f;


    bool moverDireita = true;

    public void Update()
    {
        if (rb.position.x > direita)
        {
            moverDireita = false;
        }

        if (rb.position.x < esquerda)
        {
            moverDireita = true;
        }

        if (moverDireita)
        {
            rb.MovePosition(rb.position + Vector2.right * Time.fixedDeltaTime * velocidade);
        }
        else 
        {          
            rb.MovePosition(rb.position + Vector2.left * Time.fixedDeltaTime * velocidade);
        }

    }
   
}
