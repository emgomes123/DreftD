using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambor : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forcaLacamento;

    public void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.up * forcaLacamento;
        }
    }

}
