using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medio : Photon.MonoBehaviour
{
    [Header("Objetos")]
    public Transform posicionBalon;
    public GameObject pelota;
    PhotonView pv;
    public string nombreBalon;

    [Header("Estados")]
    [SerializeField]private bool conBalon = false;
    public bool sePuedeCoger = false;


    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }
    void Update()
    {
        
        if (this.pv.isMine)
        {
            if (Input.GetMouseButtonDown(1) && sePuedeCoger == true && conBalon == false)
            {
                 pv.RPC("CogerBalon", PhotonTargets.All);
               //CogerBalon();
                
            }
            if (conBalon == true)
            {
                //pv.RPC("LanzarBalon", PhotonTargets.All);
                LanzarBalon();
            }

       }
    }
    [PunRPC]
    void CogerBalon()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "balonCoger" && hit.transform.parent.transform.name == nombreBalon)
            {
                //posicionBalon = GameObject.Find(transform.name + "/posicionAgarre").transform;
                Debug.Log("Holaaa" + transform.name);
                if (hit.transform.parent.transform.GetComponent<Rigidbody>())
                 {
                     Destroy(hit.transform.GetComponent<Rigidbody>());
                 }
                Debug.Log("Estoooooo1" + hit.transform.name);
                pv.RPC("moverBalon", PhotonTargets.All, hit.transform.GetComponent<PhotonView>().viewID);
                //hit.transform.parent.transform.position = posicionBalon.position;
                //pelota = hit.transform.parent.transform.gameObject;
                //pelota.transform.parent = transform;
                sePuedeCoger = false;
                conBalon = true;
                pelota.GetComponentInChildren<entrando>().tocoPiso = false;
                pelota.GetComponentInChildren<entrando>().fueLanzada = false;
                pelota.GetComponentInChildren<entrando>().lanzado = false;
                pelota.GetComponentInChildren<entrando>().puedePonchar = false;
                //photonView.RPC("Update", PhotonTargets.All);
            }
            if (hit.transform.tag == "Balon" && hit.transform.name == nombreBalon)
            {
               // posicionBalon = GameObject.Find(transform.name + "/posicionAgarre").transform;
                Debug.Log(transform.name);
                  if (hit.transform.GetComponent<Rigidbody>())
                  {
                      Destroy(hit.transform.GetComponent<Rigidbody>());
                  }

                Debug.Log("Esto es lo que coge despues de quitarla" + hit.transform.GetChild(0).name);
                pv.RPC("moverBalon", PhotonTargets.All, hit.transform.GetChild(0).GetComponent<PhotonView>().viewID);
                //hit.transform.position = posicionBalon.position;
                // pelota = hit.transform.gameObject;
                //pelota.transform.parent = transform;
                sePuedeCoger = false;
                conBalon = true;
                pelota.GetComponentInChildren<entrando>().tocoPiso = false;
                pelota.GetComponentInChildren<entrando>().fueLanzada = false;
                pelota.GetComponentInChildren<entrando>().lanzado = false;
                pelota.GetComponentInChildren<entrando>().puedePonchar = false;
               // photonView.RPC("Update", PhotonTargets.All);
            }
        }
    }
    [PunRPC]
    void moverBalon(int viewID) {
        PhotonView.Find(viewID).transform.parent.transform.position = posicionBalon.position;
        pelota = PhotonView.Find(viewID).transform.parent.transform.gameObject;
        pelota.transform.parent = transform;
    }

    [PunRPC]
    void LanzarBalon()
    {
        if (Input.GetMouseButtonDown(0))
                {
                    pelota.transform.parent = null;
                    pelota.AddComponent<Rigidbody>();
                    Vector3 pushDir = Camera.main.transform.position;
                    pelota.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward* 2000);
                    conBalon = false;
                    sePuedeCoger = false;
                    pelota.GetComponentInChildren<entrando>().lanzado = true;
                    pelota.GetComponentInChildren<entrando>().fueLanzada = true;
                    pelota.GetComponentInChildren<entrando>().tocoPiso = false;
                    nombreBalon = null;
                    //pv.RPC("Medio",PhotonTargets.All);
                }
    }
}
        
