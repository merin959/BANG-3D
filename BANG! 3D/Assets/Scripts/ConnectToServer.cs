using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;
    public Text errorMessage;

    public void OnClickConnect()
    {
        if(usernameInput.text.Length >= 3 && buttonText.text == "Connect")
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
        if (usernameInput.text.Length < 3) errorMessage.text = "Nickname needs to have at least 3 characters.";
    }

    public override void OnConnectedToMaster()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LobbyScene");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning($"Failed to connect: {cause}");
    }

    public void OnBackClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
        PhotonNetwork.Disconnect();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) OnClickConnect();
    }
}
