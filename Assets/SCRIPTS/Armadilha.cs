using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    public Rigidbody2D rb;
    float velocidade = 0f;
    public int limite = 86;
    public int contador;

    void Start()
    {
        contador = 0;
    }
    void Update()
    {
        if (contador >= 1)
        {
            velocidade = 3f;
            rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * velocidade);
        }

        if (contador <= 0)
        {
 
            rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * velocidade);
        }

        if (rb.position.y >= limite)
        {
            velocidade = 0f;
        }

        //if (rb.position.y <= -1)
        //{
        //    velocidade = 0f;
        //}
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        contador++;
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        contador--;
    }
}
