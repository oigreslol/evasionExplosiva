using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPlayer : MonoBehaviour {
    public bool listo = false;

    //@ Funcion que se encarga de controlar el jugador en la red
    void Start () {
        PhotonView pv = GetComponent<PhotonView>(); // obtengo los componentes de los cuales recibo datos
        if (pv.isMine) { // pregunto si esos datos son mios
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true; // Busco y habilito mis movimientos
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().setWalkSpeed(0);
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().setRunSpeed(0);
            GetComponent<CharacterController>().enabled = true; //Obtengo el controlador de mi personaje
            GetComponent<Rigidbody>().isKinematic = false; // le digo que yo no voy a ser estatico
            GameObject camera = GameObject.Find(transform.name + "/FirstPersonCharacter"); // Obtengo la camara de mi personaje
            if (camera != null) { // pregunto si tengo camara
                camera.GetComponent<Camera>().enabled = true;//Habilito mi metodo
            }
        }
	}

    private void Update()
    {
        if (listo == true)
        {
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().setWalkSpeed(5);
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().setRunSpeed(15);
            GetComponent<Medio>().enabled = true; // Habilito mi script de lanzar pelota
            listo = false;
        }
    }
}
