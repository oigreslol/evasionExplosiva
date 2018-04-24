using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrando : Photon.MonoBehaviour
{

    public bool lanzado = false;
    public bool puedePonchar = false;
    public bool fueLanzada = false;
    public bool tocoPiso = false;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "JugadorAzul" || other.transform.tag == "JugadorRojo" )) {
            other.gameObject.GetComponent<Medio>().sePuedeCoger = true;
            other.gameObject.GetComponent<Medio>().nombreBalon = transform.parent.name;
            Debug.Log("opcion1");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<Medio>().sePuedeCoger = false;
        }
        }

}
