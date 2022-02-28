using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerHandler : MonoBehaviourPunCallbacks
{
    private List<GameObject> playersInfos;
    private List<Player> players;

    private void Start()
    {
        playersInfos = new List<GameObject>();
        players = new List<Player>();
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            GameObject x = PhotonNetwork.Instantiate("RoomPlayerName", new Vector2(0, 0), Quaternion.identity);
            x.transform.SetParent(transform, false);
            x.transform.localPosition = new Vector2(0, -(i - 1) * 100 + 100);
            playersInfos.Add(x);
        }
        transform.Find("Text").GetComponent<Text>().text += PhotonNetwork.CurrentRoom.Name + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
    }

    /*public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        var x = PhotonNetwork.Instantiate("RoomPlayerName", new Vector3(0, PhotonNetwork.CurrentRoom.PlayerCount * 100 - 100, 0), Quaternion.identity);
        x.transform.SetParent(canvas.transform);
        playersInfos.Add(x);
    }*/
}
