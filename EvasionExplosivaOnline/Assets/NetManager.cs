using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetManager : Photon.MonoBehaviour {

    public Text estadoConexion;
    [SerializeField] private Transform[] spawnEquipoRojo;
    [SerializeField] private Transform[] spawnEquipoAzul;
    public bool balonesCreados = false;
    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("Evasion Explosiva Online 1.0");
        GameObject spawnAzul = GameObject.FindGameObjectWithTag("SpawnAzul");
        GameObject spawnRojo = GameObject.FindGameObjectWithTag("SpawnRojo");

        this.spawnEquipoAzul = new Transform[spawnAzul.transform.childCount];
        this.spawnEquipoRojo = new Transform[spawnRojo.transform.childCount];

        for (int s = 0; s < spawnAzul.transform.childCount; s++) {
            this.spawnEquipoAzul[s] = spawnAzul.transform.GetChild(s);
        }
        for (int v = 0; v < spawnAzul.transform.childCount; v++)
        {
            this.spawnEquipoRojo[v] = spawnRojo.transform.GetChild(v);
        }
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Estadio1", new RoomOptions { maxPlayers = 10 }, null);   
    }

    void OnJoinedLobby() {
        OnConnectedToMaster();
    }

    void OnJoinedRoom() {

        Vector3 posicion;

        posicion = this.spawnEquipoRojo[Random.Range(0, this.spawnEquipoRojo.Length)].position;

        GameObject persona = PhotonNetwork.Instantiate("JugadorEquipoRojo" , posicion , Quaternion.identity,0);
        //persona.name = "persona" + Random.Range(1,6).ToString();
       /*     GameObject balon1 = GameObject.Find("Juego/Balones/balon1");
            GameObject balon2 = GameObject.Find("Juego/Balones/balon2");
            GameObject balon3 = GameObject.Find("Juego/Balones/balon3");
            GameObject balon4 = GameObject.Find("Juego/Balones/balon4");
            GameObject balon5 = GameObject.Find("Juego/Balones/balon5");
            PhotonNetwork.Instantiate("dodgeball", balon1.transform.position, balon1.transform.rotation, 0).transform.parent = GameObject.Find("Juego/Balones").transform;
            PhotonNetwork.Instantiate("dodgeball", balon2.transform.position, balon2.transform.rotation, 0).transform.parent = GameObject.Find("Juego/Balones").transform;
            PhotonNetwork.Instantiate("dodgeball", balon3.transform.position, balon3.transform.rotation, 0).transform.parent = GameObject.Find("Juego/Balones").transform;
            PhotonNetwork.Instantiate("dodgeball", balon4.transform.position, balon4.transform.rotation, 0).transform.parent = GameObject.Find("Juego/Balones").transform;
            PhotonNetwork.Instantiate("dodgeball", balon5.transform.position, balon5.transform.rotation, 0).transform.parent = GameObject.Find("Juego/Balones").transform;
            */
    }

	// Update is called once per frame
	void Update () {
        this.estadoConexion.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}
