using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorProjetil : MonoBehaviour
{

    public float EsperaCriar = 5f;
    public Rigidbody rb;
    public GameObject car;
    float ProximoTempoParaCriar = 0f;
    int contador;

    //void Start()
    //{
    //    contador = 0;
    //}

    void Update()
    {  
        
       if (ProximoTempoParaCriar <= Time.time)
       {
            ProximoTempoParaCriar = Time.time + EsperaCriar;
            Instantiate(car, rb.position, rb.rotation);
       }  
        //if (contador >= 1)
        //{
        //}
    }

    //void carro()
    //{
    //}

    //void OnTriggerEnter()
    //{     
    //        Debug.Log("Almentou");
    //        contador++;
    //}
    //void OnTriggerExit()
    //{      
    //        Debug.Log("deminuiu");
    //        contador--;
    //}
}
