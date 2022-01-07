using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject Card;
    public GameObject GameArea;
    /*public GameObject Background;
    public GameObject Player;*/
    private List<GameObject> players = new List<GameObject>();
    private List<GameObject> cardDeck = new List<GameObject>();      // 164
    private List<GameObject> highNoonDeck = new List<GameObject>();  // 13
    private List<GameObject> fistfulDeck = new List<GameObject>();   // 15
    private List<GameObject> wildWestDeck = new List<GameObject>();  // 10
    private List<GameObject> lootDeck = new List<GameObject>();      // 24
    private List<GameObject> characterDeck = new List<GameObject>(); // 63
    private List<GameObject> roleDeck = new List<GameObject>();      // 9 (-1 - Shadow Renegate)
    private List<GameObject> gameRoleDeck = new List<GameObject>();

    private void Start()
    {
        Screen.fullScreen = true;
        CreateDecks();
        //CreatePlayers(7);
        //StartGame();
        //players[1].GetComponent<Player>().DrawCard(cardDeck[0]);
    }

    private void Update()
    {
        
    }


    private void CreateDecks()
    {
        for (int i = 0; i < 164; i++) cardDeck.Add(Instantiate(Card));
        for (int i = 0; i < 12; i++) highNoonDeck.Add(Instantiate(Card));
        for (int i = 0; i < 14; i++) fistfulDeck.Add(Instantiate(Card));
        for (int i = 0; i < 9; i++) wildWestDeck.Add(Instantiate(Card));
        for (int i = 0; i < 24; i++) lootDeck.Add(Instantiate(Card));
        for (int i = 0; i < 63; i++) characterDeck.Add(Instantiate(Card));
        for (int i = 0; i < 8; i++) roleDeck.Add(Instantiate(Card));
        SetUpPlayingDeck();
        SetUpHighNoonDeck();
        SetUpFistfulDeck();
        SetUpWildWestDeck();
        SetUpLootDeck();
        SetUpCharacterDeck();
        SetUpRolesDeck();
        /*cardDeck[1].transform.SetParent(CardArea.transform, false);
        cardDeck[1].transform.localPosition = new Vector3(0, 0, 0);
        cardDeck[1].transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        cardDeck[0].transform.SetParent(CardArea.transform, false);
        cardDeck[0].transform.localPosition = new Vector3(0, 0, 0);
        cardDeck[0].transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);*/
    }

    private void SetUpPlayingDeck()
    {
        System.Random r = new System.Random();
        cardDeck[0].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 0", "Deal 1 damage to a player in range.", "A", '♠', 0);
        cardDeck[1].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 1", "Deal 1 damage to a player in range.", "2", '♦', 0);
        cardDeck[2].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 2", "Deal 1 damage to a player in range.", "3", '♦', 0);
        cardDeck[3].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 3", "Deal 1 damage to a player in range.", "4", '♦', 0);
        cardDeck[4].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 4", "Deal 1 damage to a player in range.", "5", '♦', 0);
        cardDeck[5].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 5", "Deal 1 damage to a player in range.", "6", '♦', 0);
        cardDeck[6].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 6", "Deal 1 damage to a player in range.", "7", '♦', 0);
        cardDeck[7].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 7", "Deal 1 damage to a player in range.", "8", '♦', 0);
        cardDeck[8].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 8", "Deal 1 damage to a player in range.", "9", '♦', 0);
        cardDeck[9].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 9", "Deal 1 damage to a player in range.", "10", '♦', 0);
        cardDeck[10].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 10", "Deal 1 damage to a player in range.", "J", '♦', 0);
        cardDeck[11].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 11", "Deal 1 damage to a player in range.", "Q", '♦', 0);
        cardDeck[12].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 12", "Deal 1 damage to a player in range.", "K", '♦', 0);
        cardDeck[13].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 13", "Deal 1 damage to a player in range.", "A", '♦', 0);
        cardDeck[14].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 14", "Deal 1 damage to a player in range.", "2", '♣', 0);
        cardDeck[15].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 15", "Deal 1 damage to a player in range.", "3", '♣', 0);
        cardDeck[16].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 16", "Deal 1 damage to a player in range.", "4", '♣', 0);
        cardDeck[17].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 17", "Deal 1 damage to a player in range.", "5", '♣', 0);
        cardDeck[18].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 18", "Deal 1 damage to a player in range.", "6", '♣', 0);
        cardDeck[19].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 19", "Deal 1 damage to a player in range.", "7", '♣', 0);
        cardDeck[20].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 20", "Deal 1 damage to a player in range.", "8", '♣', 0);
        cardDeck[21].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 21", "Deal 1 damage to a player in range.", "9", '♣', 0);
        cardDeck[22].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 22", "Deal 1 damage to a player in range.", "Q", '♥', 0);
        cardDeck[23].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 23", "Deal 1 damage to a player in range.", "K", '♥', 0);
        cardDeck[24].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Vanilla/Playing cards/Bang! 24", "Deal 1 damage to a player in range.", "A", '♥', 0);
        cardDeck[25].GetComponent<Card>().SetUpPlayingCard(0, "Barrel", "Textures/Vanilla/Playing cards/Barile 0", "When you are target of a BANG! effect, test a card, if it is ♥, then you are Missed!", "Q", '♠', 1);
        cardDeck[26].GetComponent<Card>().SetUpPlayingCard(0, "Barrel", "Textures/Vanilla/Playing cards/Barile 1", "When you are target of a BANG! effect, test a card, if it is ♥, then you are Missed!", "K", '♠', 1);
        cardDeck[27].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 0", "Restore 1 life.", "6", '♥', 0);
        cardDeck[28].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 1", "Restore 1 life.", "7", '♥', 0);
        cardDeck[29].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 2", "Restore 1 life.", "8", '♥', 0);
        cardDeck[30].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 3", "Restore 1 life.", "9", '♥', 0);
        cardDeck[31].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 4", "Restore 1 life.", "10", '♥', 0);
        cardDeck[32].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Vanilla/Playing cards/Bira 5", "Restore 1 life.", "J", '♥', 0);
        cardDeck[33].GetComponent<Card>().SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 0", "Discard a card from any player.", "K", '♥', 0);
        cardDeck[34].GetComponent<Card>().SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 1", "Discard a card from any player.", "9", '♦', 0);
        cardDeck[35].GetComponent<Card>().SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 2", "Discard a card from any player.", "10", '♦', 0);
        cardDeck[36].GetComponent<Card>().SetUpPlayingCard(0, "Cat Balou", "Textures/Vanilla/Playing cards/Cat Balou 2", "Discard a card from any player.", "J", '♦', 0);
        cardDeck[37].GetComponent<Card>().SetUpPlayingCard(0, "Stagecoach", "Textures/Vanilla/Playing cards/Dilligenza 0", "Draw 2 cards.", "9", '♠', 0);
        cardDeck[38].GetComponent<Card>().SetUpPlayingCard(0, "Stagecoach", "Textures/Vanilla/Playing cards/Dilligenza 1", "Draw 2 cards.", "9", '♠', 0);
        cardDeck[39].GetComponent<Card>().SetUpPlayingCard(0, "Dynamite", "Textures/Vanilla/Playing cards/Dinamite", "Test a card, if it is 2♠ -> 9♠, lose 3 lifes and discard this. Else pass Dynamite to a player on your left.", "9", '♠', 1);
        cardDeck[40].GetComponent<Card>().SetUpPlayingCard(0, "Duel", "Textures/Vanilla/Playing cards/Duello 0", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "Q", '♦', 0);
        cardDeck[41].GetComponent<Card>().SetUpPlayingCard(0, "Duel", "Textures/Vanilla/Playing cards/Duello 1", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "J", '♠', 0);
        cardDeck[42].GetComponent<Card>().SetUpPlayingCard(0, "Duel", "Textures/Vanilla/Playing cards/Duello 2", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "10", '♠', 0);
        cardDeck[43].GetComponent<Card>().SetUpPlayingCard(0, "General Store", "Textures/Vanilla/Playing cards/Emporio 0", "Reveal one card for any player, each player draws one, going clockwise.", "9", '♣', 0);
        cardDeck[44].GetComponent<Card>().SetUpPlayingCard(0, "General Store", "Textures/Vanilla/Playing cards/Emporio 1", "Reveal one card for any player, each player draws one, going clockwise.", "Q", '♠', 0);
        cardDeck[45].GetComponent<Card>().SetUpPlayingCard(0, "Gattling", "Textures/Vanilla/Playing cards/Gattling", "Deal 1 damage to all other players.", "10", '♥', 0);
        cardDeck[46].GetComponent<Card>().SetUpPlayingCard(0, "Indians!", "Textures/Vanilla/Playing cards/Indiani 0", "All other players have to play a BANG! or lose 1 life.", "K", '♦', 0);
        cardDeck[47].GetComponent<Card>().SetUpPlayingCard(0, "Indians!", "Textures/Vanilla/Playing cards/Indiani 1", "All other players have to play a BANG! or lose 1 life.", "A", '♥', 0);
        cardDeck[48].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 0", "Cancel the effect of a card with BANG! symbol.", "10", '♣', 0);
        cardDeck[49].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 1", "Cancel the effect of a card with BANG! symbol.", "J", '♣', 0);
        cardDeck[50].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 2", "Cancel the effect of a card with BANG! symbol.", "Q", '♣', 0);
        cardDeck[51].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 3", "Cancel the effect of a card with BANG! symbol.", "K", '♣', 0);
        cardDeck[52].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 4", "Cancel the effect of a card with BANG! symbol.", "A", '♣', 0);
        cardDeck[53].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 5", "Cancel the effect of a card with BANG! symbol.", "2", '♠', 0);
        cardDeck[54].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 6", "Cancel the effect of a card with BANG! symbol.", "3", '♠', 0);
        cardDeck[55].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 7", "Cancel the effect of a card with BANG! symbol.", "4", '♠', 0);
        cardDeck[56].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 8", "Cancel the effect of a card with BANG! symbol.", "5", '♠', 0);
        cardDeck[57].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 9", "Cancel the effect of a card with BANG! symbol.", "6", '♠', 0);
        cardDeck[58].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 10", "Cancel the effect of a card with BANG! symbol.", "7", '♠', 0);
        cardDeck[59].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Vanilla/Playing cards/Mancato! 11", "Cancel the effect of a card with BANG! symbol.", "8", '♠', 0);
        cardDeck[60].GetComponent<Card>().SetUpPlayingCard(0, "Scope", "Textures/Vanilla/Playing cards/Mirino", "You view others with -1 distance.", "A", '♠', 1);
        cardDeck[61].GetComponent<Card>().SetUpPlayingCard(0, "Mustang", "Textures/Vanilla/Playing cards/Mustang 0", "Others view you with +1 distance.", "8", '♥', 1);
        cardDeck[62].GetComponent<Card>().SetUpPlayingCard(0, "Mustang", "Textures/Vanilla/Playing cards/Mustang 1", "Others view you with +1 distance.", "9", '♥', 1);
        cardDeck[63].GetComponent<Card>().SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 0", "Draw a card from a player at distance 1.", "J", '♥', 0);
        cardDeck[64].GetComponent<Card>().SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 1", "Draw a card from a player at distance 1.", "Q", '♥', 0);
        cardDeck[65].GetComponent<Card>().SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 2", "Draw a card from a player at distance 1.", "A", '♥', 0);
        cardDeck[66].GetComponent<Card>().SetUpPlayingCard(0, "Panic!", "Textures/Vanilla/Playing cards/Panico! 3", "Draw a card from a player at distance 1.", "8", '♦', 0);
        cardDeck[67].GetComponent<Card>().SetUpPlayingCard(0, "Jail", "Textures/Vanilla/Playing cards/Prigione 0", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "J", '♠', 1);
        cardDeck[68].GetComponent<Card>().SetUpPlayingCard(0, "Jail", "Textures/Vanilla/Playing cards/Prigione 1", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "10", '♠', 1);
        cardDeck[69].GetComponent<Card>().SetUpPlayingCard(0, "Jail", "Textures/Vanilla/Playing cards/Prigione 1", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "4", '♥', 1);
        cardDeck[70].GetComponent<Card>().SetUpPlayingCard(0, "Remington", "Textures/Vanilla/Playing cards/Remington", "Your shooting distance is 3.", "K", '♣', 1);
        cardDeck[71].GetComponent<Card>().SetUpPlayingCard(0, "Rev. Carabine", "Textures/Vanilla/Playing cards/Rev. Carabine", "Your shooting distance is 4.", "A", '♣', 1);
        cardDeck[72].GetComponent<Card>().SetUpPlayingCard(0, "Saloon", "Textures/Vanilla/Playing cards/Saloon", "Restore 1 life, then other players also restore 1 life.", "5", '♥', 0);
        cardDeck[73].GetComponent<Card>().SetUpPlayingCard(0, "Schofield", "Textures/Vanilla/Playing cards/Schofield 0", "Your shooting distance is 2.", "J", '♣', 1);
        cardDeck[74].GetComponent<Card>().SetUpPlayingCard(0, "Schofield", "Textures/Vanilla/Playing cards/Schofield 1", "Your shooting distance is 2.", "Q", '♣', 1);
        cardDeck[75].GetComponent<Card>().SetUpPlayingCard(0, "Schofield", "Textures/Vanilla/Playing cards/Schofield 2", "Your shooting distance is 2.", "K", '♠', 1);
        cardDeck[76].GetComponent<Card>().SetUpPlayingCard(0, "Volcanic", "Textures/Vanilla/Playing cards/Volcanic 0", "Your shooting distance is 1, you can play any number of BANGs!", "10", '♠', 1);
        cardDeck[77].GetComponent<Card>().SetUpPlayingCard(0, "Volcanic", "Textures/Vanilla/Playing cards/Volcanic 0", "Your shooting distance is 1, you can play any number of BANGs!", "10", '♣', 1);
        cardDeck[78].GetComponent<Card>().SetUpPlayingCard(0, "Wells Fargo", "Textures/Vanilla/Playing cards/Wells Fargo", "Draw 3 cards.", "3", '♥', 0);
        cardDeck[79].GetComponent<Card>().SetUpPlayingCard(0, "Winchester", "Textures/Vanilla/Playing cards/Winchester", "Your shooting distance is 5.", "8", '♠', 1);
        cardDeck[80].GetComponent<Card>().SetUpADPlayingCard(0, "Ace up the Sleeve", "Textures/Armed & Dangerous/Playing cards/Asso nella Manica", "Spend 2 load tokens to draw a card.", "A", '♥', 3, 2);
        cardDeck[81].GetComponent<Card>().SetUpADPlayingCard(0, "Bandolier", "Textures/Armed & Dangerous/Playing cards/Bandoliera", "Spend 1 load token to be able to play one extra BANG! during this turn.", "2", '♥', 3, 1);
        cardDeck[82].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 0", "Deal 1 damage to a player in range.", "6", '♥', 0);
        cardDeck[83].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 1", "Deal 1 damage to a player in range.", "2", '♣', 0);
        cardDeck[84].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 2", "Deal 1 damage to a player in range.", "2", '♦', 0);
        cardDeck[85].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Armed & Dangerous/Playing cards/Bang 3", "Deal 1 damage to a player in range.", "3", '♦', 0);
        cardDeck[86].GetComponent<Card>().SetUpADPlayingCard(0, "Big Fifty", "Textures/Armed & Dangerous/Playing cards/Big Fifty", "Your shooting distance is 6. After you play BANG!, you may spend 1 load token to cancel the targeted player's character ability and cards in play.", "Q", '♠', 3, 1);
        cardDeck[87].GetComponent<Card>().SetUpADPlayingCard(0, "Bomb", "Textures/Armed & Dangerous/Playing cards/Bomba", "Can be played on any player. At the start of your turn test a card. If it is ♥ or ♦, pass this to any player. If it is ♣ or ♠, spend two load tokens, if there aren't any on this card, lose 2 lifes and discard this.", "7", '♦', 3, 2);
        cardDeck[88].GetComponent<Card>().SetUpADPlayingCard(0, "Buntline Special", "Textures/Armed & Dangerous/Playing cards/Buntline Special", "Your shooting distance is 2. After you play BANG!, which gets cancelled, you may spend 1 load token force the target player to discard a card of their choice form their hand.", "J", '♠', 3, 1);
        cardDeck[89].GetComponent<Card>().SetUpADPlayingCard(0, "Bell Tower", "Textures/Armed & Dangerous/Playing cards/Campanile", "Spend 1 load token to see all players at distance 1 for the next card you play.", "7", '♣', 3, 1);
        cardDeck[90].GetComponent<Card>().SetUpADPlayingCard(0, "Caravan", "Textures/Armed & Dangerous/Playing cards/Carovana", "Draw 2 cards. Spend 2 load tokens from any of your cards to draw an additional card.", "2", '♠', 0, 2);
        cardDeck[91].GetComponent<Card>().SetUpADPlayingCard(0, "Crate", "Textures/Armed & Dangerous/Playing cards/Cassa", "Spend 2 load tokens to cancel the effect of a card with BANG! symbol.", "3", '♥', 3, 2);
        cardDeck[92].GetComponent<Card>().SetUpPlayingCard(0, "Cat Balou", "Textures/Armed & Dangerous/Playing cards/Cat Balou", "Discard a card from any player.", "3", '♥', 0);
        cardDeck[93].GetComponent<Card>().SetUpADPlayingCard(0, "Tumbleweed", "Textures/Armed & Dangerous/Playing cards/Cespuglio", "Spend 1 load token to force a player to repeat a test.", "4", '♣', 3, 1);
        cardDeck[94].GetComponent<Card>().SetUpADPlayingCard(0, "A Little Nip", "Textures/Armed & Dangerous/Playing cards/Cicchetto", "Restore 1 life. Spend 3 load tokens from any of your cards to restore an additional life.", "5", '♥', 0, 3);
        cardDeck[95].GetComponent<Card>().SetUpADPlayingCard(0, "Quick Shot", "Textures/Armed & Dangerous/Playing cards/Colpo Rapido", "Deal 1 damage to a player in range. Spend 1 load token from any of your cards to shoot an additional different player.", "3", '♠', 0, 1);
        cardDeck[96].GetComponent<Card>().SetUpADPlayingCard(0, "Double Barrel", "Textures/Armed & Dangerous/Playing cards/Doppia Canna", "Your shooting distance is 1. If your BANG! is ♦, you may spend 1 load token and it can't be cancelled.", "6", '♣', 3, 1);
        cardDeck[97].GetComponent<Card>().SetUpADPlayingCard(0, "Flintlock", "Textures/Armed & Dangerous/Playing cards/Flintlock", "Deal 1 damage to a player in range. Spend 1 load token, then if this is cancelled, take this back to your hand.", "A", '♠', 0, 2);
        cardDeck[98].GetComponent<Card>().SetUpADPlayingCard(0, "Arrow", "Textures/Armed & Dangerous/Playing cards/Freccia", "A target players discards a BANG! from their hand or loses 1 life. Spend 1 load token to target one additional differnet player.", "5", '♦', 3, 1);
        cardDeck[99].GetComponent<Card>().SetUpADPlayingCard(0, "Whip", "Textures/Armed & Dangerous/Playing cards/Frusta", "Spend 3 load tokens to discard any card in play.", "5", '♣', 3, 3);
        cardDeck[100].GetComponent<Card>().SetUpADPlayingCard(0, "Beer Keg ", "Textures/Armed & Dangerous/Playing cards/Fusto di Birra", "Spend 3 load tokens to restore 1 life.", "4", '♥', 3, 3);
        cardDeck[101].GetComponent<Card>().SetUpADPlayingCard(0, "Duck!", "Textures/Armed & Dangerous/Playing cards/Giù la Testa!", "Cancel the effect of a card with BANG! symbol. Spend 2 load tokens from any of your cards to add this card back to your hand.", "3", '♦', 3, 2);
        cardDeck[102].GetComponent<Card>().SetUpADPlayingCard(0, "Lock Pick", "Textures/Armed & Dangerous/Playing cards/Grimaldello", "Spend 3 load tokens to draw 1 card from the hand of any player.", "2", '♣', 3, 3);
        cardDeck[103].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Armed & Dangerous/Playing cards/Mancato!", "Cancel the effect of a card with BANG! symbol.", "K", '♠', 0);
        cardDeck[104].GetComponent<Card>().SetUpPlayingCard(0, "Reloading", "Textures/Armed & Dangerous/Playing cards/Ricarica", "Add 3 load tokens to your cards and/or your character.", "4", '♦', 0);
        cardDeck[105].GetComponent<Card>().SetUpPlayingCard(0, "Rust", "Textures/Armed & Dangerous/Playing cards/Ruggine", "All other players move 1 load token from each orange card and their characters to your character.", "9", '♠', 0);
        cardDeck[106].GetComponent<Card>().SetUpADPlayingCard(0, "Squaw", "Textures/Armed & Dangerous/Playing cards/Squaw", "Discard any card from play. Spend 2 load tokens from any of your cards to add the discarded card to your hand.", "3", '♦', 0, 2);
        cardDeck[107].GetComponent<Card>().SetUpADPlayingCard(0, "Thunderer", "Textures/Armed & Dangerous/Playing cards/Thunderer", "Your shooting distance is 3. After you play BANG!, you may spend 1 load token to take the BANG! back to your hand.", "3", '♣', 3, 1);
        cardDeck[108].GetComponent<Card>().SetUpPlayingCard(0, "Bandidos", "Textures/The Valley of Shadows/Playing cards/Bandidos", "Each player chooses one: discard 2 cards from hand (1 if he only haas 1) or lose 1 life.", "Q", '♦', 0);
        cardDeck[109].GetComponent<Card>().SetUpPlayingCard(0, "Ghost", "Textures/The Valley of Shadows/Playing cards/Fantasma 0", "Play on any eliminated player. That player is back in the game, but cannot gain nor lose any lifes.", "9", '♠', 1);
        cardDeck[110].GetComponent<Card>().SetUpPlayingCard(0, "Ghost", "Textures/The Valley of Shadows/Playing cards/Fantasma 1", "Play on any eliminated player. That player is back in the game, but cannot gain nor lose any lifes.", "10", '♠', 1);
        cardDeck[111].GetComponent<Card>().SetUpPlayingCard(0, "Escape", "Textures/The Valley of Shadows/Playing cards/Fuga", "May be played out of turn. Avoid effects of a brown card (other than BANG!) that includes you as a target.", "3", '♥', 0);
        cardDeck[112].GetComponent<Card>().SetUpPlayingCard(0, "Lemat", "Textures/The Valley of Shadows/Playing cards/Lemat", "Your shooting distance is 1. During your turn, you may use any card in your hand as a BANG!.", "4", '♦', 1);
        cardDeck[113].GetComponent<Card>().SetUpPlayingCard(0, "Aim", "Textures/The Valley of Shadows/Playing cards/Mira", "Play this card together with BANG!. If the target is hit, he loses 2 lifes.", "6", '♣', 0);
        cardDeck[114].GetComponent<Card>().SetUpPlayingCard(0, "Poker", "Textures/The Valley of Shadows/Playing cards/Poker", "All other players discard 1 card from their hand at the same time. If no ace was discarded, you may draw up to 2 of those cards.", "J", '♥', 0);
        cardDeck[115].GetComponent<Card>().SetUpPlayingCard(0, "Backfire", "Textures/The Valley of Shadows/Playing cards/Ritorno di Fiamma", "Counts as Missed! The player who shot is the target of a BANG!.", "Q", '♣', 0);
        cardDeck[116].GetComponent<Card>().SetUpPlayingCard(0, "Saved!", "Textures/The Valley of Shadows/Playing cards/Salvo", "May be played out of turn. Prevent anther player from losing 1 life. If he survives, draw 2 cards from deck or from his hand.", "5", '♥', 0);
        cardDeck[117].GetComponent<Card>().SetUpPlayingCard(0, "Rattlesnake", "Textures/The Valley of Shadows/Playing cards/Serpente a Sonagli", "Play on any player. At the beginning of his turn, he tests. If it is ♠, he loses 1 life.", "7", '♥', 1);
        cardDeck[118].GetComponent<Card>().SetUpPlayingCard(0, "Shotgun", "Textures/The Valley of Shadows/Playing cards/Shotgun", "Your shooting distance is 1. Each time you hit a player, he must discard a card of his choice from his hand.", "K", '♠', 1);
        cardDeck[119].GetComponent<Card>().SetUpPlayingCard(0, "Fanning", "Textures/The Valley of Shadows/Playing cards/Sventagliata", "Counts as a normal one BANG! per turn. Also targets a player of your choice at distance 1 from the first target with a BANG!.", "2", '♠', 0);
        cardDeck[120].GetComponent<Card>().SetUpPlayingCard(0, "Bounty", "Textures/The Valley of Shadows/Playing cards/Taglia", "Play on any player. If that player is hit by a card with BANG! effect, the player who shot him draws 1 from the deck.", "9", '♣', 1);
        cardDeck[121].GetComponent<Card>().SetUpPlayingCard(0, "Tomahawk", "Textures/The Valley of Shadows/Playing cards/Tomahawk", "Deal 1 damage to a player at distance 2.", "A", '♦', 0);
        cardDeck[122].GetComponent<Card>().SetUpPlayingCard(0, "Tornado", "Textures/The Valley of Shadows/Playing cards/Tornado", "Each player discards any card from their hand (if possible), then draws 2.", "A", '♣', 0);
        cardDeck[123].GetComponent<Card>().SetUpPlayingCard(0, "Last Call", "Textures/The Valley of Shadows/Playing cards/Ultimo Giro", "Restore 1 life. Can be played with only 2 players remaining", "8", '♦', 0);
        cardDeck[124].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 0", "Deal 1 damage to a player in range.", "8", '♠', 0);
        cardDeck[125].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 1", "Deal 1 damage to a player in range.", "5", '♣', 0);
        cardDeck[126].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 2", "Deal 1 damage to a player in range.", "6", '♣', 0);
        cardDeck[127].GetComponent<Card>().SetUpPlayingCard(0, "BANG!", "Textures/Dodge City/Playing cards/Bang 3", "Deal 1 damage to a player in range.", "K", '♣', 0);
        cardDeck[128].GetComponent<Card>().SetUpPlayingCard(0, "Barrel", "Textures/Dodge City/Playing cards/Barile", "When you are target of a BANG!, test a card, if it is ♥, then you are Missed!", "A", '♣', 1);
        cardDeck[129].GetComponent<Card>().SetUpPlayingCard(0, "Bible", "Textures/Dodge City/Playing cards/Bibbia", "Cancel the effect of a card with BANG! symbol, then draw 1. Cannot be used this turn.", "10", '♥', 2);
        cardDeck[130].GetComponent<Card>().SetUpPlayingCard(0, "Binocular", "Textures/Dodge City/Playing cards/Binocolo", "You view others with -1 distance.", "10", '♦', 1);
        cardDeck[131].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Dodge City/Playing cards/Birra 0", "Restore 1 life.", "6", '♥', 0);
        cardDeck[132].GetComponent<Card>().SetUpPlayingCard(0, "Beer", "Textures/Dodge City/Playing cards/Birra 1", "Restore 1 life.", "6", '♠', 0);
        cardDeck[133].GetComponent<Card>().SetUpPlayingCard(0, "Canteen", "Textures/Dodge City/Playing cards/Borraccia", "Restore 1 life. Cannot be used this turn.", "7", '♥', 2);
        cardDeck[134].GetComponent<Card>().SetUpPlayingCard(0, "Can Can", "Textures/Dodge City/Playing cards/Can Can", "Discard a card from any player. Cannot be used this turn.", "J", '♣', 2);
        cardDeck[135].GetComponent<Card>().SetUpPlayingCard(0, "Ten Gallon Hat", "Textures/Dodge City/Playing cards/Cappello", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "J", '♦', 2);
        cardDeck[136].GetComponent<Card>().SetUpPlayingCard(0, "Cat Balou", "Textures/Dodge City/Playing cards/Cat Balou", "Discard a card from any player.", "8", '♣', 0);
        cardDeck[137].GetComponent<Card>().SetUpPlayingCard(0, "Conestoga", "Textures/Dodge City/Playing cards/Conestoga", "Draw a card from a player. Cannot be used this turn.", "9", '♦', 2);
        cardDeck[138].GetComponent<Card>().SetUpPlayingCard(0, "Derringer", "Textures/Dodge City/Playing cards/Derringer", "Deal 1 damage to a player at distance 1, then draw 1. Cannot be used this turn.", "7", '♠', 2);
        cardDeck[139].GetComponent<Card>().SetUpPlayingCard(0, "Dynamite", "Textures/Dodge City/Playing cards/Dinamite", "Deal 1 damage to a player at distance 1, then draw 1. Cannot be used this turn.", "10", '♣', 1);
        cardDeck[140].GetComponent<Card>().SetUpPlayingCard(0, "General Store", "Textures/Dodge City/Playing cards/Emporio", "Reveal one card for any player, each player draws one, going clockwise.", "10", '♠', 0);
        cardDeck[141].GetComponent<Card>().SetUpPlayingCard(0, "Buffalo Rifle", "Textures/Dodge City/Playing cards/Fucile da Caccia", "Deal 1 damage to any player. Cannot be used this turn.", "Q", '♣', 2);
        cardDeck[142].GetComponent<Card>().SetUpPlayingCard(0, "Howitzer", "Textures/Dodge City/Playing cards/Howitzer", "Deal 1 damage to all other players. Cannot be used this turn.", "9", '♠', 2);
        cardDeck[143].GetComponent<Card>().SetUpPlayingCard(0, "Indians!", "Textures/Dodge City/Playing cards/Indiani", "All other players have to play a BANG! or lose 1 life.", "5", '♦', 0);
        cardDeck[144].GetComponent<Card>().SetUpPlayingCard(0, "Missed!", "Textures/Dodge City/Playing cards/Mancato!", "Cancel the effect of a card with BANG! symbol.", "8", '♦', 0);
        cardDeck[145].GetComponent<Card>().SetUpPlayingCard(0, "Mustang", "Textures/Dodge City/Playing cards/Mustang", "Others view you with +1 distance.", "5", '♥', 1);
        cardDeck[146].GetComponent<Card>().SetUpPlayingCard(0, "Panic!", "Textures/Dodge City/Playing cards/Panico!", "Draw a card from a player at distance 1.", "J", '♥', 0);
        cardDeck[147].GetComponent<Card>().SetUpPlayingCard(0, "Pepperbox", "Textures/Dodge City/Playing cards/Pepperbox", "Deal 1 damage to a player in range. Cannot be used this turn.", "A", '♥', 2);
        cardDeck[148].GetComponent<Card>().SetUpPlayingCard(0, "Iron Plate", "Textures/Dodge City/Playing cards/Placca di Ferro 0", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "A", '♦', 2);
        cardDeck[149].GetComponent<Card>().SetUpPlayingCard(0, "Iron Plate", "Textures/Dodge City/Playing cards/Placca di Ferro 1", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "Q", '♠', 2);
        cardDeck[150].GetComponent<Card>().SetUpPlayingCard(0, "Pony Express", "Textures/Dodge City/Playing cards/Pony Express", "Draw 3 cards. Cannot be used this turn.", "Q", '♦', 2);
        cardDeck[151].GetComponent<Card>().SetUpPlayingCard(0, "Knife", "Textures/Dodge City/Playing cards/Pugnale", "Deal 1 damage to a player at distance 1. Cannot be used this turn.", "8", '♥', 2);
        cardDeck[152].GetComponent<Card>().SetUpPlayingCard(0, "Punch", "Textures/Dodge City/Playing cards/Pugno", "Deal 1 damage to a player at distance 1.", "10", '♠', 0);
        cardDeck[153].GetComponent<Card>().SetUpPlayingCard(0, "Rag Time", "Textures/Dodge City/Playing cards/Rag Time", "Play this card and discard any other card to draw a card from any player.", "9", '♥', 0);
        cardDeck[154].GetComponent<Card>().SetUpPlayingCard(0, "Remington", "Textures/Dodge City/Playing cards/Remington", "Your shooting distance is 3.", "6", '♦', 1);
        cardDeck[155].GetComponent<Card>().SetUpPlayingCard(0, "Rev. Carabine", "Textures/Dodge City/Playing cards/Rev. Carabine", "Your shooting distance is 4.", "5", '♠', 1);
        cardDeck[156].GetComponent<Card>().SetUpPlayingCard(0, "Hideout", "Textures/Dodge City/Playing cards/Riparo", "Others view you with +1 distance.", "K", '♦', 1);
        cardDeck[157].GetComponent<Card>().SetUpPlayingCard(0, "Brawl", "Textures/Dodge City/Playing cards/Rissa", "Play this card and discard any other card to discard a card from each player.", "J", '♠', 0);
        cardDeck[158].GetComponent<Card>().SetUpPlayingCard(0, "Dodge", "Textures/Dodge City/Playing cards/Schivata 0", "Cancel the effect of a card with BANG! symbol, then draw 1.", "7", '♦', 0);
        cardDeck[159].GetComponent<Card>().SetUpPlayingCard(0, "Dodge", "Textures/Dodge City/Playing cards/Schivata 1", "Cancel the effect of a card with BANG! symbol, then draw 1.", "K", '♥', 0);
        cardDeck[160].GetComponent<Card>().SetUpPlayingCard(0, "Sombrero", "Textures/Dodge City/Playing cards/Sombrero", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "7", '♣', 2);
        cardDeck[161].GetComponent<Card>().SetUpPlayingCard(0, "Springfield", "Textures/Dodge City/Playing cards/Springfield", "Play this card and discard any other card to deal 1 damage to any player.", "K", '♠', 0);
        cardDeck[162].GetComponent<Card>().SetUpPlayingCard(0, "Tequila", "Textures/Dodge City/Playing cards/Tequila", "Play this card and discard any other card to restore 1 life to any player (including yourself).", "9", '♣', 0);
        cardDeck[163].GetComponent<Card>().SetUpPlayingCard(0, "Whisky", "Textures/Dodge City/Playing cards/Whisky", "Play this card and discard any other card to restore 2 lifes.", "Q", '♥', 0);
        cardDeck = Shuffle(cardDeck);
        int i = 0;
        foreach (GameObject go in cardDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, 0);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }
    }

    private void SetUpHighNoonDeck()
    {
        highNoonDeck[0].GetComponent<Card>().SetUpCard(1, "Blessing", "Textures/High Noon/Benedizione", "The suit of all cards is ♥.");
        highNoonDeck[1].GetComponent<Card>().SetUpCard(1, "Ghost Town", "Textures/High Noon/Città Fantasma", "During their turn, eliminated players return to the game as ghosts. In phase 1, they draw 3 cards and cannot die. At the end of their turn, they are eliminated again.");
        highNoonDeck[2].GetComponent<Card>().SetUpCard(1, "Gold Rush", "Textures/High Noon/Corsa all'Oro", "The game proceeds counter-clockwise for one round, starting with Sheriff. Effects proceed clockwise.");
        highNoonDeck[3].GetComponent<Card>().SetUpCard(1, "The Daltons", "Textures/High Noon/I Dalton", "When the Daltons enter play, each player who has any blue cards in front of him, chooses on of them and discards it.");
        highNoonDeck[4].GetComponent<Card>().SetUpCard(1, "The Doctor", "Textures/High Noon/Il Dottore", "When the Doctor enters play, the player or player still in the game with the least amount of lifes restore 1 life.");
        highNoonDeck[5].GetComponent<Card>().SetUpCard(1, "The Reverend", "Textures/High Noon/Il Reverendo", "Players cannot play Beer.");
        highNoonDeck[6].GetComponent<Card>().SetUpCard(1, "Train Arrival", "Textures/High Noon/Il Treno", "Each players draws 1 extra card at the end of phase 1 of his turn.");
        highNoonDeck[7].GetComponent<Card>().SetUpCard(1, "Curse", "Textures/High Noon/Maledizione", "The suit of all cards is ♠.");
        highNoonDeck[8].GetComponent<Card>().SetUpCard(1, "Hangover", "Textures/High Noon/Sbornia", "All character lose their effects.");
        highNoonDeck[9].GetComponent<Card>().SetUpCard(1, "The Sermon", "Textures/High Noon/Sermone", "Players cannot play BANG!.");
        highNoonDeck[10].GetComponent<Card>().SetUpCard(1, "Thirst", "Textures/High Noon/Sete", "Each player only draws 1 card in phase 1.");
        highNoonDeck[11].GetComponent<Card>().SetUpCard(1, "Shootout", "Textures/High Noon/Sparatoria", "Each player can play a second BANG! during his turn.");
        highNoonDeck = Shuffle(highNoonDeck);
        highNoonDeck.Add(Instantiate(Card));
        highNoonDeck[12].GetComponent<Card>().SetUpCard(1, "High Noon", "Textures/High Noon/Mezzogiorno di Fuoco", "Each player loses 1 life at the start of their turn.");
        int i = 0;
        foreach (GameObject go in highNoonDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, 30);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }
    }

    private void SetUpFistfulDeck()
    {
        fistfulDeck[0].GetComponent<Card>().SetUpCard(2, "Ambush", "Textures/A Fistful of Cards/Agguato", "The distance between any two players is 1. This is modified only by cards in play.");
        fistfulDeck[1].GetComponent<Card>().SetUpCard(2, "Sniper", "Textures/A Fistful of Cards/Cecchino", "During your turn, the player may play 2 BANGs! together againts a player, this counts as a BANG! it may be cancelled only by 2 Missed! effects.");
        fistfulDeck[2].GetComponent<Card>().SetUpCard(2, "Dead Man", "Textures/A Fistful of Cards/Dead Man", "During his turn, the player who was eliminated first comes back to play with 2 lifes and 2 cards.");
        fistfulDeck[3].GetComponent<Card>().SetUpCard(2, "Blood Brothers", "Textures/A Fistful of Cards/Fratelli di Sangue", "At the beginning of his turn, each player may give one of his lifes (except the last one) to any other player.");
        fistfulDeck[4].GetComponent<Card>().SetUpCard(2, "The Judge", "Textures/A Fistful of Cards/Il Giudice", "You cannot play cards in front of you or any other player.");
        fistfulDeck[5].GetComponent<Card>().SetUpCard(2, "Lasso", "Textures/A Fistful of Cards/Lazo", "Cards in play in front of the players have no effect (excluding characters).");
        fistfulDeck[6].GetComponent<Card>().SetUpCard(2, "Law of the West", "Textures/A Fistful of Cards/Legge del West", "During his phase 1, each player shows the second card he draws. If he can, he must play it during his phase 2.");
        fistfulDeck[7].GetComponent<Card>().SetUpCard(2, "Hard Liquor", "Textures/A Fistful of Cards/Liquore Forte", "Each player may skip his phase 1 to restore 1 life.");
        fistfulDeck[8].GetComponent<Card>().SetUpCard(2, "Abandoned Mine", "Textures/A Fistful of Cards/Miniera Abbandonata", "During his phase 1, each player draws from the discard pile (if it runs out, the from the deck). In phase 3, he discards face down on the deck.");
        fistfulDeck[9].GetComponent<Card>().SetUpCard(2, "Peyote", "Textures/A Fistful of Cards/Peyote", "Instead of drawing in phase 1, each player guesses if the suit of the top card of the deck is red or black. He then draws and shows it; if he guessed right, he keeps it and guesses again; otherwise he proceeds to phase 2.");
        fistfulDeck[10].GetComponent<Card>().SetUpCard(2, "Ranch", "Textures/A Fistful of Cards/Ranch", "At the end of his phase 1, each player may discard once any number of cards from his hand to draw the same number of cards from the deck.");
        fistfulDeck[11].GetComponent<Card>().SetUpCard(2, "Rinochet", "Textures/A Fistful of Cards/Rimbalzo", "Each player may play BANG! againts a card in play in front of any player; the card is discarded if its owner doesn't play a Missed! effect.");
        fistfulDeck[12].GetComponent<Card>().SetUpCard(2, "Russian Roulette", "Textures/A Fistful of Cards/Roulette Russa", "When Russian Roulette enters play, starting from the Sheriff each player must discard Missed!, until one player doesn't; he loses 2 lifes and the Roulette ends.");
        fistfulDeck[13].GetComponent<Card>().SetUpCard(2, "Vendetta", "Textures/A Fistful of Cards/Vendetta", "At the end of his turn, each player tests. If it is ♥, he plays another turn (at the end of which he doesn't test for this again).");
        fistfulDeck = Shuffle(fistfulDeck);
        fistfulDeck.Add(Instantiate(Card));
        fistfulDeck[14].GetComponent<Card>().SetUpCard(2, "A Fistful of Cards", "Textures/A Fistful of Cards/Per un Ugno di Carte", "At the beginning of his turn, the player is target of as many BANGs! as the number of the cards in his hand.");
        int i = 0;
        foreach (GameObject go in fistfulDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, -30);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }
    }

    private void SetUpWildWestDeck()
    {
        wildWestDeck[0].GetComponent<Card>().SetUpCard(3, "Ambush", "Textures/Wild West Show/WWS cards/Bavaglio", "Players cannot talk. Whoever talks, loses 1 life.");
        wildWestDeck[1].GetComponent<Card>().SetUpCard(3, "Bone Orchard", "Textures/Wild West Show/WWS cards/Camposanto", "At the start of their turn, each eliminated player returns to play with 1 life. Deal them roles at random from those of the eliminated players.");
        wildWestDeck[2].GetComponent<Card>().SetUpCard(3, "Darling Valentine", "Textures/Wild West Show/WWS cards/Darling Valentine", "At the start of his turn (before phase 1), each players discards his hand and draws the same number of cards.");
        wildWestDeck[3].GetComponent<Card>().SetUpCard(3, "Dorothy Rage", "Textures/Wild West Show/WWS cards/Dorothy Rage", "During his turn, each player can force another player to play one of his cards.");
        wildWestDeck[4].GetComponent<Card>().SetUpCard(3, "Helena Zontero", "Textures/Wild West Show/WWS cards/Helena Zontero", "When Helena comes into play, test. If it is ♥ or ♦, shuffle all active roles, except for Sheriff and, deal them at random.");
        wildWestDeck[5].GetComponent<Card>().SetUpCard(3, "Lady Rose of Texas", "Textures/Wild West Show/WWS cards/Lady Rosa del Texas", "During his turn, each player can swap places with the player on his right, who then skips his next turn.");
        wildWestDeck[6].GetComponent<Card>().SetUpCard(3, "Miss Susanna", "Textures/Wild West Show/WWS cards/Miss Susanna", "During phase 2, each player must play at least 3 cards. If he doesn't, he loses 1 life.");
        wildWestDeck[7].GetComponent<Card>().SetUpCard(3, "Showdown", "Textures/Wild West Show/WWS cards/Regolamento di Conti", "All cards may be played as they were BANG!. All BANGs! may be played as they were Missed!.");
        wildWestDeck[8].GetComponent<Card>().SetUpCard(3, "Sacagaway", "Textures/Wild West Show/WWS cards/Sacagaway", "All players play with their hands revealed.");
        wildWestDeck = Shuffle(wildWestDeck);
        wildWestDeck.Add(Instantiate(Card));
        wildWestDeck[9].GetComponent<Card>().SetUpCard(3, "Wild West Show", "Textures/Wild West Show/WWS cards/Wild West Show", "The goal of each player becomes: \"Be the last one in play!\"");
        int i = 0;
        foreach (GameObject go in wildWestDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, 60);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }
    }

    private void SetUpLootDeck()
    {
        lootDeck[0].GetComponent<Card>().SetUpLootCard(4, "Shot", "Textures/Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", 1, 0);
        lootDeck[1].GetComponent<Card>().SetUpLootCard(4, "Shot", "Textures/Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", 1, 0);
        lootDeck[2].GetComponent<Card>().SetUpLootCard(4, "Shot", "Textures/Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", 1, 0);
        lootDeck[3].GetComponent<Card>().SetUpLootCard(4, "Bottle", "Textures/Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", 2, 0);
        lootDeck[4].GetComponent<Card>().SetUpLootCard(4, "Bottle", "Textures/Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", 2, 0);
        lootDeck[5].GetComponent<Card>().SetUpLootCard(4, "Bottle", "Textures/Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", 2, 0);
        lootDeck[6].GetComponent<Card>().SetUpLootCard(4, "Calumet", "Textures/Gold Rush/Loot cards/Calumet", "♦ cards played by other players have no effect on you.", 3, 1);
        lootDeck[7].GetComponent<Card>().SetUpLootCard(4, "Gun Belt", "Textures/Gold Rush/Loot cards/Cinturone", "Your hand size limit at the end of your turn is 8 cards.", 2, 1);
        lootDeck[8].GetComponent<Card>().SetUpLootCard(4, "Partner in Crime", "Textures/Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", 2, 0);
        lootDeck[9].GetComponent<Card>().SetUpLootCard(4, "Partner in Crime", "Textures/Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", 2, 0);
        lootDeck[10].GetComponent<Card>().SetUpLootCard(4, "Partner in Crime", "Textures/Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", 2, 0);
        lootDeck[11].GetComponent<Card>().SetUpLootCard(4, "Gold Rush", "Textures/Gold Rush/Loot cards/Corsa all'Oro", "Your turn ends. Restore all your lifes then play another turn.", 5, 0);
        lootDeck[12].GetComponent<Card>().SetUpLootCard(4, "Horseshoe", "Textures/Gold Rush/Loot cards/Ferro di Cavallo", "Your turn ends. Restore all your lifes then play another turn.", 2, 1);
        lootDeck[13].GetComponent<Card>().SetUpLootCard(4, "Pickaxe", "Textures/Gold Rush/Loot cards/Piccone", "During your phase 1 draw 1 additional card.", 4, 1);
        lootDeck[14].GetComponent<Card>().SetUpLootCard(4, "Wanted", "Textures/Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", 2, 1);
        lootDeck[15].GetComponent<Card>().SetUpLootCard(4, "Wanted", "Textures/Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", 2, 1);
        lootDeck[16].GetComponent<Card>().SetUpLootCard(4, "Wanted", "Textures/Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", 2, 1);
        lootDeck[17].GetComponent<Card>().SetUpLootCard(4, "Rhum", "Textures/Gold Rush/Loot cards/Rum", "Test 4 cards. Restore 1 life for each different suit.", 3, 0);
        lootDeck[18].GetComponent<Card>().SetUpLootCard(4, "Rhum", "Textures/Gold Rush/Loot cards/Rum", "Test 4 cards. Restore 1 life for each different suit.", 3, 0);
        lootDeck[19].GetComponent<Card>().SetUpLootCard(4, "Gold Pan", "Textures/Gold Rush/Loot cards/Setaccio", "Pay 1 golden nugget to draw 1. You may use this up to 2 times per turn.", 3, 1);
        lootDeck[20].GetComponent<Card>().SetUpLootCard(4, "Boots", "Textures/Gold Rush/Loot cards/Stivali", "Each time you lose a life, draw 1.", 3, 1);
        lootDeck[21].GetComponent<Card>().SetUpLootCard(4, "Lucky Charm", "Textures/Gold Rush/Loot cards/Talismano", "Each time you lose a life, take 1 golden nugget.", 3, 1);
        lootDeck[22].GetComponent<Card>().SetUpLootCard(4, "Union Pacific", "Textures/Gold Rush/Loot cards/Unoion Pacific", "Draw 4 cards.", 4, 0);
        lootDeck[23].GetComponent<Card>().SetUpLootCard(4, "Rucksack", "Textures/Gold Rush/Loot cards/Zaino", "Pay 2 golden nuggets to restore 1.", 3, 1);
        lootDeck = Shuffle(lootDeck);
        int i = 0;
        foreach (GameObject go in lootDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, -60);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }

        //dealing loot cards
        /*for (int i = 1; i < 4; i++)
        {
            lootDeck[0].transform.localPosition = new Vector3((350 + 150 * i), 0, 0);
            lootDeck[0].GetComponent<Card>().FlipCard();
            lootDeck.RemoveAt(0);
        }*/
    }

    private void SetUpCharacterDeck()
    {
        characterDeck[0].GetComponent<Card>().SetUpCharacterCard(5, "Bart Cassidy", "Textures/Vanilla/Characters/Bart Cassidy", "Each time he is hit, he draws a card.", 4);
        characterDeck[1].GetComponent<Card>().SetUpCharacterCard(5, "Black Jack", "Textures/Vanilla/Characters/Black Jack", "He shows the second card he draws in phase 1. ", 4);
        characterDeck[2].GetComponent<Card>().SetUpCharacterCard(5, "Calamity Janet", "Textures/Vanilla/Characters/Calamity Janet", "She may play BANG! as Missed! and vice versa.", 4);
        characterDeck[3].GetComponent<Card>().SetUpCharacterCard(5, "El Gringo", "Textures/Vanilla/Characters/El Gringo", "Each time he is hit by a player, he draws a card from the hand of that player.", 3);
        characterDeck[4].GetComponent<Card>().SetUpCharacterCard(5, "Jesse Jones", "Textures/Vanilla/Characters/Jesse Jones", "He may draw his first card from the hand of any player.", 4);
        characterDeck[5].GetComponent<Card>().SetUpCharacterCard(5, "Jourdonnais", "Textures/Vanilla/Characters/Jourdonnais", "Whenever he is a target of a BANG!, he may test a card, if it is ♥, then he is Missed!", 4);
        characterDeck[6].GetComponent<Card>().SetUpCharacterCard(5, "Kit Carlson", "Textures/Vanilla/Characters/Kit Carlson", "In phase 1, he looks on top three cards of the deck and chooses two to draw and discards the other one.", 4);
        characterDeck[7].GetComponent<Card>().SetUpCharacterCard(5, "Lucky Duke", "Textures/Vanilla/Characters/Lucky Duke", "Each time he tests, he flips the top two cards a chooses one.", 4);
        characterDeck[8].GetComponent<Card>().SetUpCharacterCard(5, "Paul Regret", "Textures/Vanilla/Characters/Paul Regret", "All others see him with +1 distance.", 3);
        characterDeck[9].GetComponent<Card>().SetUpCharacterCard(5, "Pedro Ramirez", "Textures/Vanilla/Characters/Pedro Ramirez", "In phase 1, he may draw his first card frin the discard pile.", 4);
        characterDeck[10].GetComponent<Card>().SetUpCharacterCard(5, "Rose Doolan", "Textures/Vanilla/Characters/Rose Doolan", "She sees all players with -1 distance.", 4);
        characterDeck[11].GetComponent<Card>().SetUpCharacterCard(5, "Sid Ketchum", "Textures/Vanilla/Characters/Sid Ketchum", "He may discard two cards to restore 1 life.", 4);
        characterDeck[12].GetComponent<Card>().SetUpCharacterCard(5, "Slab the Killer", "Textures/Vanilla/Characters/Slab the Killer", "Players need 2 Missed! effects to cancel his BANG!.", 4);
        characterDeck[13].GetComponent<Card>().SetUpCharacterCard(5, "Suzy Lafayette", "Textures/Vanilla/Characters/Suzy Lafayette", "As soon as she has no cards in hand, she draws a card.", 4);
        characterDeck[14].GetComponent<Card>().SetUpCharacterCard(5, "Vulture Sam", "Textures/Vanilla/Characters/Vulture Sam", "Whenever a player is eliminated, he takes all the cards of that player to his hand.", 4);
        characterDeck[15].GetComponent<Card>().SetUpCharacterCard(5, "Willy the Kid", "Textures/Vanilla/Characters/Willy the Kid", "He can play any number of BANGs!.", 4);
        characterDeck[16].GetComponent<Card>().SetUpCharacterCard(5, "Al Preacher", "Textures/Armed & Dangerous/Characters/Al Preacher", "If another player plays blue or orange card, you may pay 2 load tokens to draw 1 card.", 4);
        characterDeck[17].GetComponent<Card>().SetUpCharacterCard(5, "Bass Greeves", "Textures/Armed & Dangerous/Characters/Bass Greeves", "Once during your turn, you may discard 1 card from your hand to add 2 load tokens to one of your cards.", 4);
        characterDeck[18].GetComponent<Card>().SetUpCharacterCard(5, "Bloody Mary", "Textures/Armed & Dangerous/Characters/Bloody Mary", "Each time your BANG! is cancelled, draw 1 card.", 4);
        characterDeck[19].GetComponent<Card>().SetUpCharacterCard(5, "Frankie Canton", "Textures/Armed & Dangerous/Characters/Frankie Canton", "Once during your turn, you may take 1 load token from any card and move it on this card.", 4);
        characterDeck[20].GetComponent<Card>().SetUpCharacterCard(5, "Julie Cutter", "Textures/Armed & Dangerous/Characters/Julie Cutter", "Each time a player makes you lose a life, test. If it is ♥ or ♦, they are target of a BANG!.", 4);
        characterDeck[21].GetComponent<Card>().SetUpCharacterCard(5, "Mexicali Kid", "Textures/Armed & Dangerous/Characters/Mexicali Kid", "Once during your turn, you may pay 2 load tokens to shoot 1 extra BANG! (no card required).", 4);
        characterDeck[22].GetComponent<Card>().SetUpCharacterCard(5, "Miss Abigail", "Textures/Armed & Dangerous/Characters/Miss Abigail", "You may ignore effects of brown cards with values J, Q, K and A if you are the only target.", 4);
        characterDeck[23].GetComponent<Card>().SetUpCharacterCard(5, "Red Ringo", "Textures/Armed & Dangerous/Characters/Red Ringo", "Starts with 4 load tokens. Once during your turn, you may move up to 2 load tokens from here to your cards.", 5);
        characterDeck[24].GetComponent<Card>().SetUpCharacterCard(5, "Apache Kid", "Textures/Dodge City/Characters/Apache Kid", "♦ cards played by other players don't effect him.", 3);
        characterDeck[25].GetComponent<Card>().SetUpCharacterCard(5, "Belle Star", "Textures/Dodge City/Characters/Belle Star", "During her turn, cards in play in front of other players have no effects.", 4);
        characterDeck[26].GetComponent<Card>().SetUpCharacterCard(5, "Bill Noface", "Textures/Dodge City/Characters/Bill Noface", "In phase 1, he draws 1 card, plus each wound he has.", 4);
        characterDeck[27].GetComponent<Card>().SetUpCharacterCard(5, "Chuck Wengam", "Textures/Dodge City/Characters/Chuck Wengam", "During his turn, he may choose to lose 1 life to draw 2 cards.", 4);
        characterDeck[28].GetComponent<Card>().SetUpCharacterCard(5, "Doc Holyday", "Textures/Dodge City/Characters/Doc Holyday", "During his turn, he may once discard 2 cards from his hand to shoot a BANG! to a player in range.", 4);
        characterDeck[29].GetComponent<Card>().SetUpCharacterCard(5, "Elena Fuente", "Textures/Dodge City/Characters/Elena Fuente", "She may use any card as Missed!.", 3);
        characterDeck[30].GetComponent<Card>().SetUpCharacterCard(5, "Greg Digger", "Textures/Dodge City/Characters/Greg Digger", "Each time another player is eliminated, he restores 2 lifes.", 4);
        characterDeck[31].GetComponent<Card>().SetUpCharacterCard(5, "Herb Hunter", "Textures/Dodge City/Characters/Herb Hunter", "Each time another player is eliminated, he draws 2 cards.", 4);
        characterDeck[32].GetComponent<Card>().SetUpCharacterCard(5, "José Delgado", "Textures/Dodge City/Characters/José Delgado", "Twice in his turn, he may discard a blue card form his hand to draw 2 cards.", 4);
        characterDeck[33].GetComponent<Card>().SetUpCharacterCard(5, "Molly Stark", "Textures/Dodge City/Characters/Molly Stark", "Each time she uses a card from hand out of her turn, she draws a card.", 4);
        characterDeck[34].GetComponent<Card>().SetUpCharacterCard(5, "Pat Brennan", "Textures/Dodge City/Characters/Pat Brennan", "In phase 1, instead of drawing from the deck, he may draw one card in play in front of any other player.", 4);
        characterDeck[35].GetComponent<Card>().SetUpCharacterCard(5, "Pixie Pete", "Textures/Dodge City/Characters/Pixie Pete", "In phase 1, he draws 3 cards instead of 2.", 3);
        characterDeck[36].GetComponent<Card>().SetUpCharacterCard(5, "Sean Mallory", "Textures/Dodge City/Characters/Sean Mallory", "He may hold up to 10 cards at the end of his turn.", 3);
        characterDeck[37].GetComponent<Card>().SetUpCharacterCard(5, "Tequila Joe", "Textures/Dodge City/Characters/Tequila Joe", "Each time he plays a Beer, he restores 2 lifes instead of 1.", 4);
        characterDeck[38].GetComponent<Card>().SetUpCharacterCard(5, "Vera Custer", "Textures/Dodge City/Characters/Vera Custer", "Before phase 1, she chooses another character in play and gains its effect until the start of her next turn.", 4);
        characterDeck[39].GetComponent<Card>().SetUpCharacterCard(5, "Don Bell", "Textures/Gold Rush/Characters/Don Bell", "At the end of his turn, he tests. If it is ♥ or ♦, he plays an extra turn (at the end of which he doesn't test for this again).", 4);
        characterDeck[40].GetComponent<Card>().SetUpCharacterCard(5, "Dutch Will", "Textures/Gold Rush/Characters/Dutch Will", "In phase 1, he draws 2 cards, chooses 1 to discards and takes 1 gold nugget.", 4);
        characterDeck[41].GetComponent<Card>().SetUpCharacterCard(5, "Jacky Murieta", "Textures/Gold Rush/Characters/Jacky Murieta", "During his turn, he may pay 2 gold nuggets to shoot 1 extra BANG! (no card required).", 4);
        characterDeck[42].GetComponent<Card>().SetUpCharacterCard(5, "Josh McCloud", "Textures/Gold Rush/Characters/Josh McCloud", "He may draw the top equipment from the equipment deck by paying 2 gold nuggets.", 4);
        characterDeck[43].GetComponent<Card>().SetUpCharacterCard(5, "Madame Yto", "Textures/Gold Rush/Characters/Madame Yto", "Each time a Beer is played, she draws 1.", 4);
        characterDeck[44].GetComponent<Card>().SetUpCharacterCard(5, "Pretty Luzena", "Textures/Gold Rush/Characters/Pretty Luzena", "Once per turn, she may buy 1 equipment at a cost reduced by 1 gold nugget.", 4);
        characterDeck[45].GetComponent<Card>().SetUpCharacterCard(5, "Raddie Snake", "Textures/Gold Rush/Characters/Raddie Snake", "Twice in his turn, he may pay 1 gold nugget to draw 1.", 4);
        characterDeck[46].GetComponent<Card>().SetUpCharacterCard(5, "Simeon Picos", "Textures/Gold Rush/Characters/Simeon Picos", "Each time he loses 1 life, he takes 1 gold nugget.", 4);
        characterDeck[47].GetComponent<Card>().SetUpCharacterCard(5, "Black Flower", "Textures/The Valley of Shadows/Characters/Black Flower", "Once during her turn, she may use any ♣ card as an extra BANG!.", 4);
        characterDeck[48].GetComponent<Card>().SetUpCharacterCard(5, "Colorado Bill", "Textures/The Valley of Shadows/Characters/Colorado Bill", "Each time he plays a BANG!, he tests. If it is ♠, it cannot be cancelled.", 4);
        characterDeck[49].GetComponent<Card>().SetUpCharacterCard(5, "Der Spot - Burst Ringer", "Textures/The Valley of Shadows/Characters/Der Spot", "Once during his turn, he may use a BANG! as a Gattling.", 4);
        characterDeck[50].GetComponent<Card>().SetUpCharacterCard(5, "Evelyn Shebang", "Textures/The Valley of Shadows/Characters/Evelyn Shabang", "She may skip phase 1. For each card skipped, she may shoot a BANG! at a different player in range.", 4);
        characterDeck[51].GetComponent<Card>().SetUpCharacterCard(5, "Henry Block", "Textures/The Valley of Shadows/Characters/Henry Block", "In player drawing or discarding on of his cards (in hand or in play) is a target of a BANG!.", 4);
        characterDeck[52].GetComponent<Card>().SetUpCharacterCard(5, "Lemonade Jim", "Textures/The Valley of Shadows/Characters/Lemonade Jim", "Each time another player plays Beer, he may discard any card from his hand to also restore 1 life.", 4);
        characterDeck[53].GetComponent<Card>().SetUpCharacterCard(5, "Mick Defender", "Textures/The Valley of Shadows/Characters/Mick Defender", "If he is a target of a brown card other than BANG!, he may use Missed! to avoid that card.", 4);
        characterDeck[54].GetComponent<Card>().SetUpCharacterCard(5, "Tuco Franziskaner", "Textures/The Valley of Shadows/Characters/Tuco Franziskaner", "In phase 1, if he has no blue cards in play, he may draw 2 extra cards.", 5);
        characterDeck[55].GetComponent<Card>().SetUpCharacterCard(5, "Big Spencer", "Textures/Wild West Show/Characters/Big Spencer", "Starts with 5 cards and cannot hold more than 5 cards at the end of his turn. He cannot play Missed!", 9);
        characterDeck[56].GetComponent<Card>().SetUpCharacterCard(5, "Flint Westwood", "Textures/Wild West Show/Characters/Flint Westwood", "During his turn, he may trade on card from hand with 2 cards at random from the hand of any other player.", 4);
        characterDeck[57].GetComponent<Card>().SetUpCharacterCard(5, "Gary Looter", "Textures/Wild West Show/Characters/Gary Looter", "He draws all excess cards discarded by other players at the end of their turn.", 5);
        characterDeck[58].GetComponent<Card>().SetUpCharacterCard(5, "Greygory Deck", "Textures/Wild West Show/Characters/Greygory Deck", "At the start of his turn, he may draw 2 characters at random. He has the abilities of those drawn characters.", 4);
        characterDeck[59].GetComponent<Card>().SetUpCharacterCard(5, "John Pain", "Textures/Wild West Show/Characters/John Pain", "If he has less than 6 cards in hand, each time any player tests, he will draw that card.", 4);
        characterDeck[60].GetComponent<Card>().SetUpCharacterCard(5, "Lee van Kliff", "Textures/Wild West Show/Characters/Lee van Klif", "During his turn, he may discard BANG! to repeat an effect of a brown card he just played.", 4);
        characterDeck[61].GetComponent<Card>().SetUpCharacterCard(5, "Teren Kill", "Textures/Wild West Show/Characters/Teren Kill", "Each time he would be eliminated, he tests. If it isn't ♠, he stays at 1 life and draws 1.", 3);
        characterDeck[62].GetComponent<Card>().SetUpCharacterCard(5, "Youl Grinner", "Textures/Wild West Show/Characters/Youl Grinner", "Before drawing in phase 1, players with more cards in hand than him must give him 1 card of their choice.", 4);
        characterDeck = Shuffle(characterDeck);
        int i = 0;
        foreach (GameObject go in characterDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, -90);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }
    }

    private void SetUpRolesDeck()
    {
        roleDeck[0].GetComponent<Card>().SetUpCard(6, "Sheriff", "Textures/Vanilla/Roles/Sceriffo", "Kill all Outlaws and Renegades!");
        roleDeck[1].GetComponent<Card>().SetUpCard(6, "Outlaw", "Textures/Vanilla/Roles/Fuorilegge", "Kill the Sheriff!");
        roleDeck[2].GetComponent<Card>().SetUpCard(6, "Renegade", "Textures/Vanilla/Roles/Rinnegato", "Be the last one in play!");
        roleDeck[3].GetComponent<Card>().SetUpCard(6, "Outlaw", "Textures/Vanilla/Roles/Fuorilegge", "Kill the Sheriff!");
        roleDeck[4].GetComponent<Card>().SetUpCard(6, "Deputy", "Textures/Vanilla/Roles/Vice", "Protect the Sheriff and kill all Outlaws and Renegades!");
        roleDeck[5].GetComponent<Card>().SetUpCard(6, "Outlaw", "Textures/Vanilla/Roles/Fuorilegge", "Kill the Sheriff!");
        roleDeck[6].GetComponent<Card>().SetUpCard(6, "Deputy", "Textures/Vanilla/Roles/Vice", "Protect the Sheriff and kill all Outlaws and Renegades!");
        roleDeck[7].GetComponent<Card>().SetUpCard(6, "Renegade", "Textures/Vanilla/Roles/Rinnegato", "Be the last one in play!");
        //shadow renegate
        roleDeck = Shuffle(roleDeck);
        int i = 0;
        foreach (GameObject go in roleDeck)
        {
            i++;
            go.GetComponent<Card>().FlipCard();
            go.transform.SetParent(GameArea.transform, false);
            go.transform.localPosition = new Vector3(i * 20, 0, 90);
            //go.transform.eulerAngles = Vector3.forward * (r.Next(0, 10) + 355);
        }
    }


    public static List<GameObject> Shuffle(List<GameObject> deck)
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

    /*private void CreatePlayers(int numberOfPlayers)
    {
        for (int i = 0; i < numberOfPlayers; i++) players.Add(Instantiate(Player));

        for (int i = 0; i < numberOfPlayers; i++) gameRoleDeck.Add(roleDeck[i]);

        System.Random rand = new System.Random();
        foreach (GameObject pl in players)
        {
            int x = rand.Next(0, characterDeck.Count);
            int y = rand.Next(0, gameRoleDeck.Count);
            pl.GetComponent<Player>().SetUpPlayerInfo(characterDeck[x].GetComponent<Card>(), gameRoleDeck[y].GetComponent<Card>(), characterDeck[x].GetComponent<Card>().CharacterCardLives);
            characterDeck[x].transform.SetParent(pl.transform, false);
            characterDeck[x].transform.localPosition = new Vector3(-158, 98, 0);
            gameRoleDeck[y].transform.SetParent(pl.transform, false);
            gameRoleDeck[y].transform.localPosition = new Vector3(-158, -98, 0);
            characterDeck[x].GetComponent<Card>().FlipCard();
            characterDeck.RemoveAt(x);
            gameRoleDeck.RemoveAt(y);
        }

        switch (players.Count)
        {
            case 4:
                {
                    players[0].transform.SetParent(this.transform, false);
                    players[0].transform.localPosition = new Vector3(-237, 325f, 0);
                    players[1].transform.SetParent(this.transform, false);
                    players[1].transform.localPosition = new Vector3(237, 325f, 0);
                    players[2].transform.SetParent(this.transform, false);
                    players[2].transform.localPosition = new Vector3(-237, -325f, 0);
                    players[3].transform.SetParent(this.transform, false);
                    players[3].transform.localPosition = new Vector3(237, -325f, 0);
                    break;
                }
            case 5:
                {
                    players[0].transform.SetParent(this.transform, false);
                    players[0].transform.localPosition = new Vector3(-474, 325f, 0);
                    players[1].transform.SetParent(this.transform, false);
                    players[1].transform.localPosition = new Vector3(0, 325f, 0);
                    players[2].transform.SetParent(this.transform, false);
                    players[2].transform.localPosition = new Vector3(474, 325f, 0);
                    players[3].transform.SetParent(this.transform, false);
                    players[3].transform.localPosition = new Vector3(-237, -325f, 0);
                    players[4].transform.SetParent(this.transform, false);
                    players[4].transform.localPosition = new Vector3(237, -325f, 0);
                    break;
                }
            case 6:
                {
                    players[0].transform.SetParent(this.transform, false);
                    players[0].transform.localPosition = new Vector3(-474, 325f, 0);
                    players[1].transform.SetParent(this.transform, false);
                    players[1].transform.localPosition = new Vector3(0, 325f, 0);
                    players[2].transform.SetParent(this.transform, false);
                    players[2].transform.localPosition = new Vector3(474, 325f, 0);
                    players[3].transform.SetParent(this.transform, false);
                    players[3].transform.localPosition = new Vector3(-474, -325f, 0);
                    players[4].transform.SetParent(this.transform, false);
                    players[4].transform.localPosition = new Vector3(0, -325f, 0);
                    players[5].transform.SetParent(this.transform, false);
                    players[5].transform.localPosition = new Vector3(474, -325f, 0);
                    break;
                }
            case 7:
                {
                    players[0].transform.SetParent(this.transform, false);
                    players[0].transform.localPosition = new Vector3(-711, 325f, 0);
                    players[1].transform.SetParent(this.transform, false);
                    players[1].transform.localPosition = new Vector3(-237, 325f, 0);
                    players[2].transform.SetParent(this.transform, false);
                    players[2].transform.localPosition = new Vector3(237, 325f, 0);
                    players[3].transform.SetParent(this.transform, false);
                    players[3].transform.localPosition = new Vector3(711, 325f, 0);
                    players[4].transform.SetParent(this.transform, false);
                    players[4].transform.localPosition = new Vector3(-474, -325f, 0);
                    players[5].transform.SetParent(this.transform, false);
                    players[5].transform.localPosition = new Vector3(0, -325f, 0);
                    players[6].transform.SetParent(this.transform, false);
                    players[6].transform.localPosition = new Vector3(474, -325f, 0);
                    break;
                }
            case 8:
                {
                    players[0].transform.SetParent(this.transform, false);
                    players[0].transform.localPosition = new Vector3(-711, 325f, 0);
                    players[1].transform.SetParent(this.transform, false);
                    players[1].transform.localPosition = new Vector3(-237, 325f, 0);
                    players[2].transform.SetParent(this.transform, false);
                    players[2].transform.localPosition = new Vector3(237, 325f, 0);
                    players[3].transform.SetParent(this.transform, false);
                    players[3].transform.localPosition = new Vector3(711, 325f, 0);
                    players[4].transform.SetParent(this.transform, false);
                    players[4].transform.localPosition = new Vector3(-711, -325f, 0);
                    players[5].transform.SetParent(this.transform, false);
                    players[5].transform.localPosition = new Vector3(-237, -325f, 0);
                    players[6].transform.SetParent(this.transform, false);
                    players[6].transform.localPosition = new Vector3(237, -325f, 0);
                    players[7].transform.SetParent(this.transform, false);
                    players[7].transform.localPosition = new Vector3(711, -325f, 0);
                    break;
                }
        }
    }*/

    /*private void StartGame()
    {
        foreach (GameObject pl in players)
        {
            //Debug.Log("Player lifes: " + pl.GetComponent<Player>().Lifes);
            for (int i = 0; i < pl.GetComponent<Player>().Lifes; i++)
            {
                pl.GetComponent<Player>().DrawCard(cardDeck[0].GetComponent<Card>());
                cardDeck[0].transform.SetParent(pl.transform, false);
                cardDeck[0].transform.localPosition = new Vector3(25 * i, 98, 0);
                cardDeck[0].GetComponent<Card>().FlipCard();
                cardDeck.RemoveAt(0);
            }
        }
    }*/
}
