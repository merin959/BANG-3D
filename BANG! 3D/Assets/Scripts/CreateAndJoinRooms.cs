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
        foreach(char ch in createIpnut.text)
        {
            if (!char.IsLetterOrDigit(ch)) return;
        }
        PhotonNetwork.CreateRoom(createIpnut.text.ToUpper());
    }

    public void JoinRoom()
    {
        foreach (char ch in joinIpnut.text)
        {
            if (!char.IsLetterOrDigit(ch)) return;
        }
        PhotonNetwork.JoinRoom(joinIpnut.text.ToUpper());
    }

    public override void OnJoinedRoom()
    {
        /*Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        Debug.Log(PhotonNetwork.CurrentRoom.Name);*/
        PhotonNetwork.LoadLevel("RoomScene");
    }
}
