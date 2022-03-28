using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject roomPanel;
    public GameObject lobbyPanel;
    public Text roomName;
    public Text errorMessage;

    public RoomJoinButton roomJoinButtonPrefab;
    List<RoomJoinButton> roomButtonList = new List<RoomJoinButton>();
    public Transform contentObject;

    const float TIME_BETWEEN_UPDATES = 1.25f;
    float nextUpdateTime;

    List<PlayerName> playerNameList = new List<PlayerName>();
    public PlayerName playerNamePrefab;
    public Transform playerNameParent;

    public GameObject playButton;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length == 6)
        {
            foreach (char ch in roomInputField.text) { if (!char.IsLetterOrDigit(ch)) { errorMessage.text = "Code cannot contain any special characters."; return; } }

            errorMessage.text = "";
            PhotonNetwork.CreateRoom(roomInputField.text.ToUpper(), new RoomOptions() { MaxPlayers = 8 });
        }
        else
        {
            errorMessage.text = "Code needs to be 6 characters long.";
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room code: " + PhotonNetwork.CurrentRoom.Name;

        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            foreach (RoomJoinButton rjb in roomButtonList) Destroy(rjb.gameObject);
            roomButtonList.Clear();

            foreach (RoomInfo room in roomList)
            {
                RoomJoinButton newRoom = Instantiate(roomJoinButtonPrefab, contentObject);
                newRoom.SetRoomName(room.Name);
                roomButtonList.Add(newRoom);
            }

            nextUpdateTime += Time.time + TIME_BETWEEN_UPDATES;
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        if (returnCode == 32766) errorMessage.text = "Room with this name already exists.";// room already exists
        else errorMessage.text = returnCode + ": " + message + ".";
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        if (returnCode == 32758) errorMessage.text = "This room doesn't exist.";// room doesn't exist
        else if (returnCode == 32765) errorMessage.text = "This room is currently full.";// room is full
        else if (returnCode == 32764) errorMessage.text = "This room is currently closed.";// room is full
        else errorMessage.text = returnCode + ": " + message + ".";
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        lobbyPanel.SetActive(true);
        roomInputField.text = "";
        roomPanel.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void UpdatePlayerList()
    {
        foreach (PlayerName pn in playerNameList) Destroy(pn.gameObject);
        playerNameList.Clear();

        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerName newPlayer = Instantiate(playerNamePrefab, playerNameParent);
            newPlayer.SetPlayerInfo(player.Value);
            playerNameList.Add(newPlayer);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player newPlayer)
    {
        UpdatePlayerList();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 1 /*4*/) playButton.SetActive(true);
        else playButton.SetActive(false);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && lobbyPanel.activeSelf) OnClickCreate();
    }

    public void OnClickPlayButton()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("GameScene");
    }
}
