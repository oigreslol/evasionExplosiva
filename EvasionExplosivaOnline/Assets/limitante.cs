using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundery
{
    public float xMin, xMax, zMin, zMax;
}

public class limitante : MonoBehaviour {



    public Boundery boundery;
    public Rigidbody personaje;

	void Start () {
        personaje = GetComponent<Rigidbody>();
	}


    void FixedUpdate()
    {
        Vector3 pos = personaje.position;
        Debug.Log("Posicion personaje: " + pos);

        pos.x = Mathf.Clamp(pos.x, -0.013f, 0.1f);
        Debug.Log("Poscion en x" + pos.x);
        pos.y = Mathf.Clamp(pos.y, 0.2f, 0.3f);
        Debug.Log("Posicion en y " + pos.y);
        pos.z = Mathf.Clamp(pos.z, 0.2f, 0.3f);
        Debug.Log("Posicion en z "+ pos.z);
        personaje.position = pos;
    }
}
