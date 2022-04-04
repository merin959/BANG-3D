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
    public List<Card> lootDeckOnTable = new List<Card>();
    public List<Card> characterDeck = new List<Card>(); // 63
    public List<Card> roleDeck = new List<Card>();      // 9 (-1 - Shadow Renegate)
    public List<Card> gameRoleDeck = new List<Card>();

    private float MAX_X = 97;
    private float MAX_Y = 50;

    private float MAX_X_IN_PLAY = 17.4f;
    private float MAX_Z_IN_PLAY = 28.5f;

    private int turnNumber;

    private List<Tuple<bool, Vector3>> playerUIPositions;

    private Card[] activeEfectCards = new Card[3] { null, null, null};

    private void Start()
    {
        instance = this;
        if (PhotonNetwork.IsMasterClient) photonView.RPC("SetUpDecks", RpcTarget.MasterClient);
        if (PhotonNetwork.IsMasterClient) photonView.RPC("SetUpOthersDecks", RpcTarget.OthersBuffered);
        if (PhotonNetwork.IsMasterClient) photonView.RPC("CreatePlayers", RpcTarget.MasterClient);
        if (PhotonNetwork.IsMasterClient) photonView.RPC("StartGame", RpcTarget.MasterClient);
    }

    private void Update()
    {
        HandleInput();
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
                        Card newCard = PhotonNetwork.Instantiate(Card.name, new Vector3(95, 0, 0), Quaternion.identity, 0, cardInfoObject).GetComponent<Card>();
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
        Shuffle(cardDeck);
        Shuffle(highNoonDeck);
        Shuffle(fistfulDeck);
        Shuffle(wildWestDeck);
        Shuffle(lootDeck);
        Shuffle(characterDeck);
        Shuffle(roleDeck);
    }

    [PunRPC]
    public void SetUpOthersDecks()
    {
        for (int i = 0; i < GameArea.transform.childCount; i++)
        {
            Card c = GameArea.transform.GetChild(i).gameObject.GetComponent<Card>();
            switch (c.CardType)
            {
                case 0:
                    {
                        cardDeck.Add(c);
                        break;
                    }
                case 1:
                    {
                        highNoonDeck.Add(c);
                        break;
                    }
                case 2:
                    {
                        fistfulDeck.Add(c);
                        break;
                    }
                case 3:
                    {
                        wildWestDeck.Add(c);
                        break;
                    }
                case 4:
                    {
                        lootDeck.Add(c);
                        break;
                    }
                case 5:
                    {
                        characterDeck.Add(c);
                        break;
                    }
                case 6:
                    {
                        roleDeck.Add(c);
                        break;
                    }
            }
        }
    }

    public static List<Card> Shuffle(List<Card> deck)
    {
        Card tr = null;
        if (deck.First().CardName == "High Noon" || deck.First().CardName == "A Fistful of Cards" || deck.First().CardName == "Wild West Show") { tr = deck.First(); deck.RemoveAt(0); }
        if (deck.First().CardName == "Sheriff")
        {
            List<Card> tempRole = new List<Card>();
            for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++) tempRole.Add(deck[i]);
            deck = tempRole;
        }
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
        if(tr != null) deck.Add(tr);
        return deck;
    }

    [PunRPC]
    private void CreatePlayers()
    {
        playerUIPositions = SetUpPlayerPositions(); 
        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            characterDeck[players.Count].transform.localPosition = playerUIPositions[players.Count].Item2;//new Vector3(MAX_X, 0, player.Value.ActorNumber * 25 - 73);
            Player newPlayerInfo = PhotonNetwork.Instantiate(PlayerInfo.name, GetUIPosition(characterDeck[players.Count].transform), Quaternion.identity, 0, new object[3] { playerUIPositions[players.Count].Item1, player.Value.NickName, players.Count }).GetComponent<Player>();
            newPlayerInfo.photonView.TransferOwnership(player.Value);
            players.Add(newPlayerInfo);
        }

        for (int j = 40; j <= 70; j += 15)
        {
            lootDeck.First().transform.localPosition = new Vector3(j, 0, 0);
            lootDeck.First().FlipCard();
            lootDeckOnTable.Add(lootDeck.First());
            lootDeck.RemoveAt(0);
        }

        photonView.RPC("PreparePlayers", RpcTarget.All);
    }

    [PunRPC]
    private void PreparePlayers()
    {
        foreach (Player pl in players) { if (pl.Role.CardName == "Sheriff") sheriff = pl; break; }
        activePlayer = sheriff;
        turnNumber = 1;
    }

    [PunRPC]
    private void StartGame()
    {
        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            Player _player = players[player.Key - 1];
            for (int i = 0; i < (_player.MainCharacter.CardName == "Sean Mallory" ? 3 : _player.MaximumCardsInHand); i++)
            {
                Card drawnCard = cardDeck.First();
                drawnCard.ChangeOwner(player.Value);
                _player.DrawCard(cardDeck.First());
            }
            _player.SetUpCardsInHand();
        }
        TurnManager.instance.DoTurn(activePlayer);
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

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TargetingSystem.instance.IsActive) return;
            Photon.Realtime.Player x = null;
            bool toReturn = false;
            try
            {
                x = activePlayer.photonView.Owner;
            }
            catch { toReturn = true; }
            finally { if (x != PhotonNetwork.LocalPlayer) toReturn = true; }

            if (toReturn) return;

            if (dragAndDropObject == null)
            {
                Tooltip.instance.HideTooltip();
                tooltipObject = null;
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag") || TurnManager.instance.ActivePhase < 2) return;

                    dragAndDropObject = hit.collider.gameObject.GetComponent<Card>();
                    if (dragAndDropObject.CanBeMoved)//
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
                    (dragAndDropObject.EligibleDestination == "Discard deck" || TurnManager.instance.ActivePhase == 3))
                {
                    dragAndDropObject.transform.localPosition = new Vector3(10, discardDeck.Count * 0.02f, 0);
                    discardDeck.Add(dragAndDropObject);
                    activePlayer.RemoveCardFromHand(dragAndDropObject);
                    dragAndDropObject.CanBeMoved = false;
                    try
                    {
                        foreach (Player _player in players)
                        {
                            _player.photonView.RPC("SetUpCardsInHand", RpcTarget.AllBuffered);
                            _player.photonView.RPC("SetUpCardsInPlay", RpcTarget.AllBuffered);
                            _player.photonView.RPC("SetUpUI", RpcTarget.AllBuffered);
                        }
                    }
                    catch { }
                    if (TurnManager.instance.ActivePhase == 2) TargetingSystem.instance.ShowTarget(dragAndDropObject);
                }
                else if((dragAndDropObject.transform.localPosition.x < activePlayer.Characters[0].transform.localPosition.x + MAX_X_IN_PLAY && dragAndDropObject.transform.localPosition.x > activePlayer.Characters[0].transform.localPosition.x - MAX_X_IN_PLAY) &&
                    (activePlayer.IsTopOrBottom ? dragAndDropObject.transform.localPosition.z < MAX_Z_IN_PLAY && dragAndDropObject.transform.localPosition.z > MAX_Z_IN_PLAY - 16 : dragAndDropObject.transform.localPosition.z > -MAX_Z_IN_PLAY && dragAndDropObject.transform.localPosition.z < MAX_Z_IN_PLAY + 16) &&
                    dragAndDropObject.EligibleDestination == "In front of a player")
                {
                    discardDeck.Add(dragAndDropObject);
                    activePlayer.AddCardToPlay(dragAndDropObject);
                    dragAndDropObject.CanBeMoved = false;
                    activePlayer.RemoveCardFromHand(dragAndDropObject);
                    try
                    {
                        foreach (Player _player in players)
                        {
                            _player.photonView.RPC("SetUpCardsInHand", RpcTarget.AllBuffered);
                            _player.photonView.RPC("SetUpCardsInPlay", RpcTarget.AllBuffered);
                            _player.photonView.RPC("SetUpUI", RpcTarget.AllBuffered);
                        }
                    }
                    catch { }
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

        if (Input.GetMouseButtonDown(1) && !TargetingSystem.instance.IsActive && dragAndDropObject == null)
        {
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

        if(Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.T) && !players[PhotonNetwork.LocalPlayer.ActorNumber - 1].HasActivatedEasterEgg)
        {
            players[PhotonNetwork.LocalPlayer.ActorNumber - 1].DrawCard(cardDeck.Last());
            players[PhotonNetwork.LocalPlayer.ActorNumber - 1].HasActivatedEasterEgg = true;
            Debug.Log("Easter egg byl vykonán.");
        }
    }

    [PunRPC]
    public void OnEndTurn()
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
            FlipEffectCards(highNoonDeck, 0);
            FlipEffectCards(fistfulDeck, 1);
            //FlipEffectCards(wildWestDeck, 2);
        }
    }

    private void FlipEffectCards(List<Card> deck, int index)
    {
        if(deck.Count > 0)
        {
            if (turnNumber > 1)
            {
                try
                {
                    activeEfectCards[index].transform.localPosition = new Vector3(0, 0, 100);
                    Destroy(activeEfectCards[index]);
                }
                catch { }
                activeEfectCards[index] = deck.First();
                activeEfectCards[index].transform.localPosition = new Vector3(deck.First().transform.localPosition.x, 0.05f, deck.First().transform.localPosition.z);
                deck.Remove(activeEfectCards[index]);
                //její efekt
            }
            activeEfectCards[index].FlipCard();
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
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X / 2, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X / 2, 0.1f, -MAX_Y)));
                    break;
                }
            case 5:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(0, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 2 / 3, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 2 / 3, 0.1f, -MAX_Y)));
                    break;
                }
            case 6:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(0, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(0, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    break;
                }
            case 7:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X* 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(0, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y)));
                    break;
                }
            case 8:
                {
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 4 / 15, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(true, new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 4 / 5, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(MAX_X * 4 / 15, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 4 / 15, 0.1f, -MAX_Y)));
                    playerUIPositions.Add(Tuple.Create(false, new Vector3(-MAX_X * 4 / 5, 0.1f, -MAX_Y)));
                    break;
                }
        }

        return playerUIPositions;
    }
}
