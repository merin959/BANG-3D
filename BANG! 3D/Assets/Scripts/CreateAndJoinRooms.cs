using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createIpnut;
    public InputField joinIpnut;
    public Text message;

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
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.MasterClient.NickName = "Kyle (0)";
            PhotonNetwork.LoadLevel("RoomScene");
            PhotonNetwork.CurrentRoom.MaxPlayers = 8;
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        if(returnCode == 32766) this.message.text = "Room with this name already exists.";// room already exists
        else this.message.text = returnCode + ": " + message + ".";
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        if (returnCode == 32758) this.message.text = "This room doesn't exist.";// room doesn't exist
        else if (returnCode == 32765) this.message.text = "This room is currently full.";// room is full
        else this.message.text = returnCode + ": " + message + ".";
    }
}
