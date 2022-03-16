using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class PlayerHandler : MonoBehaviourPunCallbacks
{
    private List<GameObject> playersInfos;
    public GameObject RoomInfo;
    public GameObject PlayerInfoArea;
    public GameObject playerInfoPrefab;

    /*void UpdatePlayerList()
    {
        foreach (var x in playersInfos) Destroy(x);
        playersInfos.Clear();

        foreach(KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            var p = Instantiate(playerInfoPrefab, PlayerInfoArea.transform);
            playersInfos.Add(p);
        }
    }*/

    private void Awake()
    {
        PhotonNetwork.MasterClient.NickName = "Kyle (1)";
        playersInfos = new List<GameObject>();
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("UpdatePlayerList", RpcTarget.AllBuffered);
        //UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        newPlayer.NickName = "Kyle (" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
        //UpdatePlayerList();
        photonView.RPC("UpdatePlayerList", RpcTarget.AllBuffered);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        photonView.RPC("UpdatePlayerList", RpcTarget.AllBuffered);
        //UpdatePlayerList();
    }

    [PunRPC]
    void UpdatePlayerList()
    {
        foreach (var x in playersInfos) Destroy(x);
        playersInfos.Clear();

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            Debug.Log("Player " + i + ": " + PhotonNetwork.CurrentRoom.Players.ElementAt(i).Value.NickName);
            GameObject x = PhotonNetwork.Instantiate("RoomNamePlayer", new Vector2(0, 0), Quaternion.identity);
            x.GetComponent<Text>().text = "Player " + i + ": " + PhotonNetwork.CurrentRoom.Players.ElementAt(i).Value.NickName;//.Key.ToString();
            try
            {
                x.transform.SetParent(PlayerInfoArea.transform);
            }
            catch
            {
                Debug.Log("Spadlo to bráško");
            }
            x.transform.localPosition = new Vector2(0, 325 - i * 100);
            playersInfos.Add(x);
        }
        RoomInfo.GetComponent<Text>().text = "Current room: " + PhotonNetwork.CurrentRoom.Name + " (" + PhotonNetwork.CurrentRoom.PlayerCount + " players)";
    }

    private void UUpdatePlayerList()
    {
        int i = 0;
        foreach (var x in playersInfos) Destroy(x);
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            GameObject temp = PhotonNetwork.Instantiate("RoomNamePlayer", new Vector2(0, 0), Quaternion.identity);
            temp.transform.SetParent(PlayerInfoArea.transform);
            temp.GetComponent<Text>().text = "Player " + i + ": " + PhotonNetwork.CurrentRoom.Players.ElementAt(i).Value.NickName;
            temp.transform.localPosition = new Vector2(0, 325 - i * 100);
            playersInfos.Add(temp);
            i++;
        }
    }
}
