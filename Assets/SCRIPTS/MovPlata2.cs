using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlata2 : MonoBehaviour
{
    public float velocidade = 3f;
    public Rigidbody2D rb;

    public float descer = 39f;
    public float subir = 65f;


    bool moverCima = true;

    public void Update()
    {
        if (rb.position.y > subir)
        {
            moverCima = false;
        }

        if (rb.position.y < descer)
        {
            moverCima = true;
        }

        if (moverCima)
        {
            rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * velocidade);
        }
        else
        {
            rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * velocidade);
        }

    }
}
