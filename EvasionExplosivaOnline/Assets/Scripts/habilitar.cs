using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilitar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "balonCoger" || ( other.transform.parent != null  && other.transform.parent.transform.tag == "Balon"))
        {
            if (other.gameObject.GetComponent<entrando>().fueLanzada == true && other.gameObject.GetComponent<entrando>().tocoPiso == false)
            {
                other.gameObject.GetComponent<entrando>().puedePonchar = true;
            }
        }
    }
}
