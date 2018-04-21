using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medio : MonoBehaviour
{
    public bool sePuedeCoger = false;
    private bool conBalon = false;
    public string nombreBalon;
    public Transform posicionBalon;
    public GameObject pelota;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && sePuedeCoger == true && conBalon == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Balon"  && hit.transform.name == nombreBalon)
                {

                    Debug.Log(transform.name);
                    posicionBalon = GameObject.Find(transform.name+ "/posicionAgarre").transform;
                    Debug.Log(transform.name);
                    
                    hit.transform.position = posicionBalon.position;
                    pelota = hit.transform.gameObject;
                    pelota.transform.parent = transform;
                    sePuedeCoger = false;
                    conBalon = true;
                    //hit.transform.GetComponent<Rigidbody>().useGravity = false;
                    //hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        if (conBalon == true) {
            if (Input.GetMouseButtonDown(0)) {
                pelota.transform.parent = GameObject.Find("Juego/Balones").transform;
                pelota.AddComponent<Rigidbody>();
                Vector3 pushDir = Camera.main.transform.position - pelota.transform.position;
                pelota.GetComponent<Rigidbody>().AddForce(pushDir.normalized * 9);
                conBalon = false;
            }
        }
        
    }

}
        
