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

    public bool IsDragAndDropActive => dragAndDropObject != null;

    private Card tooltipObject;

    /*internal Player activePlayer;
    private int activePlayerIndex;*/
    private Player sheriff;

    public List<Player> players = new List<Player>(); 
    public List<Player> deadPlayers = new List<Player>(); 
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

    public Text InfoMessage;

    private float MAX_X = 97;
    private float MAX_Y = 50;

    private float MAX_X_IN_PLAY = 17.4f;
    private float MAX_Z_IN_PLAY = 28.5f;

    private int turnNumber;

    private List<Tuple<bool, Vector3>> playerUIPositions;

    private Card[] activeEfectCards = new Card[3] { null, null, null};

    private static string[] staticNicknames = new string[8] { "Daniel", "Joshua", "Wendy", "Alex", "Judy", "Antonio", "Gwen", "Peter" };

    private bool waitingForResponse;
    public bool WaitingForResponse
    {
        get { return waitingForResponse; }
        set { waitingForResponse = value; }
    }

    private void Start()
    {
        instance = this;
        waitingForResponse = false;
        SetUpDecks();
        CreatePlayers();
        StartGame();
    }

    private void Update()
    {
        HandleInput();
    }

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
        //Shuffle(cardDeck);
        Shuffle(highNoonDeck);
        Shuffle(fistfulDeck);
        Shuffle(wildWestDeck);
        Shuffle(lootDeck);
        Shuffle(characterDeck);
        //Shuffle(roleDeck);
    }

    public static List<Card> Shuffle(List<Card> deck)
    {
        Card tr = null;
        if (deck.First().CardName == "High Noon" || deck.First().CardName == "A Fistful of Cards" || deck.First().CardName == "Wild West Show") { tr = deck.First(); deck.RemoveAt(0); }

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

    private void CreatePlayers()
    {
        playerUIPositions = SetUpPlayerPositions(); 
        for (int i = 0; i < 8; i++)
        {
            characterDeck[players.Count].transform.localPosition = playerUIPositions[players.Count].Item2;
            Player newPlayerInfo = PhotonNetwork.Instantiate(PlayerInfo.name, GetUIPosition(characterDeck[players.Count].transform), Quaternion.identity, 0, new object[3] { playerUIPositions[players.Count].Item1, staticNicknames[i], players.Count }).GetComponent<Player>();
            players.Add(newPlayerInfo);
            if (newPlayerInfo.MainCharacter.CardName == "Greg Digger") Debug.Log("Gerg Digger in game");
            if (newPlayerInfo.MainCharacter.CardName == "Herb Hunter") Debug.Log("Herb Hunter in game");
            if (newPlayerInfo.MainCharacter.CardName == "Vulture Sam") Debug.Log("Vulture Sam in game");
        }

        for (int j = 40; j <= 70; j += 15)
        {
            lootDeck.First().transform.localPosition = new Vector3(j, 0, 0);
            lootDeck.First().FlipCard();
            lootDeckOnTable.Add(lootDeck.First());
            lootDeck.RemoveAt(0);
        }
    }

    private void StartGame()
    {
        foreach (Player _player in players)
        {
            for (int i = 0; i < (_player.MainCharacter.CardName == "Sean Mallory" ? 3 : _player.MaximumCardsInHand); i++)
            {
                _player.DrawCard(cardDeck.First());
            }
            _player.SetUpCardsInHand();
        }
        turnNumber = 1;
        foreach (Player pl in players) { if (pl.Role.CardName == "Sheriff") { sheriff = pl; break; } }
        TurnManager.instance.DoTurn(sheriff);
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

            if (dragAndDropObject == null)
            {
                Tooltip.instance.HideTooltip();
                tooltipObject = null;
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag") || TurnManager.instance.ActivePhase < 2) return;

                    dragAndDropObject = hit.collider.gameObject.GetComponent<Card>();
                    if (dragAndDropObject.CanBeMoved)
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
                    TurnManager.instance.ActivePlayer.RemoveCardFromHand(dragAndDropObject);
                    TurnManager.instance.ActivePlayer.RemoveCardFromPlay(dragAndDropObject);
                    dragAndDropObject.CanBeMoved = false;
                    if (TurnManager.instance.ActivePhase == 3) { dragAndDropObject = null; return; }
                    else if (TurnManager.instance.ActivePhase == 2 && (dragAndDropObject.CardName != "Beer" && dragAndDropObject.CardName != "Saloon" && dragAndDropObject.CardName != "Last Call" &&
                        dragAndDropObject.CardName != "Stagecoach" && dragAndDropObject.CardName != "Wells Fargo")) 
                        TargetingSystem.instance.ShowTarget(dragAndDropObject);
                    else CardDatabase.instance.GetCardEffect(dragAndDropObject, TurnManager.instance.ActivePlayer, null);
                }
                else if((dragAndDropObject.transform.localPosition.x < TurnManager.instance.ActivePlayer.Characters[0].transform.localPosition.x + MAX_X_IN_PLAY && dragAndDropObject.transform.localPosition.x > TurnManager.instance.ActivePlayer.Characters[0].transform.localPosition.x - MAX_X_IN_PLAY) &&
                    (TurnManager.instance.ActivePlayer.IsTopOrBottom ? dragAndDropObject.transform.localPosition.z < MAX_Z_IN_PLAY && dragAndDropObject.transform.localPosition.z > MAX_Z_IN_PLAY - 16 : dragAndDropObject.transform.localPosition.z > -MAX_Z_IN_PLAY && dragAndDropObject.transform.localPosition.z < MAX_Z_IN_PLAY + 16) &&
                    dragAndDropObject.EligibleDestination == "In front of a player" && TurnManager.instance.ActivePhase != 3)
                {
                    bool qqq = true;
                    foreach(Card c in TurnManager.instance.ActivePlayer.CardsInPlay)
                    {
                        if(dragAndDropObject.CardName == c.CardName)
                        {
                            InfoMessage.text = "You cannot have two cards with the same name in play.";
                            dragAndDropObject.transform.position = ddObjectPosition;
                            dragAndDropObject.transform.rotation = ddObjectRotation;
                            qqq = false;
                            break;
                        }
                    }
                    if (qqq)
                    {
                        TurnManager.instance.ActivePlayer.AddCardToPlay(dragAndDropObject);
                        dragAndDropObject.CanBeMoved = false;
                        TurnManager.instance.ActivePlayer.RemoveCardFromHand(dragAndDropObject);
                    }
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

        if(Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.T) && !TurnManager.instance.ActivePlayer.HasActivatedEasterEgg)
        {
            TurnManager.instance.ActivePlayer.DrawCard(cardDeck.Last());
            TurnManager.instance.ActivePlayer.HasActivatedEasterEgg = true;
            Debug.Log("Easter egg byl vykonán.");
        }
    }

    public void OnEndTurn(Player activePlayer)
    {
        foreach (Card c in activePlayer.CardsInHand) c.FlipCard();
        foreach (Card c in activePlayer.CardsInPlay) { c.EligibleDestination = "Discard deck"; c.CanBeMoved = true; }
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
        TurnManager.instance.DoTurn(activePlayer);
    }

    public void FlipEffectCards(List<Card> deck, int index)
    {
        if(deck.Count > 0)
        {
            if (turnNumber > 1 || index == 2)
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
        int x = 8;
        switch (x)
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


    internal void PlayerDied(Player playerWhoDied)
    {
        bool normal = true;
        foreach (Player pl in players)
        {
            switch (pl.MainCharacter.CardName)
            {
                case "Greg Digger":
                    {
                        pl.Lifes += 2;
                        break;
                    }
                case "Herb Hunter":
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            cardDeck.First().FlipCard();
                            pl.DrawCard(cardDeck.First());
                        }
                        break;
                    }
                case "Vulture Sam":
                    {
                        List<Card> cardsToRemove = new List<Card>();

                        for (int i = 0; i < playerWhoDied.CardsInHand.Count; i++)
                        {
                            Card c1 = playerWhoDied.CardsInHand[i];
                            pl.AddCardToHand(c1);
                            cardsToRemove.Add(c1);
                            c1.CanBeMoved = false;
                        }

                        cardsToRemove.ForEach(c => playerWhoDied.RemoveCardFromHand(c, false));
                        cardsToRemove.Clear();

                        for (int i = 0; i < playerWhoDied.CardsInPlay.Count; i++)
                        {
                            Card c2 = playerWhoDied.CardsInPlay[i];
                            pl.AddCardToHand(c2);
                            cardsToRemove.Add(c2);
                            c2.CanBeMoved = false;
                        }

                        cardsToRemove.ForEach(c => playerWhoDied.RemoveCardFromPlay(c, false));
                        normal = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        if (normal)
        {
            List<Card> cardsToRemove = new List<Card>();
            for (int i = 0; i < playerWhoDied.CardsInHand.Count; i++)
            {
                Card c1 = playerWhoDied.CardsInHand[i];
                discardDeck.Add(c1);
                cardsToRemove.Add(c1);
                c1.CanBeMoved = false;
                Vector3 newPosition = new Vector3(10, discardDeck.Count * 0.02f, 0);
                c1.transform.localPosition = newPosition;
                c1.transform.rotation = Quaternion.identity;
                c1.IsFlipped = true;
            }

            cardsToRemove.ForEach(c => playerWhoDied.RemoveCardFromHand(c, false));
            cardsToRemove.Clear();

            for (int i = 0; i < playerWhoDied.CardsInPlay.Count; i++)
            {
                Card c2 = playerWhoDied.CardsInHand[i];
                discardDeck.Add(c2);
                cardsToRemove.Add(c2);
                c2.CanBeMoved = false;
                Vector3 newPosition = new Vector3(10, discardDeck.Count * 0.02f, 0);
                c2.transform.localPosition = newPosition;
                c2.transform.rotation = Quaternion.identity;
                c2.IsFlipped = true;
            }
            cardsToRemove.ForEach(c => playerWhoDied.RemoveCardFromPlay(c, false));
        }


        InfoMessage.text = playerWhoDied.PlayerName + " (" + playerWhoDied.Role.CardName + ") died.";

        deadPlayers.Add(playerWhoDied);
        players.Remove(playerWhoDied);

        if(sheriff.Lifes <= 0)
        {
            int i = 1;
            InfoMessage.text = "Sheriff died. Outlaws (";
            foreach (Player pl in players)
            {
                if (pl.Role.CardName == "Outlaw" && i == 1) InfoMessage.text += pl.PlayerName;
                if (pl.Role.CardName == "Outlaw" && i > 1) InfoMessage.text += ", " + pl.PlayerName;
                i++;
            }
            InfoMessage.text += ") are the winners!";
        }

        int? x = 0;
        foreach (Player pl in players) if (pl.Role.CardName == "Outlaw" || pl.Role.CardName == "Renegade") x += pl.Lifes;
        if (x <= 0)
        {
            int j = 1;
            InfoMessage.text = "All outlaws and renegades died. Sheriff and deputies (";
            foreach (Player pl in players)
            {
                if ((pl.Role.CardName == "Sheriff" || pl.Role.CardName == "Deputy") && j == 1) InfoMessage.text += pl.PlayerName;
                if ((pl.Role.CardName == "Sheriff" || pl.Role.CardName == "Deputy") && j > 1) InfoMessage.text += ", " + pl.PlayerName;
                j++;
            }
            InfoMessage.text += ") are the winners!";
        }

        if (players.Count == 1 && players.First().Role.CardName == "Renegade")
        {
            InfoMessage.text = "All other players died. " + players.First().PlayerName + " is the winner.";
        }
    }

    public char? TestCard()
    {
        Card testedCard = cardDeck.First();
        testedCard.FlipCard();
        testedCard.transform.position = new Vector3(testedCard.transform.position.x, testedCard.transform.position.y + 0.1f, testedCard.transform.position.z);
        return activeEfectCards[0].CardName == "Curse" ? '♠' : (activeEfectCards[0].CardName == "Blessing" ? '♥' : (testedCard.PlayingCardColor));
    }
}
