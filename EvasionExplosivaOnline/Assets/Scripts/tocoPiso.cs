using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocoPiso : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "piso" && ( GetComponentInChildren<entrando>().tocoPiso == false && GetComponentInChildren<entrando>().fueLanzada == true))
        {
            GetComponentInChildren<entrando>().tocoPiso = true;
            GetComponentInChildren<entrando>().puedePonchar = false;
        }
    }
}
