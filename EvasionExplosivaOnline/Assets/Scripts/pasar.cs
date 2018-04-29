using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasar : Photon.MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JugadorAzul")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z +1.5f);
        }
        if (other.tag == "JugadorRojo")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 1.5f);
        }
    }
}
