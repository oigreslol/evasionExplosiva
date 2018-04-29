using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Ganador : MonoBehaviour {

    [SerializeField] private GameObject[] personajesRojo;
    [SerializeField] private GameObject[] personajesAzul;
    [SerializeField] private Organizador organizador;
    [SerializeField] private Text text;
    [SerializeField] private bool comprobador = false;
    [SerializeField] private bool equipos = false;
    [SerializeField] private int perdedoresAzul = 0;
    [SerializeField] private int perdedoresRojo = 0;
    [SerializeField] private CoolDown coolDown;
    PhotonView pv;

    // Use this for initialization
    void Start () {
        pv = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
        if (organizador.listo && comprobador == false && equipos == false)
        {
            personajesRojo = GameObject.FindGameObjectsWithTag("JugadorRojo");
            personajesAzul = GameObject.FindGameObjectsWithTag("JugadorAzul");
            comprobador = true;
            equipos = true;
        }
        if (comprobador == true)
        {
            foreach (GameObject rojo in personajesRojo)
            {
                if (rojo.GetComponent<ponchar>().esPonchado == true) {
                    perdedoresRojo++;
                }
                
            }
            foreach (GameObject azul in personajesAzul)
            {
                if (azul.GetComponent<ponchar>().esPonchado == true)
                {
                    perdedoresAzul++;
                }
            }
            if (perdedoresRojo == personajesRojo.Length)
            {
                text.text = "Ganó el equipo AZUL";
                coolDown.coolDownTimer = 5;
                coolDown.necesito = false;
                comprobador = false;
            }
            else if (perdedoresAzul == personajesAzul.Length) {
                text.text = "Ganó el equipo ROJO";
                coolDown.coolDownTimer = 5;
                coolDown.necesito = false;
                comprobador = false;
            }
        }
        if (coolDown.listo == true && comprobador == false && equipos == true) {
            //hacer algo
        }
    }
}
