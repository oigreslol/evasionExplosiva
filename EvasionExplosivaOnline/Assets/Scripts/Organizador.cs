using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Organizador : MonoBehaviour
{
    [SerializeField] private GameObject[] personajesRojo;
    [SerializeField] private GameObject[] personajesAzul;
    [SerializeField] private CoolDown esperando;
    [SerializeField] private bool entraron = false;
    public bool listo = false;
    private int contador = 0;
    // Update is called once per frame
    void Update()
    {
        personajesRojo = GameObject.FindGameObjectsWithTag("JugadorRojo");

        personajesAzul = GameObject.FindGameObjectsWithTag("JugadorAzul");

        if (personajesRojo.Length == 1 && personajesAzul.Length == 1 && entraron == false)
        {
            esperando.coolDownTimer = 5;
            esperando.necesito = true;
            entraron = true;
        }
        if (esperando.listo == true && listo == false)
        {
            listo = true;
            esperando.listo = false;
            foreach (GameObject rojo in personajesRojo)
            {
                rojo.GetComponent<NetPlayer>().listo = true;
            }
            foreach (GameObject azul in personajesAzul)
            {
                azul.GetComponent<NetPlayer>().listo = true;
            }
        }
    }
}
