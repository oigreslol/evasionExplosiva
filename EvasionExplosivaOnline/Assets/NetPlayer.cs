using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonView pv = GetComponent<PhotonView>();
        if (pv.isMine) {
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GameObject camera = GameObject.Find(transform.name + "/FirstPersonCharacter");
            GetComponent<Medio>().enabled = true;
            GetComponent<ponchar>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
            if (camera != null) {
                camera.GetComponent<Camera>().enabled = true;
            }

        }
	}
	
}
