using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agacharse : MonoBehaviour {

	public CharacterController personaje;
	public GameObject p;
	[SerializeField] private bool activado = false;

	void Start () {
		personaje = GetComponent<CharacterController>();
		p = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().gameObject;
	}
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("left ctrl")) {
			activado = true;
			personaje.height = 2.2f;
			p.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_RunSpeed = 3.0f;
			p.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_RunSpeed = 5.0f;
			p.transform.Rotate (Vector3.up, 50 * Time.deltaTime);
		} else if(activado = true) {
			activado = false;
			p.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_WalkSpeed = 5.0f;
			p.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_RunSpeed = 15.0f;
			personaje.height = 3.5f;
		}
	}
}
