using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorPersonaje : MonoBehaviour {

    Animator anim;
    PhotonView pv;
	void Start () {
        pv = GetComponent<PhotonView>();
        if (this.pv.isMine) {
            anim = GetComponent<Animator>();
            anim.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (pv.isMine) {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                pv.RPC("caminar", PhotonTargets.All);

            }
            else if (Input.GetMouseButtonDown(0)) {
                pv.RPC("lanzar", PhotonTargets.All);
            }
            else
            {
                anim.SetBool("Parado", true);
                anim.SetBool("Caminando", false);
                anim.SetBool("Perder", false);
                anim.SetBool("Lanzar", false);
            }
        }
    }

    [PunRPC]
    void caminar() {
        this.anim.SetBool("Parado", false);
        this.anim.SetBool("Caminando", true);
        this.anim.SetBool("Perder", false);
        this.anim.SetBool("Lanzar", false);
    }

    [PunRPC]
    void lanzar() {
        this.anim.SetBool("Parado", false);
        this.anim.SetBool("Caminando", false);
        this.anim.SetBool("Perder", false);
        this.anim.SetBool("Lanzar", true);
    }
}
