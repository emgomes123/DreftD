using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinta : MonoBehaviour
{
    public GameObject LineDrawer;
    public float estamina2;

    void Update()
    {
        //estamina2 = LineDrawer.GetComponent<LineDrawer>().estamina;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            estamina2 = 25;
            //Destroy(gameObject);
            Debug.Log("tinta + 25");
        }
    }
}
