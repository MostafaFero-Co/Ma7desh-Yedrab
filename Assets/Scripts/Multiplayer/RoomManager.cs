using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;

    [Space]
    public Transform spawnPoints;
    void Start()
    {
        Debug.Log("Connecting..");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
    }
   public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("Test", null, null);
        Debug.Log("we are in the lobby");
           
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("we are in the room");
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoints.position, Quaternion.identity);
    }
}
