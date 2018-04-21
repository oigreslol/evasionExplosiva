using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrando : MonoBehaviour {

    public bool lanzado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            other.gameObject.GetComponent<Medio>().sePuedeCoger = true;
            other.gameObject.GetComponent<Medio>().nombreBalon = transform.name;
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
