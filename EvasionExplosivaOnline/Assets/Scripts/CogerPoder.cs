using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerPoder : MonoBehaviour {
    public bool activo;
    [SerializeField] CoolDown coolDown;
    [SerializeField] Animator animador;
    public GameObject personaje;
    PhotonView pv;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JugadorRojo" || other.tag == "JugadorAzul") {
            if (this.transform.tag == "poder1") {
                other.transform.gameObject.GetComponent<ponchar>().poderShield = true;
                personaje = other.gameObject;
                activo = true;
                coolDown.coolDownTimer = 5;
                transform.GetComponent<BoxCollider>().enabled = false;
                transform.gameObject.GetComponent<Renderer>().enabled = false;
                animador = other.gameObject.GetComponentInChildren<Animator>();
                animador.SetBool("escudoActivado",true);
            }
            if (this.transform.tag == "poder2") {
                transform.GetComponent<BoxCollider>().enabled = false;
                transform.gameObject.GetComponent<Renderer>().enabled = false;
                Destroy(transform.gameObject);
            }
        }
    }

    private void Update()
    {
        if (activo) {
            if (coolDown.listo) {
                personaje.GetComponent<ponchar>().poderShield = false;
                activo = false;
                animador.SetBool("escudoActivado", false);
                Destroy(transform.gameObject);
            }
        }
    }
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if (pv.isMine)
        {
            animador = GetComponentInChildren<Animator>();
        }
    }
}
