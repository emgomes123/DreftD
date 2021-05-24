using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformaquecai : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals(""))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 50f;
            rb.gravityScale = 0.5f;
        }
    }
}
