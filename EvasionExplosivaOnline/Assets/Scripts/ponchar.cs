using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponchar : MonoBehaviour
{

    public PhotonView pv;
    public bool esPonchado= false;
    public bool poderShield= false;

	void Start () {
        pv = GetComponent<PhotonView>();
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (poderShield == false)
        {
            if (other.tag == "Balon" && other.GetComponentInChildren<entrando>().puedePonchar == true && other.GetComponentInChildren<entrando>().fueLanzada == true && other.GetComponentInChildren<entrando>().tocoPiso == false)
            {
                if (other.GetComponent<Tirada>().lanzadaPor != transform.tag)
                {
                    pv.RPC("avisar", PhotonTargets.All);
                }
            }
        }
        else
        {
            Debug.Log("tienes poder ");
            if (other.tag == "Balon" && other.GetComponentInChildren<entrando>().puedePonchar == true && other.GetComponentInChildren<entrando>().fueLanzada == true && other.GetComponentInChildren<entrando>().tocoPiso == false)
            {
                other.GetComponentInChildren<entrando>().puedePonchar = false;
            }
        }
    }
    [PunRPC]
    void avisar() {
        GameObject.Find("Gradas/grada" + Random.Range(1,11));
        transform.position = GameObject.Find("Gradas/grada" + Random.Range(1, 11)).transform.position;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().setWalkSpeed(0);
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().setRunSpeed(0);
        this.esPonchado = true;
    }
}
