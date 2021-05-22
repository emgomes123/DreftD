using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estala : MonoBehaviour
{
    public Rigidbody2D rb;
    //float velocidade = 0f;
    public int contador;
    public int VelocidadeQueda;

    void Start()
    {
        contador = 0;
    }
    void Update()
    {
        if (contador >= 1)
        {
            //velocidade = 15f;
            //rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * velocidade);
            rb.gravityScale = VelocidadeQueda;
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
            contador++;

        if (Other.gameObject.CompareTag("armadilha"))
            Destroy(gameObject);
    }
}

