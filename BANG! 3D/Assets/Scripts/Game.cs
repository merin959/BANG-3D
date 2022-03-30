using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Linq;

public class Game : MonoBehaviourPun
{
    public static Game instance;

    public GameObject Card;
    public GameObject GameArea;
    public GameObject PlayerInfo;

    public Camera GameCamera;

    private Card dragAndDropObject;
    private Vector3 ddObjectPosition;
    private Quaternion ddObjectRotation;

    private Card tooltipObject;

    internal Player activePlayer;
    private Player sheriff;

    public List<Player> players = new List<Player>();
    public List<Card> cardDeck = new List<Card>();      // 164
    public List<Card> discardDeck = new List<Card>();
    public List<Card> highNoonDeck = new List<Card>();  // 13
    public List<Card> fistfulDeck = new List<Card>();   // 15
    public List<Card> wildWestDeck = new List<Card>();  // 10
    public List<Card> lootDeck = new List<Card>();      // 24
    public List<Card> characterDeck = new List<Card>(); // 63
    public List<Card> roleDeck = new List<Card>();      // 9 (-1 - Shadow Renegate)
    public List<Card> gameRoleDeck = new List<Card>();

    private float MAX_X = 97;
    private float MAX_Y = 50;

    private float MAX_X_IN_PLAY = 17.4f;
    private float MAX_Z_IN_PLAY = 28.5f;

    private int turnNumber;

    private List<Tuple<bool, Vector3>> playerUIPositions;

    private int setUpIniciator;

    private void Start()
    {
        instance = this;
        setUpIniciator = 0;
        TurnManager.instance.EndTurn += OnEndTurn;
    }

    private void Update()
    {
        if (setUpIniciator == 0 && PhotonNetwork.IsMasterClient) { setUpIniciator++; photonView.RPC("SetUpDecks", RpcTarget.AllBuffered); }
        if (setUpIniciator == 2 && PhotonNetwork.IsMasterClient) { setUpIniciator++; photonView.RPC("CreatePlayers", RpcTarget.MasterClient); }
        //if (iTimer == 50 && PhotonNetwork.IsMasterClient) photonView.RPC("ShuffleDecks", RpcTarget.AllBuffered);

        //if (iTimer == 150) photonView.RPC("StartGame", RpcTarget.MasterClient);//) StartGame();
        HandleClick();
    }

