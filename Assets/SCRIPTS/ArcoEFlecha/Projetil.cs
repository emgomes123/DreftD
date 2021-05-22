using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    public Rigidbody2D rb;
    float velocidade = 1f;

    void Start()
    {
        velocidade = Random.Range(10f, 20f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * Time.fixedDeltaTime * velocidade);
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (Other.gameObject.CompareTag("Plataformas"))
        {
            Destroy(gameObject);
        }

        //    if (Other.gameObject.CompareTag("carro"))
        //    {
        //        velocidade = 4f;
        //    }       
    }
}