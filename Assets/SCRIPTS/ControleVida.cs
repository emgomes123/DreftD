using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVida : MonoBehaviour
{
    public GameObject vida1, vida2, vida3;
    public static int vida;

    void Start()
    {
        vida = 3;
        vida1.gameObject.SetActive(true);
        vida2.gameObject.SetActive(true);
        vida3.gameObject.SetActive(true);
    }

    void Update()
    {
        if (vida > 3)
            vida = 3;

        switch (vida)
        {
            case 3:
                vida1.gameObject.SetActive(true);
                vida2.gameObject.SetActive(true);
                vida3.gameObject.SetActive(true);
                break;
            case 2:
                vida1.gameObject.SetActive(true);
                vida2.gameObject.SetActive(true);
                vida3.gameObject.SetActive(false);
                break;
            case 1:
                vida1.gameObject.SetActive(true);
                vida2.gameObject.SetActive(false);
                vida3.gameObject.SetActive(false);
                break;
            case 0:
                vida1.gameObject.SetActive(false);
                vida2.gameObject.SetActive(false);
                vida3.gameObject.SetActive(false);
                break;

        }
    }
}