    [PunRPC]
    private void SetUpDecks()
    {
        foreach (Tuple<int, Tuple<string, string, string>, Tuple<string, char?, int?>, int?, Tuple<int?, int?>, int?, int?> cardInfo in CardDatabase.instance.CardDatas)
        {
            string tempString = "";
            tempString += cardInfo.Item3.Item2 != null ? cardInfo.Item3.Item2 : '0';
            object[] cardInfoObject = new object[12] { cardInfo.Item1, cardInfo.Item2.Item1, cardInfo.Item2.Item2, cardInfo.Item2.Item3, cardInfo.Item3.Item1, tempString , cardInfo.Item3.Item3, cardInfo.Item4, cardInfo.Item5.Item1, cardInfo.Item5.Item2, cardInfo.Item6, cardInfo.Item7 };
            switch (cardInfo.Item1)
            {
                case 0:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(-10, 0, 0), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        newCard.FlipCard();
                        cardDeck.Add(newCard);
                        break;
                    }
                case 1:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(-55, 0, 0), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        newCard.FlipCard();
                        highNoonDeck.Add(newCard);
                        break;
                    }
                case 2:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(-75, 0, 0), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        newCard.FlipCard();
                        fistfulDeck.Add(newCard);
                        break;
                    }
                case 3:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(-95, 0, 0), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        newCard.FlipCard();
                        wildWestDeck.Add(newCard);
                        break;
                    }
                case 4:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(40, 0, 0), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        newCard.FlipCard();
                        lootDeck.Add(newCard);
                        break;
                    }
                case 5:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(-10, 0, 100), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        characterDeck.Add(newCard);
                        break;
                    }
                case 6:
                    {
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(10, 0, 100), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
                        roleDeck.Add(newCard);
                        break;
                    }
            }
        }
        setUpIniciator++;
    }

    public static List<Card> Shuffle(List<Card> deck)
    {
        System.Random r = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            var temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }

        return deck;
    }

    [PunRPC]
    private void CreatePlayers()
    {
        //List<Tuple<bool, Vector3>> playerUIPositions = SetUpPlayerPositions();
        /*foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            characterDeck[player.Value.ActorNumber - 1].transform.localPosition = SetUpPlayerPositions()[player.Value.ActorNumber - 1].Item2;//new Vector3(MAX_X, 0, player.Value.ActorNumber * 25 - 73);
            Player newPlayerInfo = PhotonNetwork.Instantiate(PlayerInfo.name, GetUIPosition(characterDeck[player.Value.ActorNumber - 1].transform), Quaternion.identity, 0, new object[3] {true, player.Value.ActorNumber - 1, player.Value.NickName }).GetComponent<Player>();
            players.Add(newPlayerInfo);
        }*/
        Debug.Log("Roles: " + roleDeck.Count);
        playerUIPositions = SetUpPlayerPositions(); 
        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            characterDeck[players.Count].transform.localPosition = playerUIPositions[players.Count].Item2;//new Vector3(MAX_X, 0, player.Value.ActorNumber * 25 - 73);
            Player newPlayerInfo = PhotonNetwork.Instantiate(PlayerInfo.name, GetUIPosition(characterDeck[players.Count].transform), Quaternion.identity, 0, new object[3] { playerUIPositions[players.Count].Item1, player.Value.NickName, players.Count }).GetComponent<Player>();
            newPlayerInfo.photonView.TransferOwnership(player.Value);
            players.Add(newPlayerInfo);
        }

        /*Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
        characterDeck[PhotonNetwork.LocalPlayer.ActorNumber - 1].transform.localPosition = new Vector3(100, 0, (PhotonNetwork.LocalPlayer.ActorNumber - 1) * 25 - MAX_Z_IN_PLAY);
        Player newPlayerInfo = PhotonNetwork.Instantiate(PlayerInfo.name, GetUIPosition(characterDeck[PhotonNetwork.LocalPlayer.ActorNumber - 1].transform), Quaternion.identity, 0, new object[5] { true, PhotonNetwork.LocalPlayer.ActorNumber - 1 , PhotonNetwork.LocalPlayer.ActorNumber + 10, PhotonNetwork.LocalPlayer.ActorNumber - 1, PhotonNetwork.LocalPlayer.NickName}).GetComponent<Player>();
        //players.Add(newPlayerInfo);
        characterDeck.RemoveAt(PhotonNetwork.LocalPlayer.ActorNumber + 10);
        characterDeck.RemoveAt(PhotonNetwork.LocalPlayer.ActorNumber - 1);
        roleDeck.RemoveAt(PhotonNetwork.LocalPlayer.ActorNumber - 1);
        Debug.Log("Player created");*/
        setUpIniciator++;
    }

    [PunRPC]
    private void StartGame()
    {
        foreach (Player pl in players)
        {
            for (int i = 0; i < pl.MaximumCardsInHand; i++)
            {
                pl.DrawCard(cardDeck[0]);
                cardDeck.RemoveAt(0);
            }
            pl.SetUpCardsInHand();

        }
        foreach (Player pl in players) if (pl.Role.CardName == "Sheriff") { sheriff = pl; break; }
        activePlayer = sheriff;
        turnNumber = 1;
        //TurnManager.instance.DoTurn(activePlayer);

    }

    internal RaycastHit CastRay()
    {
        Vector3 worldMousePositionFar = GameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GameCamera.farClipPlane));
        Vector3 worldMousePositionNear = GameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GameCamera.nearClipPlane));

        RaycastHit hit;
        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }

    internal Vector2 GetUIPosition(Transform tr)
    {
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.instance.GetComponent<RectTransform>(), GameCamera.WorldToScreenPoint(tr.position), null, out canvasPos);
        return canvasPos;
    }

    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dragAndDropObject == null)
            {
                Tooltip.instance.HideTooltip();
                tooltipObject = null;
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag")) return;

                    dragAndDropObject = hit.collider.gameObject.GetComponent<Card>();
                    if (dragAndDropObject.CanBeMoved && (activePlayer.CardsInHand.Contains(dragAndDropObject) || activePlayer.CardsInPlay.Contains(dragAndDropObject)))
                    {
                        if (dragAndDropObject.IsFlipped) { ddObjectPosition = dragAndDropObject.transform.position; ddObjectRotation = dragAndDropObject.transform.rotation; dragAndDropObject.transform.eulerAngles = new Vector3(0, 0, 0); dragAndDropObject.enabled = false; }
                        else dragAndDropObject = null;
                    }
                    else dragAndDropObject = null;
                }
            }
            else
            {
                dragAndDropObject.transform.position = new Vector3(dragAndDropObject.transform.position.x, dragAndDropObject.transform.position.y - 48, dragAndDropObject.transform.position.z);
                Vector3 worldPosition = GameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GameCamera.WorldToScreenPoint(dragAndDropObject.transform.position).z));
                if ((dragAndDropObject.transform.localPosition.x < 15 && dragAndDropObject.transform.localPosition.x > 5) &&
                    (dragAndDropObject.transform.localPosition.z < 10 && dragAndDropObject.transform.localPosition.z > -10) &&
                    dragAndDropObject.EligibleDestination == "Discard deck")
                {
                    dragAndDropObject.transform.localPosition = new Vector3(10, discardDeck.Count * 0.02f, 0);
                    discardDeck.Add(dragAndDropObject);
                    activePlayer.RemoveCardFromHand(dragAndDropObject);
                    float x = new System.Random().Next(0, 3000) / 1000f - 1.5f;
                    if (discardDeck.Count > 1) dragAndDropObject.transform.Rotate(new Vector3(0, x, 0));
                   ; TargetingSystem.instance.ShowTarget();
                }
                else if((dragAndDropObject.transform.localPosition.x < activePlayer.Characters[0].transform.localPosition.x + MAX_X_IN_PLAY && dragAndDropObject.transform.localPosition.x > activePlayer.Characters[0].transform.localPosition.x - MAX_X_IN_PLAY) &&
                    (activePlayer.IsTopOrBottom ? dragAndDropObject.transform.localPosition.z < MAX_Z_IN_PLAY && dragAndDropObject.transform.localPosition.z > MAX_Z_IN_PLAY - 16 : dragAndDropObject.transform.localPosition.z > -MAX_Z_IN_PLAY && dragAndDropObject.transform.localPosition.z < MAX_Z_IN_PLAY + 16) &&
                    dragAndDropObject.EligibleDestination == "In front of a player")
                {
                    discardDeck.Add(dragAndDropObject);
                    activePlayer.AddCardToPlay(dragAndDropObject);
                    activePlayer.RemoveCardFromHand(dragAndDropObject);
                }
                else
                {
                    dragAndDropObject.transform.position = ddObjectPosition;
                    dragAndDropObject.transform.rotation = ddObjectRotation;
                }

                dragAndDropObject = null;
            }
        }

        if (dragAndDropObject != null)
        {
            Vector3 worldPosition = GameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GameCamera.WorldToScreenPoint(dragAndDropObject.transform.position).z));
            dragAndDropObject.transform.position = new Vector3(worldPosition.x, -50, worldPosition.z); 
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (dragAndDropObject != null) return;
            if (tooltipObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag")) return;

                    tooltipObject = hit.collider.gameObject.GetComponent<Card>();
                    if (tooltipObject.IsFlipped) Tooltip.instance.ShowTooltip(tooltipObject.TooltipData);
                }
            }
            else
            {
                Tooltip.instance.HideTooltip();

                tooltipObject = null;
            }
        }

        if (tooltipObject != null)
        {
            RaycastHit hit = CastRay();
            try { var x = hit.collider.name; }
            catch
            {
                Tooltip.instance.HideTooltip();
                tooltipObject = null;
            }
        }
    }

    private void OnEndTurn(Player player)
    {
        try
        {
            activePlayer = players[players.FindIndex(a => a.Equals(activePlayer)) + 1];
        }
        catch
        {
            activePlayer = players[0];
        }
        if (activePlayer.Role.CardName == "Sheriff")
        {
            turnNumber++;
            FlipEffectCards(highNoonDeck);
            FlipEffectCards(fistfulDeck);
            FlipEffectCards(wildWestDeck);
        }
        TurnManager.instance.DoTurn(activePlayer);
    }

    private void FlipEffectCards(List<Card> deck)
    {
        if(deck.Count > 1)
        {
            if (turnNumber > 2)
            {
                deck[0].transform.localPosition = new Vector3(0, -5, 0);
                deck.RemoveAt(0);
            }
            deck[0].FlipCard();
        }
    }

    private List<Tuple<bool, Vector3>> SetUpPlayerPositions()
    {
        List<Tuple<bool, Vector3>> playerUIPositions = new List<Tuple<bool, Vector3>>();
        switch (PhotonNetwork.CurrentRoom.PlayerCount)
        {
            case 1:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(0, 0.1f, MAX_Y)));
                    break;
                }
            case 2:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(0, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(0, 0.1f, -MAX_Y)));
                    /*players[0].Characters[0].transform.localPosition = new Vector3(0, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(0, 0.1f, -MAX_Y);
                    players[0].IsTopOrBottom = true;
                    players[1].IsTopOrBottom = false;*/
                    break;
                }
            case 3:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X / 2, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X / 2, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(0, 0.1f, -MAX_Y)));
                    break;
                }
            case 4:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X / 2, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X / 2, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X / 2, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X / 2, 0.1f, -MAX_Y)));
                    /*players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X / 2, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(MAX_X / 2, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(-MAX_X / 2, 0.1f, -MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(MAX_X / 2, 0.1f, -MAX_Y);
                    players[0].IsTopOrBottom = true;
                    players[1].IsTopOrBottom = true;
                    players[2].IsTopOrBottom = false;
                    players[3].IsTopOrBottom = false;*/
                    break;
                }
            case 5:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(0, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 2 / 3, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 2 / 3, 0.1f, -MAX_Y)));
                    /*players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(0, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(-MAX_X * 2 / 3, 0.1f, -MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(MAX_X * 2 / 3, 0.1f, -MAX_Y);
                    players[0].IsTopOrBottom = true;
                    players[1].IsTopOrBottom = true;
                    players[2].IsTopOrBottom = true;
                    players[3].IsTopOrBottom = false;
                    players[4].IsTopOrBottom = false;*/
                    break;
                }
            case 6:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(0, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(0, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    /*players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(0, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(0, 0.1f, -MAX_Y);
                    players[5].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    players[0].IsTopOrBottom = true;
                    players[1].IsTopOrBottom = true;
                    players[2].IsTopOrBottom = true;
                    players[3].IsTopOrBottom = false;
                    players[4].IsTopOrBottom = false;
                    players[5].IsTopOrBottom = false;*/
                    break;
                }
            case 7:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X* 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(0, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    /*players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    players[5].Characters[0].transform.localPosition = new Vector3(0, 0.1f, -MAX_Y);
                    players[6].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    players[0].IsTopOrBottom = true;
                    players[1].IsTopOrBottom = true;
                    players[2].IsTopOrBottom = true;
                    players[3].IsTopOrBottom = true;
                    players[4].IsTopOrBottom = false;
                    players[5].IsTopOrBottom = false;
                    players[6].IsTopOrBottom = false;*/
                    break;
                }
            case 8:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 4 / 5, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 4 / 15, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 4 / 15, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 4 / 5, 0.1f, -MAX_Y)));
                    /*players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 5, 0.1f, -MAX_Y);
                    players[5].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 15, 0.1f, -MAX_Y);
                    players[6].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 15, 0.1f, -MAX_Y);
                    players[7].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 5, 0.1f, -MAX_Y);
                    players[0].IsTopOrBottom = true;
                    players[1].IsTopOrBottom = true;
                    players[2].IsTopOrBottom = true;
                    players[3].IsTopOrBottom = true;
                    players[4].IsTopOrBottom = false;
                    players[5].IsTopOrBottom = false;
                    players[6].IsTopOrBottom = false;
                    players[7].IsTopOrBottom = false;*/
                    break;
                }
        }

        return playerUIPositions;
    }
}
