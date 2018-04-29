using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poderes : MonoBehaviour {

    public CoolDown coolDown;
    public Organizador organizador;
    private bool primera=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (organizador.listo && primera == false) {
            coolDown.listo = false;
            coolDown.coolDownTimer = Random.Range(5,30);
            primera = true;
        }
        if (coolDown.listo == true && primera == true) {

                if (Random.Range(0, 2) == 1)
                {
                    PhotonNetwork.InstantiateSceneObject("poder1", GameObject.Find("posicion" + Random.Range(1, 7)).transform.position, Quaternion.Euler(-90, 0, 0), 0, null);
                }
                else {
                    PhotonNetwork.InstantiateSceneObject("poder2", GameObject.Find("posicion" + Random.Range(1, 7)).transform.position, Quaternion.Euler(-90, 0, 0), 0, null);
                }
            primera = false;
        }
	}
}
