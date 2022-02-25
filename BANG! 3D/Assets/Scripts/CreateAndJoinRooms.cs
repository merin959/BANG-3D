using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createIpnut;
    public InputField joinIpnut;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createIpnut.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinIpnut.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
