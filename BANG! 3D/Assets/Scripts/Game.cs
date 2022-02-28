using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Game : MonoBehaviour
{
    public static Game instance;

    public GameObject Card;
    public GameObject GameArea;
    public GameObject Player;

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
    int i;
    bool iIncreaser;

    private void Start()
    {
        i = 0;
        iIncreaser = true;
        instance = this;
        Screen.fullScreen = true;
        TurnManager.instance.EndTurn += OnEndTurn;
        //CreateDecks();
        //CreatePlayers(8);
        //StartGame();
    }

    private void Update()
    {
        if(iIncreaser) i++;
        if(i==50) CreateDecks();
        if(i==100) CreatePlayers(8);
        if(i==150) StartGame();
        if(i==200)
        {
            iIncreaser = false;
        }
        HandleClick();
    }
  
    private void CreateDecks()
    {
        //var x = PhotonNetwork.Instantiate(Card.name, new Vector3(0, 0, 0), Quaternion.identity);
        //for (int i = 0; i < 164; i++) cardDeck.Add(PhotonNetwork.Instantiate(Card.name, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Card>());
        for (int i = 0; i < 164; i++) cardDeck.Add(Instantiate(Card).GetComponent<Card>());
        for (int i = 0; i < 12; i++) highNoonDeck.Add(Instantiate(Card).GetComponent<Card>());
        for (int i = 0; i < 14; i++) fistfulDeck.Add(Instantiate(Card).GetComponent<Card>());
        for (int i = 0; i < 9; i++) wildWestDeck.Add(Instantiate(Card).GetComponent<Card>());
        for (int i = 0; i < 24; i++) lootDeck.Add(Instantiate(Card).GetComponent<Card>());
        for (int i = 0; i < 63; i++) characterDeck.Add(Instantiate(Card).GetComponent<Card>());
        for (int i = 0; i < 8; i++) roleDeck.Add(Instantiate(Card).GetComponent<Card>());
        SetUpPlayingDeck();
        SetUpHighNoonDeck();
        SetUpFistfulDeck();
        SetUpWildWestDeck();
        SetUpLootDeck();
        SetUpCharacterDeck();
        SetUpRolesDeck();
    }

    private void SetUpPlayingDeck()
    {
        System.Random r = new System.Random();
        cardDeck[0].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 0", "Deal 1 damage to a player in range.", "A", '♠', 0);
        cardDeck[1].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 1", "Deal 1 damage to a player in range.", "2", '♦', 0);
        cardDeck[2].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 2", "Deal 1 damage to a player in range.", "3", '♦', 0);
        cardDeck[3].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 3", "Deal 1 damage to a player in range.", "4", '♦', 0);
        cardDeck[4].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 4", "Deal 1 damage to a player in range.", "5", '♦', 0);
        cardDeck[5].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 5", "Deal 1 damage to a player in range.", "6", '♦', 0);
        cardDeck[6].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 6", "Deal 1 damage to a player in range.", "7", '♦', 0);
        cardDeck[7].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 7", "Deal 1 damage to a player in range.", "8", '♦', 0);
        cardDeck[8].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 8", "Deal 1 damage to a player in range.", "9", '♦', 0);
        cardDeck[9].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 9", "Deal 1 damage to a player in range.", "10", '♦', 0);
        cardDeck[10].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 10", "Deal 1 damage to a player in range.", "J", '♦', 0);
        cardDeck[11].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 11", "Deal 1 damage to a player in range.", "Q", '♦', 0);
        cardDeck[12].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 12", "Deal 1 damage to a player in range.", "K", '♦', 0);
        cardDeck[13].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 13", "Deal 1 damage to a player in range.", "A", '♦', 0);
        cardDeck[14].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 14", "Deal 1 damage to a player in range.", "2", '♣', 0);
        cardDeck[15].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 15", "Deal 1 damage to a player in range.", "3", '♣', 0);
        cardDeck[16].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 16", "Deal 1 damage to a player in range.", "4", '♣', 0);
        cardDeck[17].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 17", "Deal 1 damage to a player in range.", "5", '♣', 0);
        cardDeck[18].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 18", "Deal 1 damage to a player in range.", "6", '♣', 0);
        cardDeck[19].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 19", "Deal 1 damage to a player in range.", "7", '♣', 0);
        cardDeck[20].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 20", "Deal 1 damage to a player in range.", "8", '♣', 0);
        cardDeck[21].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 21", "Deal 1 damage to a player in range.", "9", '♣', 0);
        cardDeck[22].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 22", "Deal 1 damage to a player in range.", "Q", '♥', 0);
        cardDeck[23].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 23", "Deal 1 damage to a player in range.", "K", '♥', 0);
        cardDeck[24].SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 24", "Deal 1 damage to a player in range.", "A", '♥', 0);
        cardDeck[25].SetUpPlayingCard(0, "Barrel", "Textures/Vanilla/Playing cards/Barile 0", "When you are target of a BANG! effect, test a card, if it is ♥, then you are Missed!", "Q", '♠', 1);
        cardDeck[26].SetUpPlayingCard(0, "Barrel", "Textures/Vanilla/Playing cards/Barile 1", "When you are target of a BANG! effect, test a card, if it is ♥, then you are Missed!", "K", '♠', 1);
        cardDeck[27].SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 0", "Restore 1 life.", "6", '♥', 0);
        cardDeck[28].SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 1", "Restore 1 life.", "7", '♥', 0);
        cardDeck[29].SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 2", "Restore 1 life.", "8", '♥', 0);
        cardDeck[30].SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 3", "Restore 1 life.", "9", '♥', 0);
        cardDeck[31].SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 4", "Restore 1 life.", "10", '♥', 0);
        cardDeck[32].SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 5", "Restore 1 life.", "J", '♥', 0);
        cardDeck[33].SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 0", "Discard a card from any player.", "K", '♥', 0);
        cardDeck[34].SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 1", "Discard a card from any player.", "9", '♦', 0);
        cardDeck[35].SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 2", "Discard a card from any player.", "10", '♦', 0);
        cardDeck[36].SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 2", "Discard a card from any player.", "J", '♦', 0);
        cardDeck[37].SetUpPlayingCard(0, "Stagecoach", "Textures/Vanilla/Playing cards/Dilligenza 0", "Draw 2 cards.", "9", '♠', 0);
        cardDeck[38].SetUpPlayingCard(0, "Stagecoach", "Textures/Vanilla/Playing cards/Dilligenza 1", "Draw 2 cards.", "9", '♠', 0);
        cardDeck[39].SetUpPlayingCard(0, "Dynamite", "Textures/Vanilla/Playing cards/Dinamite", "Test a card, if it is 2♠ -> 9♠, lose 3 lifes and discard this. Else pass Dynamite to a player on your left.", "9", '♠', 1);
        cardDeck[40].SetUpPlayingCard(0, "Duel", "Textures/Vanilla/Playing cards/Duello 0", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "Q", '♦', 0);
        cardDeck[41].SetUpPlayingCard(0, "Duel", "Textures/Vanilla/Playing cards/Duello 1", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "J", '♠', 0);
        cardDeck[42].SetUpPlayingCard(0, "Duel", "Textures/Vanilla/Playing cards/Duello 2", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "10", '♠', 0);
        cardDeck[43].SetUpPlayingCard(0, "General Store", "Textures/Vanilla/Playing cards/Emporio 0", "Reveal one card for any player, each player draws one, going clockwise.", "9", '♣', 0);
        cardDeck[44].SetUpPlayingCard(0, "General Store", "Textures/Vanilla/Playing cards/Emporio 1", "Reveal one card for any player, each player draws one, going clockwise.", "Q", '♠', 0);
        cardDeck[45].SetUpPlayingCard(0, "Gattling", "Textures/Vanilla/Playing cards/Gattling", "Deal 1 damage to all other players.", "10", '♥', 0);
        cardDeck[46].SetUpPlayingCard(0, "Indians!", "Textures/Vanilla/Playing cards/Indiani 0", "All other players have to play a BANG! or lose 1 life.", "K", '♦', 0);
        cardDeck[47].SetUpPlayingCard(0, "Indians!", "Textures/Vanilla/Playing cards/Indiani 1", "All other players have to play a BANG! or lose 1 life.", "A", '♥', 0);
        cardDeck[48].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 0", "Cancel the effect of a card with BANG! symbol.", "10", '♣', 0);
        cardDeck[49].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 1", "Cancel the effect of a card with BANG! symbol.", "J", '♣', 0);
        cardDeck[50].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 2", "Cancel the effect of a card with BANG! symbol.", "Q", '♣', 0);
        cardDeck[51].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 3", "Cancel the effect of a card with BANG! symbol.", "K", '♣', 0);
        cardDeck[52].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 4", "Cancel the effect of a card with BANG! symbol.", "A", '♣', 0);
        cardDeck[53].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 5", "Cancel the effect of a card with BANG! symbol.", "2", '♠', 0);
        cardDeck[54].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 6", "Cancel the effect of a card with BANG! symbol.", "3", '♠', 0);
        cardDeck[55].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 7", "Cancel the effect of a card with BANG! symbol.", "4", '♠', 0);
        cardDeck[56].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 8", "Cancel the effect of a card with BANG! symbol.", "5", '♠', 0);
        cardDeck[57].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 9", "Cancel the effect of a card with BANG! symbol.", "6", '♠', 0);
        cardDeck[58].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 10", "Cancel the effect of a card with BANG! symbol.", "7", '♠', 0);
        cardDeck[59].SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 11", "Cancel the effect of a card with BANG! symbol.", "8", '♠', 0);
        cardDeck[60].SetUpPlayingCard(0, "Scope", "Textures/Vanilla/Playing cards/Mirino", "You view others with -1 distance.", "A", '♠', 1);
        cardDeck[61].SetUpPlayingCard(0, "Mustang", "Textures/Vanilla/Playing cards/Mustang 0", "Others view you with +1 distance.", "8", '♥', 1);
        cardDeck[62].SetUpPlayingCard(0, "Mustang", "Textures/Vanilla/Playing cards/Mustang 1", "Others view you with +1 distance.", "9", '♥', 1);
        cardDeck[63].SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 0", "Draw a card from a player at distance 1.", "J", '♥', 0);
        cardDeck[64].SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 1", "Draw a card from a player at distance 1.", "Q", '♥', 0);
        cardDeck[65].SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 2", "Draw a card from a player at distance 1.", "A", '♥', 0);
        cardDeck[66].SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 3", "Draw a card from a player at distance 1.", "8", '♦', 0);
        cardDeck[67].SetUpPlayingCard(0, "Jail", "Textures/Vanilla/Playing cards/Prigione 0", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "J", '♠', 1);
        cardDeck[68].SetUpPlayingCard(0, "Jail", "Textures/Vanilla/Playing cards/Prigione 1", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "10", '♠', 1);
        cardDeck[69].SetUpPlayingCard(0, "Jail", "Textures/Vanilla/Playing cards/Prigione 1", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "4", '♥', 1);
        cardDeck[70].SetUpPlayingCard(0, "Remington", "Textures/Vanilla/Playing cards/Remington", "Your shooting distance is 3.", "K", '♣', 1);
        cardDeck[71].SetUpPlayingCard(0, "Rev. Carabine", "Textures/Vanilla/Playing cards/Rev. Carabine", "Your shooting distance is 4.", "A", '♣', 1);
        cardDeck[72].SetUpPlayingCard(0, "Saloon", "Textures/Vanilla/Playing cards/Saloon", "Restore 1 life, then other players also restore 1 life.", "5", '♥', 0);
        cardDeck[73].SetUpPlayingCard(0, "Schofield", "Textures/Vanilla/Playing cards/Schofield 0", "Your shooting distance is 2.", "J", '♣', 1);
        cardDeck[74].SetUpPlayingCard(0, "Schofield", "Textures/Vanilla/Playing cards/Schofield 1", "Your shooting distance is 2.", "Q", '♣', 1);
        cardDeck[75].SetUpPlayingCard(0, "Schofield", "Textures/Vanilla/Playing cards/Schofield 2", "Your shooting distance is 2.", "K", '♠', 1);
        cardDeck[76].SetUpPlayingCard(0, "Volcanic", "Textures/Vanilla/Playing cards/Volcanic 0", "Your shooting distance is 1, you can play any number of BANGs!", "10", '♠', 1);
        cardDeck[77].SetUpPlayingCard(0, "Volcanic", "Textures/Vanilla/Playing cards/Volcanic 0", "Your shooting distance is 1, you can play any number of BANGs!", "10", '♣', 1);
        cardDeck[78].SetUpPlayingCard(0, "Wells Fargo", "Textures/Vanilla/Playing cards/Wells Fargo", "Draw 3 cards.", "3", '♥', 0);
        cardDeck[79].SetUpPlayingCard(0, "Winchester", "Textures/Vanilla/Playing cards/Winchester", "Your shooting distance is 5.", "8", '♠', 1);
        cardDeck[80].SetUpADPlayingCard(0, "Ace up the Sleeve", "Textures/Armed & Dangerous/Playing cards/Asso nella Manica", "Spend 2 load tokens to draw a card.", "A", '♥', 3, 2);
        cardDeck[81].SetUpADPlayingCard(0, "Bandolier", "Textures/Armed & Dangerous/Playing cards/Bandoliera", "Spend 1 load token to be able to play one extra BANG! during this turn.", "2", '♥', 3, 1);
        cardDeck[82].SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 0", "Deal 1 damage to a player in range.", "6", '♥', 0);
        cardDeck[83].SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 1", "Deal 1 damage to a player in range.", "2", '♣', 0);
        cardDeck[84].SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 2", "Deal 1 damage to a player in range.", "2", '♦', 0);
        cardDeck[85].SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 3", "Deal 1 damage to a player in range.", "3", '♦', 0);
        cardDeck[86].SetUpADPlayingCard(0, "Big Fifty", "Textures/Armed & Dangerous/Playing cards/Big Fifty", "Your shooting distance is 6. After you play BANG!, you may spend 1 load token to cancel the targeted player's character ability and cards in play.", "Q", '♠', 3, 1);
        cardDeck[87].SetUpADPlayingCard(0, "Bomb", "Textures/Armed & Dangerous/Playing cards/Bomba", "Can be played on any player. At the start of your turn test a card. If it is ♥ or ♦, pass this to any player. If it is ♣ or ♠, spend two load tokens, if there aren't any on this card, lose 2 lifes and discard this.", "7", '♦', 3, 2);
        cardDeck[88].SetUpADPlayingCard(0, "Buntline Special", "Textures/Armed & Dangerous/Playing cards/Buntline Special", "Your shooting distance is 2. After you play BANG!, which gets cancelled, you may spend 1 load token force the target player to discard a card of their choice form their hand.", "J", '♠', 3, 1);
        cardDeck[89].SetUpADPlayingCard(0, "Bell Tower", "Textures/Armed & Dangerous/Playing cards/Campanile", "Spend 1 load token to see all players at distance 1 for the next card you play.", "7", '♣', 3, 1);
        cardDeck[90].SetUpADPlayingCard(0, "Caravan", "Textures/Armed & Dangerous/Playing cards/Carovana", "Draw 2 cards. Spend 2 load tokens from any of your cards to draw an additional card.", "2", '♠', 0, 2);
        cardDeck[91].SetUpADPlayingCard(0, "Crate", "Textures/Armed & Dangerous/Playing cards/Cassa", "Spend 2 load tokens to cancel the effect of a card with BANG! symbol.", "3", '♥', 3, 2);
        cardDeck[92].SetUpPlayingCard(0, "Cat Balou", "Textures/Armed & Dangerous/Playing cards/Cat Balou", "Discard a card from any player.", "3", '♥', 0);
        cardDeck[93].SetUpADPlayingCard(0, "Tumbleweed", "Textures/Armed & Dangerous/Playing cards/Cespuglio", "Spend 1 load token to force a player to repeat a test.", "4", '♣', 3, 1);
        cardDeck[94].SetUpADPlayingCard(0, "A Little Nip", "Textures/Armed & Dangerous/Playing cards/Cicchetto", "Restore 1 life. Spend 3 load tokens from any of your cards to restore an additional life.", "5", '♥', 0, 3);
        cardDeck[95].SetUpADPlayingCard(0, "Quick Shot", "Textures/Armed & Dangerous/Playing cards/Colpo Rapido", "Deal 1 damage to a player in range. Spend 1 load token from any of your cards to shoot an additional different player.", "3", '♠', 0, 1);
        cardDeck[96].SetUpADPlayingCard(0, "Double Barrel", "Textures/Armed & Dangerous/Playing cards/Doppia Canna", "Your shooting distance is 1. If your BANG! is ♦, you may spend 1 load token and it can't be cancelled.", "6", '♣', 3, 1);
        cardDeck[97].SetUpADPlayingCard(0, "Flintlock", "Textures/Armed & Dangerous/Playing cards/Flintlock", "Deal 1 damage to a player in range. Spend 1 load token, then if this is cancelled, take this back to your hand.", "A", '♠', 0, 2);
        cardDeck[98].SetUpADPlayingCard(0, "Arrow", "Textures/Armed & Dangerous/Playing cards/Freccia", "A target players discards a BANG! from their hand or loses 1 life. Spend 1 load token to target one additional differnet player.", "5", '♦', 3, 1);
        cardDeck[99].SetUpADPlayingCard(0, "Whip", "Textures/Armed & Dangerous/Playing cards/Frusta", "Spend 3 load tokens to discard any card in play.", "5", '♣', 3, 3);
        cardDeck[100].SetUpADPlayingCard(0, "Beer Keg ", "Textures/Armed & Dangerous/Playing cards/Fusto di Birra", "Spend 3 load tokens to restore 1 life.", "4", '♥', 3, 3);
        cardDeck[101].SetUpADPlayingCard(0, "Duck!", "Textures/Armed & Dangerous/Playing cards/Giù la Testa!", "Cancel the effect of a card with BANG! symbol. Spend 2 load tokens from any of your cards to add this card back to your hand.", "3", '♦', 3, 2);
        cardDeck[102].SetUpADPlayingCard(0, "Lock Pick", "Textures/Armed & Dangerous/Playing cards/Grimaldello", "Spend 3 load tokens to draw 1 card from the hand of any player.", "2", '♣', 3, 3);
        cardDeck[103].SetUpPlayingCard(0, "Missed!", "Textures/Armed & Dangerous/Playing cards/Mancato!", "Cancel the effect of a card with BANG! symbol.", "K", '♠', 0);
        cardDeck[104].SetUpPlayingCard(0, "Reloading", "Textures/Armed & Dangerous/Playing cards/Ricarica", "Add 3 load tokens to your cards and/or your character.", "4", '♦', 0);
        cardDeck[105].SetUpPlayingCard(0, "Rust", "Textures/Armed & Dangerous/Playing cards/Ruggine", "All other players move 1 load token from each orange card and their characters to your character.", "9", '♠', 0);
        cardDeck[106].SetUpADPlayingCard(0, "Squaw", "Textures/Armed & Dangerous/Playing cards/Squaw", "Discard any card from play. Spend 2 load tokens from any of your cards to add the discarded card to your hand.", "3", '♦', 0, 2);
        cardDeck[107].SetUpADPlayingCard(0, "Thunderer", "Textures/Armed & Dangerous/Playing cards/Thunderer", "Your shooting distance is 3. After you play BANG!, you may spend 1 load token to take the BANG! back to your hand.", "3", '♣', 3, 1);
        cardDeck[108].SetUpPlayingCard(0, "Bandidos", "Textures/The Valley of Shadows/Playing cards/Bandidos", "Each player chooses one: discard 2 cards from hand (1 if he only haas 1) or lose 1 life.", "Q", '♦', 0);
        cardDeck[109].SetUpPlayingCard(0, "Ghost", "Textures/The Valley of Shadows/Playing cards/Fantasma 0", "Play on any eliminated player. That player is back in the game, but cannot gain nor lose any lifes.", "9", '♠', 1);
        cardDeck[110].SetUpPlayingCard(0, "Ghost", "Textures/The Valley of Shadows/Playing cards/Fantasma 1", "Play on any eliminated player. That player is back in the game, but cannot gain nor lose any lifes.", "10", '♠', 1);
        cardDeck[111].SetUpPlayingCard(0, "Escape", "Textures/The Valley of Shadows/Playing cards/Fuga", "May be played out of turn. Avoid effects of a brown card (other than BANG!) that includes you as a target.", "3", '♥', 0);
        cardDeck[112].SetUpPlayingCard(0, "Lemat", "Textures/The Valley of Shadows/Playing cards/Lemat", "Your shooting distance is 1. During your turn, you may use any card in your hand as a BANG!.", "4", '♦', 1);
        cardDeck[113].SetUpPlayingCard(0, "Aim", "Textures/The Valley of Shadows/Playing cards/Mira", "Play this card together with BANG!. If the target is hit, he loses 2 lifes.", "6", '♣', 0);
        cardDeck[114].SetUpPlayingCard(0, "Poker", "Textures/The Valley of Shadows/Playing cards/Poker", "All other players discard 1 card from their hand at the same time. If no ace was discarded, you may draw up to 2 of those cards.", "J", '♥', 0);
        cardDeck[115].SetUpPlayingCard(0, "Backfire", "Textures/The Valley of Shadows/Playing cards/Ritorno di Fiamma", "Counts as Missed! The player who shot is the target of a BANG!.", "Q", '♣', 0);
        cardDeck[116].SetUpPlayingCard(0, "Saved!", "Textures/The Valley of Shadows/Playing cards/Salvo", "May be played out of turn. Prevent anther player from losing 1 life. If he survives, draw 2 cards from deck or from his hand.", "5", '♥', 0);
        cardDeck[117].SetUpPlayingCard(0, "Rattlesnake", "Textures/The Valley of Shadows/Playing cards/Serpente a Sonagli", "Play on any player. At the beginning of his turn, he tests. If it is ♠, he loses 1 life.", "7", '♥', 1);
        cardDeck[118].SetUpPlayingCard(0, "Shotgun", "Textures/The Valley of Shadows/Playing cards/Shotgun", "Your shooting distance is 1. Each time you hit a player, he must discard a card of his choice from his hand.", "K", '♠', 1);
        cardDeck[119].SetUpPlayingCard(0, "Fanning", "Textures/The Valley of Shadows/Playing cards/Sventagliata", "Counts as a normal one BANG! per turn. Also targets a player of your choice at distance 1 from the first target with a BANG!.", "2", '♠', 0);
        cardDeck[120].SetUpPlayingCard(0, "Bounty", "Textures/The Valley of Shadows/Playing cards/Taglia", "Play on any player. If that player is hit by a card with BANG! effect, the player who shot him draws 1 from the deck.", "9", '♣', 1);
        cardDeck[121].SetUpPlayingCard(0, "Tomahawk", "Textures/The Valley of Shadows/Playing cards/Tomahawk", "Deal 1 damage to a player at distance 2.", "A", '♦', 0);
        cardDeck[122].SetUpPlayingCard(0, "Tornado", "Textures/The Valley of Shadows/Playing cards/Tornado", "Each player discards any card from their hand (if possible), then draws 2.", "A", '♣', 0);
        cardDeck[123].SetUpPlayingCard(0, "Last Call", "Textures/The Valley of Shadows/Playing cards/Ultimo Giro", "Restore 1 life. Can be played with only 2 players remaining", "8", '♦', 0);
        cardDeck[124].SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 0", "Deal 1 damage to a player in range.", "8", '♠', 0);
        cardDeck[125].SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 1", "Deal 1 damage to a player in range.", "5", '♣', 0);
        cardDeck[126].SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 2", "Deal 1 damage to a player in range.", "6", '♣', 0);
        cardDeck[127].SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 3", "Deal 1 damage to a player in range.", "K", '♣', 0);
        cardDeck[128].SetUpPlayingCard(0, "Barrel", "Textures/Dodge City/Playing cards/Barile", "When you are target of a BANG!, test a card, if it is ♥, then you are Missed!", "A", '♣', 1);
        cardDeck[129].SetUpPlayingCard(0, "Bible", "Textures/Dodge City/Playing cards/Bibbia", "Cancel the effect of a card with BANG! symbol, then draw 1. Cannot be used this turn.", "10", '♥', 2);
        cardDeck[130].SetUpPlayingCard(0, "Binocular", "Textures/Dodge City/Playing cards/Binocolo", "You view others with -1 distance.", "10", '♦', 1);
        cardDeck[131].SetUpPlayingCard(0, "Beer", "Textures/Dodge City/Playing cards/Birra 0", "Restore 1 life.", "6", '♥', 0);
        cardDeck[132].SetUpPlayingCard(0, "Beer", "Textures/Dodge City/Playing cards/Birra 1", "Restore 1 life.", "6", '♠', 0);
        cardDeck[133].SetUpPlayingCard(0, "Canteen", "Textures/Dodge City/Playing cards/Borraccia", "Restore 1 life. Cannot be used this turn.", "7", '♥', 2);
        cardDeck[134].SetUpPlayingCard(0, "Can Can", "Textures/Dodge City/Playing cards/Can Can", "Discard a card from any player. Cannot be used this turn.", "J", '♣', 2);
        cardDeck[135].SetUpPlayingCard(0, "Ten Gallon Hat", "Textures/Dodge City/Playing cards/Cappello", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "J", '♦', 2);
        cardDeck[136].SetUpPlayingCard(0, "Cat Balou", "Textures/Dodge City/Playing cards/Cat Balou", "Discard a card from any player.", "8", '♣', 0);
        cardDeck[137].SetUpPlayingCard(0, "Conestoga", "Textures/Dodge City/Playing cards/Conestoga", "Draw a card from a player. Cannot be used this turn.", "9", '♦', 2);
        cardDeck[138].SetUpPlayingCard(0, "Derringer", "Textures/Dodge City/Playing cards/Derringer", "Deal 1 damage to a player at distance 1, then draw 1. Cannot be used this turn.", "7", '♠', 2);
        cardDeck[139].SetUpPlayingCard(0, "Dynamite", "Textures/Dodge City/Playing cards/Dinamite", "Deal 1 damage to a player at distance 1, then draw 1. Cannot be used this turn.", "10", '♣', 1);
        cardDeck[140].SetUpPlayingCard(0, "General Store", "Textures/Dodge City/Playing cards/Emporio", "Reveal one card for any player, each player draws one, going clockwise.", "10", '♠', 0);
        cardDeck[141].SetUpPlayingCard(0, "Buffalo Rifle", "Textures/Dodge City/Playing cards/Fucile da Caccia", "Deal 1 damage to any player. Cannot be used this turn.", "Q", '♣', 2);
        cardDeck[142].SetUpPlayingCard(0, "Howitzer", "Textures/Dodge City/Playing cards/Howitzer", "Deal 1 damage to all other players. Cannot be used this turn.", "9", '♠', 2);
        cardDeck[143].SetUpPlayingCard(0, "Indians!", "Textures/Dodge City/Playing cards/Indiani", "All other players have to play a BANG! or lose 1 life.", "5", '♦', 0);
        cardDeck[144].SetUpPlayingCard(0, "Missed!", "Textures/Dodge City/Playing cards/Mancato!", "Cancel the effect of a card with BANG! symbol.", "8", '♦', 0);
        cardDeck[145].SetUpPlayingCard(0, "Mustang", "Textures/Dodge City/Playing cards/Mustang", "Others view you with +1 distance.", "5", '♥', 1);
        cardDeck[146].SetUpPlayingCard(0, "Panic!", "Textures/Dodge City/Playing cards/Panico!", "Draw a card from a player at distance 1.", "J", '♥', 0);
        cardDeck[147].SetUpPlayingCard(0, "Pepperbox", "Textures/Dodge City/Playing cards/Pepperbox", "Deal 1 damage to a player in range. Cannot be used this turn.", "A", '♥', 2);
        cardDeck[148].SetUpPlayingCard(0, "Iron Plate", "Textures/Dodge City/Playing cards/Placca di Ferro 0", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "A", '♦', 2);
        cardDeck[149].SetUpPlayingCard(0, "Iron Plate", "Textures/Dodge City/Playing cards/Placca di Ferro 1", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "Q", '♠', 2);
        cardDeck[150].SetUpPlayingCard(0, "Pony Express", "Textures/Dodge City/Playing cards/Pony Express", "Draw 3 cards. Cannot be used this turn.", "Q", '♦', 2);
        cardDeck[151].SetUpPlayingCard(0, "Knife", "Textures/Dodge City/Playing cards/Pugnale", "Deal 1 damage to a player at distance 1. Cannot be used this turn.", "8", '♥', 2);
        cardDeck[152].SetUpPlayingCard(0, "Punch", "Textures/Dodge City/Playing cards/Pugno", "Deal 1 damage to a player at distance 1.", "10", '♠', 0);
        cardDeck[153].SetUpPlayingCard(0, "Rag Time", "Textures/Dodge City/Playing cards/Rag Time", "Play this card and discard any other card to draw a card from any player.", "9", '♥', 0);
        cardDeck[154].SetUpPlayingCard(0, "Remington", "Textures/Dodge City/Playing cards/Remington", "Your shooting distance is 3.", "6", '♦', 1);
        cardDeck[155].SetUpPlayingCard(0, "Rev. Carabine", "Textures/Dodge City/Playing cards/Rev. Carabine", "Your shooting distance is 4.", "5", '♠', 1);
        cardDeck[156].SetUpPlayingCard(0, "Hideout", "Textures/Dodge City/Playing cards/Riparo", "Others view you with +1 distance.", "K", '♦', 1);
        cardDeck[157].SetUpPlayingCard(0, "Brawl", "Textures/Dodge City/Playing cards/Rissa", "Play this card and discard any other card to discard a card from each player.", "J", '♠', 0);
        cardDeck[158].SetUpPlayingCard(0, "Dodge", "Textures/Dodge City/Playing cards/Schivata 0", "Cancel the effect of a card with BANG! symbol, then draw 1.", "7", '♦', 0);
        cardDeck[159].SetUpPlayingCard(0, "Dodge", "Textures/Dodge City/Playing cards/Schivata 1", "Cancel the effect of a card with BANG! symbol, then draw 1.", "K", '♥', 0);
        cardDeck[160].SetUpPlayingCard(0, "Sombrero", "Textures/Dodge City/Playing cards/Sombrero", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "7", '♣', 2);
        cardDeck[161].SetUpPlayingCard(0, "Springfield", "Textures/Dodge City/Playing cards/Springfield", "Play this card and discard any other card to deal 1 damage to any player.", "K", '♠', 0);
        cardDeck[162].SetUpPlayingCard(0, "Tequila", "Textures/Dodge City/Playing cards/Tequila", "Play this card and discard any other card to restore 1 life to any player (including yourself).", "9", '♣', 0);
        cardDeck[163].SetUpPlayingCard(0, "Whisky", "Textures/Dodge City/Playing cards/Whisky", "Play this card and discard any other card to restore 2 lifes.", "Q", '♥', 0);
        cardDeck = Shuffle(cardDeck);
        float i = 0.02f * cardDeck.Count;
        foreach (Card card in cardDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(-10, i, 0);
            i -= 0.02f;
        }
    }

    private void SetUpHighNoonDeck()
    {
        highNoonDeck[0].SetUpCard(1, "Blessing", "Textures/High Noon/Benedizione", "The suit of all cards is ♥.");
        highNoonDeck[1].SetUpCard(1, "Ghost Town", "Textures/High Noon/Città Fantasma", "During their turn, eliminated players return to the game as ghosts. In phase 1, they draw 3 cards and cannot die. At the end of their turn, they are eliminated again.");
        highNoonDeck[2].SetUpCard(1, "Gold Rush", "Textures/High Noon/Corsa all'Oro", "The game proceeds counter-clockwise for one round, starting with Sheriff. Effects proceed clockwise.");
        highNoonDeck[3].SetUpCard(1, "The Daltons", "Textures/High Noon/I Dalton", "When the Daltons enter play, each player who has any blue cards in front of him, chooses on of them and discards it.");
        highNoonDeck[4].SetUpCard(1, "The Doctor", "Textures/High Noon/Il Dottore", "When the Doctor enters play, the player or player still in the game with the least amount of lifes restore 1 life.");
        highNoonDeck[5].SetUpCard(1, "The Reverend", "Textures/High Noon/Il Reverendo", "Players cannot play Beer.");
        highNoonDeck[6].SetUpCard(1, "Train Arrival", "Textures/High Noon/Il Treno", "Each players draws 1 extra card at the end of phase 1 of his turn.");
        highNoonDeck[7].SetUpCard(1, "Curse", "Textures/High Noon/Maledizione", "The suit of all cards is ♠.");
        highNoonDeck[8].SetUpCard(1, "Hangover", "Textures/High Noon/Sbornia", "All character lose their effects.");
        highNoonDeck[9].SetUpCard(1, "The Sermon", "Textures/High Noon/Sermone", "Players cannot play BANG!.");
        highNoonDeck[10].SetUpCard(1, "Thirst", "Textures/High Noon/Sete", "Each player only draws 1 card in phase 1.");
        highNoonDeck[11].SetUpCard(1, "Shootout", "Textures/High Noon/Sparatoria", "Each player can play a second BANG! during his turn.");
        highNoonDeck = Shuffle(highNoonDeck);
        highNoonDeck.Add(Instantiate(Card).GetComponent<Card>());
        highNoonDeck[12].SetUpCard(1, "High Noon", "Textures/High Noon/Mezzogiorno di Fuoco", "Each player loses 1 life at the start of their turn.");
        float i = 0.02f * highNoonDeck.Count;
        foreach (Card card in highNoonDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(-55, i, 0);
            i -= 0.02f;
        }
    }

    private void SetUpFistfulDeck()
    {
        fistfulDeck[0].SetUpCard(2, "Ambush", "Textures/A Fistful of Cards/Agguato", "The distance between any two players is 1. This is modified only by cards in play.");
        fistfulDeck[1].SetUpCard(2, "Sniper", "Textures/A Fistful of Cards/Cecchino", "During your turn, the player may play 2 BANGs! together againts a player, this counts as a BANG! it may be cancelled only by 2 Missed! effects.");
        fistfulDeck[2].SetUpCard(2, "Dead Man", "Textures/A Fistful of Cards/Dead Man", "During his turn, the player who was eliminated first comes back to play with 2 lifes and 2 cards.");
        fistfulDeck[3].SetUpCard(2, "Blood Brothers", "Textures/A Fistful of Cards/Fratelli di Sangue", "At the beginning of his turn, each player may give one of his lifes (except the last one) to any other player.");
        fistfulDeck[4].SetUpCard(2, "The Judge", "Textures/A Fistful of Cards/Il Giudice", "You cannot play cards in front of you or any other player.");
        fistfulDeck[5].SetUpCard(2, "Lasso", "Textures/A Fistful of Cards/Lazo", "Cards in play in front of the players have no effect (excluding characters).");
        fistfulDeck[6].SetUpCard(2, "Law of the West", "Textures/A Fistful of Cards/Legge del West", "During his phase 1, each player shows the second card he draws. If he can, he must play it during his phase 2.");
        fistfulDeck[7].SetUpCard(2, "Hard Liquor", "Textures/A Fistful of Cards/Liquore Forte", "Each player may skip his phase 1 to restore 1 life.");
        fistfulDeck[8].SetUpCard(2, "Abandoned Mine", "Textures/A Fistful of Cards/Miniera Abbandonata", "During his phase 1, each player draws from the discard pile (if it runs out, the from the deck). In phase 3, he discards face down on the deck.");
        fistfulDeck[9].SetUpCard(2, "Peyote", "Textures/A Fistful of Cards/Peyote", "Instead of drawing in phase 1, each player guesses if the suit of the top card of the deck is red or black. He then draws and shows it; if he guessed right, he keeps it and guesses again; otherwise he proceeds to phase 2.");
        fistfulDeck[10].SetUpCard(2, "Ranch", "Textures/A Fistful of Cards/Ranch", "At the end of his phase 1, each player may discard once any number of cards from his hand to draw the same number of cards from the deck.");
        fistfulDeck[11].SetUpCard(2, "Rinochet", "Textures/A Fistful of Cards/Rimbalzo", "Each player may play BANG! againts a card in play in front of any player; the card is discarded if its owner doesn't play a Missed! effect.");
        fistfulDeck[12].SetUpCard(2, "Russian Roulette", "Textures/A Fistful of Cards/Roulette Russa", "When Russian Roulette enters play, starting from the Sheriff each player must discard Missed!, until one player doesn't; he loses 2 lifes and the Roulette ends.");
        fistfulDeck[13].SetUpCard(2, "Vendetta", "Textures/A Fistful of Cards/Vendetta", "At the end of his turn, each player tests. If it is ♥, he plays another turn (at the end of which he doesn't test for this again).");
        fistfulDeck = Shuffle(fistfulDeck);
        fistfulDeck.Add(Instantiate(Card).GetComponent<Card>());
        fistfulDeck[14].SetUpCard(2, "A Fistful of Cards", "Textures/A Fistful of Cards/Per un Ugno di Carte", "At the beginning of his turn, the player is target of as many BANGs! as the number of the cards in his hand.");
        float i = 0.02f * fistfulDeck.Count;
        foreach (Card card in fistfulDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(-75, i, 0);
            i -= 0.02f;
        }
    }

    private void SetUpWildWestDeck()
    {
        wildWestDeck[0].SetUpCard(3, "Ambush", "Textures/Wild West Show/WWS cards/Bavaglio", "Players cannot talk. Whoever talks, loses 1 life.");
        wildWestDeck[1].SetUpCard(3, "Bone Orchard", "Textures/Wild West Show/WWS cards/Camposanto", "At the start of their turn, each eliminated player returns to play with 1 life. Deal them roles at random from those of the eliminated players.");
        wildWestDeck[2].SetUpCard(3, "Darling Valentine", "Textures/Wild West Show/WWS cards/Darling Valentine", "At the start of his turn (before phase 1), each players discards his hand and draws the same number of cards.");
        wildWestDeck[3].SetUpCard(3, "Dorothy Rage", "Textures/Wild West Show/WWS cards/Dorothy Rage", "During his turn, each player can force another player to play one of his cards.");
        wildWestDeck[4].SetUpCard(3, "Helena Zontero", "Textures/Wild West Show/WWS cards/Helena Zontero", "When Helena comes into play, test. If it is ♥ or ♦, shuffle all active roles, except for Sheriff and, deal them at random.");
        wildWestDeck[5].SetUpCard(3, "Lady Rose of Texas", "Textures/Wild West Show/WWS cards/Lady Rosa del Texas", "During his turn, each player can swap places with the player on his right, who then skips his next turn.");
        wildWestDeck[6].SetUpCard(3, "Miss Susanna", "Textures/Wild West Show/WWS cards/Miss Susanna", "During phase 2, each player must play at least 3 cards. If he doesn't, he loses 1 life.");
        wildWestDeck[7].SetUpCard(3, "Showdown", "Textures/Wild West Show/WWS cards/Regolamento di Conti", "All cards may be played as they were BANG!. All BANGs! may be played as they were Missed!.");
        wildWestDeck[8].SetUpCard(3, "Sacagaway", "Textures/Wild West Show/WWS cards/Sacagaway", "All players play with their hands revealed.");
        wildWestDeck = Shuffle(wildWestDeck);
        wildWestDeck.Add(Instantiate(Card).GetComponent<Card>());
        wildWestDeck[9].SetUpCard(3, "Wild West Show", "Textures/Wild West Show/WWS cards/Wild West Show", "The goal of each player becomes: \"Be the last one in play!\"");
        float i = 0.02f * wildWestDeck.Count;
        foreach (Card card in wildWestDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(-95, i, 0);
            i -= 0.02f;
        }
    }

    private void SetUpLootDeck()
    {
        lootDeck[0].SetUpLootCard(4, "Shot", "Textures/Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", 1, 0);
        lootDeck[1].SetUpLootCard(4, "Shot", "Textures/Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", 1, 0);
        lootDeck[2].SetUpLootCard(4, "Shot", "Textures/Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", 1, 0);
        lootDeck[3].SetUpLootCard(4, "Bottle", "Textures/Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", 2, 0);
        lootDeck[4].SetUpLootCard(4, "Bottle", "Textures/Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", 2, 0);
        lootDeck[5].SetUpLootCard(4, "Bottle", "Textures/Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", 2, 0);
        lootDeck[6].SetUpLootCard(4, "Calumet", "Textures/Gold Rush/Loot cards/Calumet", "♦ cards played by other players have no effect on you.", 3, 1);
        lootDeck[7].SetUpLootCard(4, "Gun Belt", "Textures/Gold Rush/Loot cards/Cinturone", "Your hand size limit at the end of your turn is 8 cards.", 2, 1);
        lootDeck[8].SetUpLootCard(4, "Partner in Crime", "Textures/Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", 2, 0);
        lootDeck[9].SetUpLootCard(4, "Partner in Crime", "Textures/Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", 2, 0);
        lootDeck[10].SetUpLootCard(4, "Partner in Crime", "Textures/Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", 2, 0);
        lootDeck[11].SetUpLootCard(4, "Gold Rush", "Textures/Gold Rush/Loot cards/Corsa all'Oro", "Your turn ends. Restore all your lifes then play another turn.", 5, 0);
        lootDeck[12].SetUpLootCard(4, "Horseshoe", "Textures/Gold Rush/Loot cards/Ferro di Cavallo", "Your turn ends. Restore all your lifes then play another turn.", 2, 1);
        lootDeck[13].SetUpLootCard(4, "Pickaxe", "Textures/Gold Rush/Loot cards/Piccone", "During your phase 1 draw 1 additional card.", 4, 1);
        lootDeck[14].SetUpLootCard(4, "Wanted", "Textures/Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", 2, 1);
        lootDeck[15].SetUpLootCard(4, "Wanted", "Textures/Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", 2, 1);
        lootDeck[16].SetUpLootCard(4, "Wanted", "Textures/Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", 2, 1);
        lootDeck[17].SetUpLootCard(4, "Rhum", "Textures/Gold Rush/Loot cards/Rum", "Test 4 cards. Restore 1 life for each different suit.", 3, 0);
        lootDeck[18].SetUpLootCard(4, "Rhum", "Textures/Gold Rush/Loot cards/Rum", "Test 4 cards. Restore 1 life for each different suit.", 3, 0);
        lootDeck[19].SetUpLootCard(4, "Gold Pan", "Textures/Gold Rush/Loot cards/Setaccio", "Pay 1 golden nugget to draw 1. You may use this up to 2 times per turn.", 3, 1);
        lootDeck[20].SetUpLootCard(4, "Boots", "Textures/Gold Rush/Loot cards/Stivali", "Each time you lose a life, draw 1.", 3, 1);
        lootDeck[21].SetUpLootCard(4, "Lucky Charm", "Textures/Gold Rush/Loot cards/Talismano", "Each time you lose a life, take 1 golden nugget.", 3, 1);
        lootDeck[22].SetUpLootCard(4, "Union Pacific", "Textures/Gold Rush/Loot cards/Unoion Pacific", "Draw 4 cards.", 4, 0);
        lootDeck[23].SetUpLootCard(4, "Rucksack", "Textures/Gold Rush/Loot cards/Zaino", "Pay 2 golden nuggets to restore 1.", 3, 1);
        lootDeck = Shuffle(lootDeck);
        float i = 0.02f * lootDeck.Count;
        foreach (Card card in lootDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(40, i, 0);
            i -= 0.02f;
        }

        //dealing loot cards
        for (int j = 65; j <= 95; j += 15)
        {
            lootDeck[0].transform.localPosition = new Vector3(j, 0, 0);
            lootDeck[0].FlipCard();
            lootDeck.RemoveAt(0);
        }
    }

    private void SetUpCharacterDeck()
    {
        characterDeck[0].SetUpCharacterCard(5, "Bart Cassidy", "Textures/Vanilla/Characters/Bart Cassidy", "Each time he is hit, he draws a card.", 4);
        characterDeck[1].SetUpCharacterCard(5, "Black Jack", "Textures/Vanilla/Characters/Black Jack", "He shows the second card he draws in phase 1. ", 4);
        characterDeck[2].SetUpCharacterCard(5, "Calamity Janet", "Textures/Vanilla/Characters/Calamity Janet", "She may play BANG! as Missed! and vice versa.", 4);
        characterDeck[3].SetUpCharacterCard(5, "El Gringo", "Textures/Vanilla/Characters/El Gringo", "Each time he is hit by a player, he draws a card from the hand of that player.", 3);
        characterDeck[4].SetUpCharacterCard(5, "Jesse Jones", "Textures/Vanilla/Characters/Jesse Jones", "He may draw his first card from the hand of any player.", 4);
        characterDeck[5].SetUpCharacterCard(5, "Jourdonnais", "Textures/Vanilla/Characters/Jourdonnais", "Whenever he is a target of a BANG!, he may test a card, if it is ♥, then he is Missed!", 4);
        characterDeck[6].SetUpCharacterCard(5, "Kit Carlson", "Textures/Vanilla/Characters/Kit Carlson", "In phase 1, he looks on top three cards of the deck and chooses two to draw and discards the other one.", 4);
        characterDeck[7].SetUpCharacterCard(5, "Lucky Duke", "Textures/Vanilla/Characters/Lucky Duke", "Each time he tests, he flips the top two cards a chooses one.", 4);
        characterDeck[8].SetUpCharacterCard(5, "Paul Regret", "Textures/Vanilla/Characters/Paul Regret", "All others see him with +1 distance.", 3);
        characterDeck[9].SetUpCharacterCard(5, "Pedro Ramirez", "Textures/Vanilla/Characters/Pedro Ramirez", "In phase 1, he may draw his first card from the discard pile.", 4);
        characterDeck[10].SetUpCharacterCard(5, "Rose Doolan", "Textures/Vanilla/Characters/Rose Doolan", "She sees all players with -1 distance.", 4);
        characterDeck[11].SetUpCharacterCard(5, "Sid Ketchum", "Textures/Vanilla/Characters/Sid Ketchum", "He may discard two cards to restore 1 life.", 4);
        characterDeck[12].SetUpCharacterCard(5, "Slab the Killer", "Textures/Vanilla/Characters/Slab the Killer", "Players need 2 Missed! effects to cancel his BANG!.", 4);
        characterDeck[13].SetUpCharacterCard(5, "Suzy Lafayette", "Textures/Vanilla/Characters/Suzy Lafayette", "As soon as she has no cards in hand, she draws a card.", 4);
        characterDeck[14].SetUpCharacterCard(5, "Vulture Sam", "Textures/Vanilla/Characters/Vulture Sam", "Whenever a player is eliminated, he takes all the cards of that player to his hand.", 4);
        characterDeck[15].SetUpCharacterCard(5, "Willy the Kid", "Textures/Vanilla/Characters/Willy the Kid", "He can play any number of BANGs!.", 4);
        characterDeck[16].SetUpCharacterCard(5, "Al Preacher", "Textures/Armed & Dangerous/Characters/Al Preacher", "If another player plays blue or orange card, you may pay 2 load tokens to draw 1 card.", 4);
        characterDeck[17].SetUpCharacterCard(5, "Bass Greeves", "Textures/Armed & Dangerous/Characters/Bass Greeves", "Once during your turn, you may discard 1 card from your hand to add 2 load tokens to one of your cards.", 4);
        characterDeck[18].SetUpCharacterCard(5, "Bloody Mary", "Textures/Armed & Dangerous/Characters/Bloody Mary", "Each time your BANG! is cancelled, draw 1 card.", 4);
        characterDeck[19].SetUpCharacterCard(5, "Frankie Canton", "Textures/Armed & Dangerous/Characters/Frankie Canton", "Once during your turn, you may take 1 load token from any card and move it on this card.", 4);
        characterDeck[20].SetUpCharacterCard(5, "Julie Cutter", "Textures/Armed & Dangerous/Characters/Julie Cutter", "Each time a player makes you lose a life, test. If it is ♥ or ♦, they are target of a BANG!.", 4);
        characterDeck[21].SetUpCharacterCard(5, "Mexicali Kid", "Textures/Armed & Dangerous/Characters/Mexicali Kid", "Once during your turn, you may pay 2 load tokens to shoot 1 extra BANG! (no card required).", 4);
        characterDeck[22].SetUpCharacterCard(5, "Miss Abigail", "Textures/Armed & Dangerous/Characters/Miss Abigail", "You may ignore effects of brown cards with values J, Q, K and A if you are the only target.", 4);
        characterDeck[23].SetUpCharacterCard(5, "Red Ringo", "Textures/Armed & Dangerous/Characters/Red Ringo", "Starts with 4 load tokens. Once during your turn, you may move up to 2 load tokens from here to your cards.", 5);
        characterDeck[24].SetUpCharacterCard(5, "Apache Kid", "Textures/Dodge City/Characters/Apache Kid", "♦ cards played by other players don't effect him.", 3);
        characterDeck[25].SetUpCharacterCard(5, "Belle Star", "Textures/Dodge City/Characters/Belle Star", "During her turn, cards in play in front of other players have no effects.", 4);
        characterDeck[26].SetUpCharacterCard(5, "Bill Noface", "Textures/Dodge City/Characters/Bill Noface", "In phase 1, he draws 1 card, plus each wound he has.", 4);
        characterDeck[27].SetUpCharacterCard(5, "Chuck Wengam", "Textures/Dodge City/Characters/Chuck Wengam", "During his turn, he may choose to lose 1 life to draw 2 cards.", 4);
        characterDeck[28].SetUpCharacterCard(5, "Doc Holyday", "Textures/Dodge City/Characters/Doc Holyday", "During his turn, he may once discard 2 cards from his hand to shoot a BANG! to a player in range.", 4);
        characterDeck[29].SetUpCharacterCard(5, "Elena Fuente", "Textures/Dodge City/Characters/Elena Fuente", "She may use any card as Missed!.", 3);
        characterDeck[30].SetUpCharacterCard(5, "Greg Digger", "Textures/Dodge City/Characters/Greg Digger", "Each time another player is eliminated, he restores 2 lifes.", 4);
        characterDeck[31].SetUpCharacterCard(5, "Herb Hunter", "Textures/Dodge City/Characters/Herb Hunter", "Each time another player is eliminated, he draws 2 cards.", 4);
        characterDeck[32].SetUpCharacterCard(5, "José Delgado", "Textures/Dodge City/Characters/José Delgado", "Twice in his turn, he may discard a blue card form his hand to draw 2 cards.", 4);
        characterDeck[33].SetUpCharacterCard(5, "Molly Stark", "Textures/Dodge City/Characters/Molly Stark", "Each time she uses a card from hand out of her turn, she draws a card.", 4);
        characterDeck[34].SetUpCharacterCard(5, "Pat Brennan", "Textures/Dodge City/Characters/Pat Brennan", "In phase 1, instead of drawing from the deck, he may draw one card in play in front of any other player.", 4);
        characterDeck[35].SetUpCharacterCard(5, "Pixie Pete", "Textures/Dodge City/Characters/Pixie Pete", "In phase 1, he draws 3 cards instead of 2.", 3);
        characterDeck[36].SetUpCharacterCard(5, "Sean Mallory", "Textures/Dodge City/Characters/Sean Mallory", "He may hold up to 10 cards at the end of his turn.", 3);
        characterDeck[37].SetUpCharacterCard(5, "Tequila Joe", "Textures/Dodge City/Characters/Tequila Joe", "Each time he plays a Beer, he restores 2 lifes instead of 1.", 4);
        characterDeck[38].SetUpCharacterCard(5, "Vera Custer", "Textures/Dodge City/Characters/Vera Custer", "Before phase 1, she chooses another character in play and gains its effect until the start of her next turn.", 4);
        characterDeck[39].SetUpCharacterCard(5, "Don Bell", "Textures/Gold Rush/Characters/Don Bell", "At the end of his turn, he tests. If it is ♥ or ♦, he plays an extra turn (at the end of which he doesn't test for this again).", 4);
        characterDeck[40].SetUpCharacterCard(5, "Dutch Will", "Textures/Gold Rush/Characters/Dutch Will", "In phase 1, he draws 2 cards, chooses 1 to discards and takes 1 gold nugget.", 4);
        characterDeck[41].SetUpCharacterCard(5, "Jacky Murieta", "Textures/Gold Rush/Characters/Jacky Murieta", "During his turn, he may pay 2 gold nuggets to shoot 1 extra BANG! (no card required).", 4);
        characterDeck[42].SetUpCharacterCard(5, "Josh McCloud", "Textures/Gold Rush/Characters/Josh McCloud", "He may draw the top equipment from the equipment deck by paying 2 gold nuggets.", 4);
        characterDeck[43].SetUpCharacterCard(5, "Madame Yto", "Textures/Gold Rush/Characters/Madame Yto", "Each time a Beer is played, she draws 1.", 4);
        characterDeck[44].SetUpCharacterCard(5, "Pretty Luzena", "Textures/Gold Rush/Characters/Pretty Luzena", "Once per turn, she may buy 1 equipment at a cost reduced by 1 gold nugget.", 4);
        characterDeck[45].SetUpCharacterCard(5, "Raddie Snake", "Textures/Gold Rush/Characters/Raddie Snake", "Twice in his turn, he may pay 1 gold nugget to draw 1.", 4);
        characterDeck[46].SetUpCharacterCard(5, "Simeon Picos", "Textures/Gold Rush/Characters/Simeon Picos", "Each time he loses 1 life, he takes 1 gold nugget.", 4);
        characterDeck[47].SetUpCharacterCard(5, "Black Flower", "Textures/The Valley of Shadows/Characters/Black Flower", "Once during her turn, she may use any ♣ card as an extra BANG!.", 4);
        characterDeck[48].SetUpCharacterCard(5, "Colorado Bill", "Textures/The Valley of Shadows/Characters/Colorado Bill", "Each time he plays a BANG!, he tests. If it is ♠, it cannot be cancelled.", 4);
        characterDeck[49].SetUpCharacterCard(5, "Der Spot - Burst Ringer", "Textures/The Valley of Shadows/Characters/Der Spot", "Once during his turn, he may use a BANG! as a Gattling.", 4);
        characterDeck[50].SetUpCharacterCard(5, "Evelyn Shebang", "Textures/The Valley of Shadows/Characters/Evelyn Shabang", "She may skip phase 1. For each card skipped, she may shoot a BANG! at a different player in range.", 4);
        characterDeck[51].SetUpCharacterCard(5, "Henry Block", "Textures/The Valley of Shadows/Characters/Henry Block", "In player drawing or discarding on of his cards (in hand or in play) is a target of a BANG!.", 4);
        characterDeck[52].SetUpCharacterCard(5, "Lemonade Jim", "Textures/The Valley of Shadows/Characters/Lemonade Jim", "Each time another player plays Beer, he may discard any card from his hand to also restore 1 life.", 4);
        characterDeck[53].SetUpCharacterCard(5, "Mick Defender", "Textures/The Valley of Shadows/Characters/Mick Defender", "If he is a target of a brown card other than BANG!, he may use Missed! to avoid that card.", 4);
        characterDeck[54].SetUpCharacterCard(5, "Tuco Franziskaner", "Textures/The Valley of Shadows/Characters/Tuco Franziskaner", "In phase 1, if he has no blue cards in play, he may draw 2 extra cards.", 5);
        characterDeck[55].SetUpCharacterCard(5, "Big Spencer", "Textures/Wild West Show/Characters/Big Spencer", "Starts with 5 cards and cannot hold more than 5 cards at the end of his turn. He cannot play Missed!", 9);
        characterDeck[56].SetUpCharacterCard(5, "Flint Westwood", "Textures/Wild West Show/Characters/Flint Westwood", "During his turn, he may trade on card from hand with 2 cards at random from the hand of any other player.", 4);
        characterDeck[57].SetUpCharacterCard(5, "Gary Looter", "Textures/Wild West Show/Characters/Gary Looter", "He draws all excess cards discarded by other players at the end of their turn.", 5);
        characterDeck[58].SetUpCharacterCard(5, "Greygory Deck", "Textures/Wild West Show/Characters/Greygory Deck", "At the start of his turn, he may draw 2 characters at random. He has the abilities of those drawn characters.", 4);
        characterDeck[59].SetUpCharacterCard(5, "John Pain", "Textures/Wild West Show/Characters/John Pain", "If he has less than 6 cards in hand, each time any player tests, he will draw that card.", 4);
        characterDeck[60].SetUpCharacterCard(5, "Lee van Kliff", "Textures/Wild West Show/Characters/Lee van Klif", "During his turn, he may discard BANG! to repeat an effect of a brown card he just played.", 4);
        characterDeck[61].SetUpCharacterCard(5, "Teren Kill", "Textures/Wild West Show/Characters/Teren Kill", "Each time he would be eliminated, he tests. If it isn't ♠, he stays at 1 life and draws 1.", 3);
        characterDeck[62].SetUpCharacterCard(5, "Youl Grinner", "Textures/Wild West Show/Characters/Youl Grinner", "Before drawing in phase 1, players with more cards in hand than him must give him 1 card of their choice.", 4);
        characterDeck = Shuffle(characterDeck);
        float i = 0.02f * characterDeck.Count;
        foreach (Card card in characterDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(0, i, 100);
            i -= 0.02f;
        }
    }

    private void SetUpRolesDeck()
    {
        roleDeck[0].SetUpCard(6, "Sheriff", "Textures/Vanilla/Roles/Sceriffo", "Kill all Outlaws and Renegades!");
        roleDeck[1].SetUpCard(6, "Outlaw", "Textures/Vanilla/Roles/Fuorilegge", "Kill the Sheriff!");
        roleDeck[2].SetUpCard(6, "Renegade", "Textures/Vanilla/Roles/Rinnegato", "Be the last one in play!");
        roleDeck[3].SetUpCard(6, "Outlaw", "Textures/Vanilla/Roles/Fuorilegge", "Kill the Sheriff!");
        roleDeck[4].SetUpCard(6, "Deputy", "Textures/Vanilla/Roles/Vice", "Protect the Sheriff and kill all Outlaws and Renegades!");
        roleDeck[5].SetUpCard(6, "Outlaw", "Textures/Vanilla/Roles/Fuorilegge", "Kill the Sheriff!");
        roleDeck[6].SetUpCard(6, "Deputy", "Textures/Vanilla/Roles/Vice", "Protect the Sheriff and kill all Outlaws and Renegades!");
        roleDeck[7].SetUpCard(6, "Renegade", "Textures/Vanilla/Roles/Rinnegato", "Be the last one in play!");
        //shadow renegate
        //roleDeck = Shuffle(roleDeck);
        float i = 0.02f * roleDeck.Count;
        foreach (Card card in roleDeck)
        {
            card.FlipCard();
            card.transform.SetParent(GameArea.transform, false);
            card.transform.localPosition = new Vector3(20, i, 100);
            i -= 0.02f;
        }
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

    private void CreatePlayers(int numberOfPlayers)
    {
        for (int i = 0; i < numberOfPlayers; i++) players.Add(Instantiate(Player).GetComponent<Player>());

        for (int i = 0; i < numberOfPlayers; i++) gameRoleDeck.Add(roleDeck[i]);

        gameRoleDeck = Shuffle(gameRoleDeck);
        System.Random rand = new System.Random();
        int x = 0;
        foreach (Player player in players)
        {
            if (x >= players.Count / 2 + players.Count % 2) player.SetUpPlayerInfo(characterDeck[0], characterDeck[1], gameRoleDeck[0], false);
            else player.SetUpPlayerInfo(characterDeck[0], characterDeck[1], gameRoleDeck[0], true);
            player.transform.SetParent(Canvas.instance.transform.Find("PlayerAreas").transform);
            characterDeck[0].FlipCard();
            characterDeck.RemoveAt(0);
            characterDeck.RemoveAt(0);
            gameRoleDeck.RemoveAt(0);
            x++;
        }
        switch (players.Count)
        {
            case 4:
                {
                    players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X / 2, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(MAX_X / 2, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(-MAX_X / 2, 0.1f, -MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(MAX_X / 2, 0.1f, -MAX_Y);
                    break;
                }
            case 5:
                {
                    players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(0, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(-MAX_X * 2 / 3, 0.1f, -MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(MAX_X * 2 / 3, 0.1f, -MAX_Y);
                    break;
                }
            case 6:
                {
                    players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3/ 4, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(0, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 3/ 4, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(0, 0.1f, -MAX_Y);
                    players[5].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    break;
                }
            case 7:
                {
                    players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(-MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    players[5].Characters[0].transform.localPosition = new Vector3(0, 0.1f, -MAX_Y);
                    players[6].Characters[0].transform.localPosition = new Vector3(MAX_X * 3 / 4, 0.1f, -MAX_Y);
                    break;
                }
            case 8:
                {
                    players[0].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[1].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[2].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 15, 0.1f, MAX_Y);
                    players[3].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 5, 0.1f, MAX_Y);
                    players[4].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 5, 0.1f, -MAX_Y);
                    players[5].Characters[0].transform.localPosition = new Vector3(-MAX_X * 4 / 15, 0.1f, -MAX_Y);
                    players[6].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 15, 0.1f, -MAX_Y);
                    players[7].Characters[0].transform.localPosition = new Vector3(MAX_X * 4 / 5, 0.1f, -MAX_Y);
                    break;
                }
        }

        foreach(Player player in players) player.transform.localPosition = GetUIPosition(player);
    }

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
        foreach (Card c in activePlayer.CardsInHand) c.FlipCard();
        turnNumber = 1;
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

    internal Vector2 GetUIPosition(Player player)
    {
        Vector2 canvasPos;
        Vector2 screenPoint = GameCamera.WorldToScreenPoint(player.Characters[0].transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.instance.GetComponent<RectTransform>(), screenPoint, null, out canvasPos);
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
                    TargetingSystem.instance.ShowTarget();
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
}
