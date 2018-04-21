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

    // Update is called once per frame
    void FixedUpdate() {
        personaje.position = new Vector3(Mathf.Clamp(personaje.position.x, boundery.xMin, boundery.xMax), 0f, Mathf.Clamp(personaje.position.z, boundery.zMin, boundery.zMax));
	}
}
