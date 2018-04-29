using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetManager : Photon.MonoBehaviour {

    [Header("Red")]
    [SerializeField] private Text estadoConexion;
    [SerializeField] private Ganador ganador;
    [SerializeField] private bool sePuede= true;
    [Header("Equipos")]
    public GameObject[] puestosEquipos;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("Evasion Explosiva Online 1.0"); // Conectamos al server diciendole que este es el nombre
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Estadio1", new RoomOptions { MaxPlayers = 10 }, null);   
    }

    void OnJoinedLobby() {
        OnConnectedToMaster();
    }

    void OnJoinedRoom()
    {
        Vector3 posicion;
        if (PhotonNetwork.playerList.Length % 2 == 0)
        {
            posicion = puestosEquipos[PhotonNetwork.playerList.Length].transform.position;
            GameObject jugadorAzul = PhotonNetwork.Instantiate("JugadorEquipoAzul", posicion, Quaternion.identity, 0);
            jugadorAzul.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else {
            posicion = puestosEquipos[PhotonNetwork.playerList.Length].transform.position;
            PhotonNetwork.Instantiate("JugadorEquipoRojo", posicion, Quaternion.identity, 0);
        }
      
    }
	void Update () {
        this.estadoConexion.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}
