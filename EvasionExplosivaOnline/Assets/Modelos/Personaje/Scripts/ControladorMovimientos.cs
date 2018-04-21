using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMovimientos : MonoBehaviour {

    public float radioDeRotacion = 360;
    public float velocidadMovimiento = 2;

    private Rigidbody personajeRB;
	void Start () {
        if (GetComponent<Rigidbody>())
        {
            personajeRB = GetComponent<Rigidbody>();
        }
        else {
            Debug.LogError("Debe ponerle un Rigidbody al objeto");
        }
	}
	
	// Update is called once per frame
	void Update () {
        float teclaMovimiento = Input.GetAxis("Vertical");
        float teclaRotacion = Input.GetAxis("Horizontal");         
         AplicarMovimiento(teclaMovimiento, teclaRotacion);

	}

    private void AplicarMovimiento(float movimiento, float rotacion)
    {
        Moverse(movimiento);
        Rotar(rotacion);
    }

    private void Moverse(float movimiento) {
        personajeRB.AddForce(transform.forward * movimiento * velocidadMovimiento, ForceMode.Force);
    }

    private void Rotar(float rotacion) {
        transform.Rotate(0,rotacion* radioDeRotacion * Time.deltaTime,0);
    }
}
