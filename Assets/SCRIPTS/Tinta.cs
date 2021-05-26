using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinta : MonoBehaviour
{
       
    public GameObject Player;
    public float Vida2;

    void Update()
    {
        Vida2 = Player.GetComponent<WalkJumpFire>().vida;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Vida2++;
            Destroy(gameObject);
            Debug.Log("tvida + 25");
        }
    }
}
