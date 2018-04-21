using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasar : MonoBehaviour {


  //  GameObject pelota;

    private void Start()
    {
        //pelota = transform.parent.gameObject;
       /// Debug.Log(pelota.transform.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balon") {

                Debug.Log("cambiando trigger");
                transform.parent.GetComponent<BoxCollider>().isTrigger = true;
                // other.gameObject.GetComponent<entrando>().lanzado = false;
        }
        else {
            transform.parent.GetComponent<BoxCollider>().isTrigger = false;
        }

    
    }
/*
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Balon" && other.gameObject.GetComponent<entrando>().lanzado == true)
        {
            other.gameObject.GetComponent<entrando>().lanzado = false;
        }
    }*/



}
