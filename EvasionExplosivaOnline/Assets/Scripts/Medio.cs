using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medio : Photon.MonoBehaviour
{
    //Objetos para lanzar
    [Header("Objetos")]
    public Transform posicionBalon; // La posicion donde va a ir la pelota
    public GameObject pelota; // La pelota que obtengo en mis manos
    PhotonView pv; // Controlador de los elementos que veo 
    public Camera camara; // Mi camara
    public string nombreBalon; // El nombre del balon el cual estoy alfrente

  
    //Estados necesarios para lanzar el balon
    [Header("Estados")]
    [SerializeField]private bool conBalon = false; // Variable que define si tengo un balon en mis manos
    public bool sePuedeCoger = false; // Variable que determina si puedo coger un balon o no
    [SerializeField] private int contador=0;


    private void Start()
    {
        pv = GetComponent<PhotonView>(); // Obtengo el controlador de lo que estoy observando
        if (this.pv.isMine) { // pregunto si es mio
            this.camara = GetComponentInChildren<Camera>(); // Me asigno a mi mismo la camara pero a otras maquinas no
        }
    }

    //@ Metodo que se ejecuta siempre que el objeto 
    void Update()
    {
        if (this.pv.isMine)// Pregunto si soy yo el que esta ejecutando el metodo
        {
            if (Input.GetMouseButtonDown(1) && sePuedeCoger == true && conBalon == false) // Si undo el click izquierdo y yo puedo coger un balon y no tengo ningun otro balon
            {
                 pv.RPC("CogerBalon", PhotonTargets.All);//Ejecuto el metodo de coger el balon en toda la red
            }
            if (conBalon == true) // Pregunto si tengo un balon en mi mano
            {
                if (Input.GetKey(KeyCode.Mouse0) && contador < 550) // Pregunto si le undo el click izquierdo
                {
                    contador += 10;
                }else if(contador > 10)
                { 
                    pv.RPC("darRigidbody", PhotonTargets.All,new object[] { pelota.GetComponent<PhotonView>().viewID, contador });//Transmito en toda la red el dar fisicas y ejercer fuerza
                    pelota.transform.GetComponent<Rigidbody>().useGravity = true; // le digo que el objeto usara la gravedad
                    conBalon = false; // Digo que ya no tengo balon
                    sePuedeCoger = false; // Digo que ahora puedo coger un balon
                    pelota.GetComponentInChildren<entrando>().lanzado = true; // Hago que el componente de la pelota indique que esta siendo lanzada
                    pelota.GetComponentInChildren<entrando>().fueLanzada = true; // Indicamos que fue lanzada
                    pelota.GetComponentInChildren<entrando>().tocoPiso = false; // Indicamos que no toco el piso por ser lanzada
                    pelota.GetComponentInChildren<BoxCollider>().enabled = true; // Activamos el box collider que nos permite coger el balon
                    pelota.GetComponent<Tirada>().lanzadaPor = transform.tag; // le decimos a la pelota quien fue que la tiro
                    pelota = null; // decimos que ya no tenemos una pelota 
                    nombreBalon = null; // volvemos vacio el nombre del balon que tengo
                    contador = 0;
                }
            }
        }
    }

    //@ Funcion que permite coger el balon y lo transmite en la red
    [PunRPC]
    void CogerBalon()
    {
        RaycastHit hit; // un hit que captura el RAycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // un punto en el espacio
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "balonCoger" && hit.transform.parent.transform.name == nombreBalon) // si estoy dentro del area y el balon que esta adelante de mi es el que etoy señalando
            {
                pv.RPC("eliminarRigidbody", PhotonTargets.All, hit.transform.gameObject.GetComponent<PhotonView>().viewID); // eliminamos el rigidbody en toda la red
                pv.RPC("moverBalon", PhotonTargets.All, hit.transform.GetComponent<PhotonView>().viewID);// movemos el balon a la posicion que debe ir
                conBalon = true; // indicacmos que tengo un balon
                sePuedeCoger = false; // decimos que nos e puede coger otro balon porque ya tenemos uno 
                pelota.GetComponentInChildren<entrando>().tocoPiso = false; // indico que como la cogi no toco el piso 
                pelota.GetComponentInChildren<entrando>().fueLanzada = false; // como la agarre no fue lanzada 
                pelota.GetComponentInChildren<entrando>().lanzado = false; // digo que no fue lanzado 
                pelota.GetComponentInChildren<entrando>().puedePonchar = false; // no puede ponchar 
                pelota.GetComponentInChildren<BoxCollider>().enabled = false; // desactivamos el box collider
            }
            if (hit.transform.tag == "Balon" && hit.transform.name == nombreBalon)
            {
                pv.RPC("eliminarRigidbody", PhotonTargets.All,hit.transform.gameObject.GetComponent<PhotonView>().viewID);
                pv.RPC("moverBalon", PhotonTargets.All, hit.transform.GetChild(0).GetComponent<PhotonView>().viewID);
                sePuedeCoger = false;
                conBalon = true;
                pelota.GetComponentInChildren<entrando>().tocoPiso = false;
                pelota.GetComponentInChildren<entrando>().fueLanzada = false;
                pelota.GetComponentInChildren<entrando>().lanzado = false;
                pelota.GetComponentInChildren<entrando>().puedePonchar = false;
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
    void eliminarRigidbody(int viewID)
    {
        if (PhotonView.Find(viewID).GetComponent<Rigidbody>())
        {
            PhotonView.Find(viewID).GetComponent<PhotonView>().ObservedComponents.Remove(GetComponent<PhotonRigidbodyView>());
            Destroy(PhotonView.Find(viewID).transform.GetComponent<PhotonRigidbodyView>());
            Destroy(PhotonView.Find(viewID).transform.GetComponent<Rigidbody>());
        }
    }

    [PunRPC]
    void darRigidbody(int viewID, int contador) {
        PhotonView.Find(viewID).transform.parent = null;
        PhotonView.Find(viewID).gameObject.AddComponent<Rigidbody>();
        PhotonView.Find(viewID).gameObject.AddComponent<PhotonRigidbodyView>();
        PhotonView.Find(viewID).GetComponent<PhotonView>().ObservedComponents[1] = PhotonView.Find(viewID).gameObject.GetComponent<PhotonRigidbodyView>();
        transform.GetComponent<PhotonView>().ObservedComponents[1] = PhotonView.Find(viewID).gameObject.GetComponent<PhotonRigidbodyView>();
        Vector3 direcccion = this.camara.transform.forward;
        PhotonView.Find(viewID).GetComponent<Rigidbody>().AddForce(direcccion * (contador*10), ForceMode.Force);
    }
}
        
