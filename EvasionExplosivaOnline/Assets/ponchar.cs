using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponchar : MonoBehaviour
{

    public PhotonView pv;
	void Start () {
        pv = GetComponent<PhotonView>();
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balon" && other.GetComponentInChildren<entrando>().puedePonchar == true && other.GetComponentInChildren<entrando>().fueLanzada == true && other.GetComponentInChildren<entrando>().tocoPiso == false) {
            Debug.Log("Ponchado");
            transform.position = new Vector3(111,111,111);
        }
    }
}
