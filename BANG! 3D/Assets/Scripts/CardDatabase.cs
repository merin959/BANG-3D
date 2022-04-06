﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardDatabase : MonoBehaviour
{
    public static CardDatabase instance;

    private static List<Tuple<int, Tuple<string, string, string>, Tuple<string, char?, int?>, int?, Tuple<int?, int?>, int?, int?>> cardDatas;
    public List<Tuple<int, Tuple<string, string, string>, Tuple<string, char?, int?>, int?, Tuple<int?, int?>, int?, int?>> CardDatas => cardDatas;

    private void Awake()
    {
        instance = this;
        cardDatas = new List<Tuple<int, Tuple<string, string, string>, Tuple<string, char?, int?>, int?, Tuple<int?, int?>, int?, int?>>();
        cardDatas.Add(Tuplify(0, "Winchester", "Vanilla/Playing cards/Winchester", "Your shooting distance is 5.", "8", '♠', 1, null, null, null, null, 5));

        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 0", "Deal 1 damage to a player in range.", "A", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 1", "Deal 1 damage to a player in range.", "2", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 2", "Deal 1 damage to a player in range.", "3", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 3", "Deal 1 damage to a player in range.", "4", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 4", "Deal 1 damage to a player in range.", "5", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 5", "Deal 1 damage to a player in range.", "6", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 6", "Deal 1 damage to a player in range.", "7", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 7", "Deal 1 damage to a player in range.", "8", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 8", "Deal 1 damage to a player in range.", "9", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 9", "Deal 1 damage to a player in range.", "10", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 10", "Deal 1 damage to a player in range.", "J", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 11", "Deal 1 damage to a player in range.", "Q", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 12", "Deal 1 damage to a player in range.", "K", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 13", "Deal 1 damage to a player in range.", "A", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 14", "Deal 1 damage to a player in range.", "2", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 15", "Deal 1 damage to a player in range.", "3", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 16", "Deal 1 damage to a player in range.", "4", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 17", "Deal 1 damage to a player in range.", "5", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 18", "Deal 1 damage to a player in range.", "6", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 19", "Deal 1 damage to a player in range.", "7", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 20", "Deal 1 damage to a player in range.", "8", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 21", "Deal 1 damage to a player in range.", "9", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 22", "Deal 1 damage to a player in range.", "J", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 23", "Deal 1 damage to a player in range.", "Q", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Vanilla/Playing cards/Bang! 24", "Deal 1 damage to a player in range.", "K", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Barrel", "Vanilla/Playing cards/Barile 0", "When you are target of a BANG! effect, test a card, if it is ♥, then you are Missed!", "Q", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Barrel", "Vanilla/Playing cards/Barile 1", "When you are target of a BANG! effect, test a card, if it is ♥, then you are Missed!", "K", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Beer", "Vanilla/Playing cards/Bira 0", "Restore 1 life.", "6", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Beer", "Vanilla/Playing cards/Bira 1", "Restore 1 life.", "7", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Beer", "Vanilla/Playing cards/Bira 2", "Restore 1 life.", "8", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Beer", "Vanilla/Playing cards/Bira 3", "Restore 1 life.", "9", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Beer", "Vanilla/Playing cards/Bira 4", "Restore 1 life.", "10", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Beer", "Vanilla/Playing cards/Bira 5", "Restore 1 life.", "J", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Cat Balou", "Vanilla/Playing cards/Cat Balou 0", "Discard a card from any player.", "K", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Cat Balou", "Vanilla/Playing cards/Cat Balou 1", "Discard a card from any player.", "9", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Cat Balou", "Vanilla/Playing cards/Cat Balou 2", "Discard a card from any player.", "10", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Cat Balou", "Vanilla/Playing cards/Cat Balou 3", "Discard a card from any player.", "J", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Stagecoach", "Vanilla/Playing cards/Dilligenza 0", "Draw 2 cards.", "9", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Stagecoach", "Vanilla/Playing cards/Dilligenza 1", "Draw 2 cards.", "9", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Dynamite", "Vanilla/Playing cards/Dinamite", "Test a card, if it is 2♠ -> 9♠, lose 3 lifes and discard this. Else pass Dynamite to a player on your left.", "9", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Duel", "Vanilla/Playing cards/Duello 0", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "Q", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Duel", "Vanilla/Playing cards/Duello 1", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "J", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Duel", "Vanilla/Playing cards/Duello 2", "A target player has to play a BANG!, then you have to do the same, etc. First player failing to play a BANG! loses 1 life.", "10", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "General Store", "Vanilla/Playing cards/Emporio 0", "Reveal one card for any player, each player draws one, going clockwise.", "9", '♣', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "General Store", "Vanilla/Playing cards/Emporio 1", "Reveal one card for any player, each player draws one, going clockwise.", "Q", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Gattling", "Vanilla/Playing cards/Gattling", "Deal 1 damage to all other players.", "10", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Indians!", "Vanilla/Playing cards/Indiani 0", "All other players have to play a BANG! or lose 1 life.", "K", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Indians!", "Vanilla/Playing cards/Indiani 1", "All other players have to play a BANG! or lose 1 life.", "A", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 0", "Cancel the effect of a card with BANG! symbol.", "10", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 1", "Cancel the effect of a card with BANG! symbol.", "J", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 2", "Cancel the effect of a card with BANG! symbol.", "Q", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 3", "Cancel the effect of a card with BANG! symbol.", "K", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 4", "Cancel the effect of a card with BANG! symbol.", "A", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 5", "Cancel the effect of a card with BANG! symbol.", "2", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 6", "Cancel the effect of a card with BANG! symbol.", "3", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 7", "Cancel the effect of a card with BANG! symbol.", "4", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 8", "Cancel the effect of a card with BANG! symbol.", "5", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 9", "Cancel the effect of a card with BANG! symbol.", "6", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 10", "Cancel the effect of a card with BANG! symbol.", "7", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Missed!", "Vanilla/Playing cards/Mancato! 11", "Cancel the effect of a card with BANG! symbol.", "8", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Scope", "Vanilla/Playing cards/Mirino", "You view others with -1 distance.", "A", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Mustang", "Vanilla/Playing cards/Mustang 0", "Others view you with +1 distance.", "8", '♥', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Mustang", "Vanilla/Playing cards/Mustang 1", "Others view you with +1 distance.", "9", '♥', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Panic!", "Vanilla/Playing cards/Panico! 0", "Draw a card from a player at distance 1.", "J", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Panic!", "Vanilla/Playing cards/Panico! 1", "Draw a card from a player at distance 1.", "Q", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Panic!", "Vanilla/Playing cards/Panico! 2", "Draw a card from a player at distance 1.", "A", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Panic!", "Vanilla/Playing cards/Panico! 3", "Draw a card from a player at distance 1.", "8", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Jail", "Vanilla/Playing cards/Prigione 0", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "J", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Jail", "Vanilla/Playing cards/Prigione 1", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "10", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Jail", "Vanilla/Playing cards/Prigione 2", "Test a card, if it is ♥, discard this card, otherwise discard this card and end your turn.", "4", '♥', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Remington", "Vanilla/Playing cards/Remington", "Your shooting distance is 3.", "K", '♣', 1, null, null, null, null, 3));
        cardDatas.Add(Tuplify(0, "Rev. Carabine", "Vanilla/Playing cards/Rev. Carabine", "Your shooting distance is 4.", "A", '♣', 1, null, null, null, null, 4));
        cardDatas.Add(Tuplify(0, "Saloon", "Vanilla/Playing cards/Saloon", "Restore 1 life, then other players also restore 1 life.", "5", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Schofield", "Vanilla/Playing cards/Schofield 0", "Your shooting distance is 2.", "J", '♣', 1, null, null, null, null, 2));
        cardDatas.Add(Tuplify(0, "Schofield", "Vanilla/Playing cards/Schofield 1", "Your shooting distance is 2.", "Q", '♣', 1, null, null, null, null, 2));
        cardDatas.Add(Tuplify(0, "Schofield", "Vanilla/Playing cards/Schofield 2", "Your shooting distance is 2.", "K", '♠', 1, null, null, null, null, 2));
        cardDatas.Add(Tuplify(0, "Volcanic", "Vanilla/Playing cards/Volcanic 0", "Your shooting distance is 1, you can play any number of BANGs!", "10", '♠', 1, null, null, null, null, 1));
        cardDatas.Add(Tuplify(0, "Volcanic", "Vanilla/Playing cards/Volcanic 1", "Your shooting distance is 1, you can play any number of BANGs!", "10", '♣', 1, null, null, null, null, 1));
        cardDatas.Add(Tuplify(0, "Wells Fargo", "Vanilla/Playing cards/Wells Fargo", "Draw 3 cards.", "3", '♥', 0, null, null, null, null, null));//completed
        cardDatas.Add(Tuplify(0, "Winchester", "Vanilla/Playing cards/Winchester", "Your shooting distance is 5.", "8", '♠', 1, null, null, null, null, 5));
        cardDatas.Add(Tuplify(0, "Ace up the Sleeve", "Armed & Dangerous/Playing cards/Asso nella Manica", "Spend 2 load tokens to draw a card.", "A", '♥', 3, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Bandolier", "Armed & Dangerous/Playing cards/Bandoliera", "Spend 1 load token to be able to play one extra BANG! during this turn.", "2", '♥', 3, 1, null, null, null, null));
        cardDatas.Add(Tuplify(0, "BANG!", "Armed & Dangerous/Playing cards/Bang 0", "Deal 1 damage to a player in range.", "6", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Armed & Dangerous/Playing cards/Bang 1", "Deal 1 damage to a player in range.", "2", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Armed & Dangerous/Playing cards/Bang 2", "Deal 1 damage to a player in range.", "2", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Armed & Dangerous/Playing cards/Bang 3", "Deal 1 damage to a player in range.", "3", '♦', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Big Fifty", "Armed & Dangerous/Playing cards/Big Fifty", "Your shooting distance is 6. After you play BANG!, you may spend 1 load token to cancel the targeted player's character ability and cards in play.", "Q", '♠', 3, 1, null, null, null, 6));
        cardDatas.Add(Tuplify(0, "Bomb", "Armed & Dangerous/Playing cards/Bomba", "Can be played on any player. At the start of your turn test a card. If it is ♥ or ♦, pass this to any player. If it is ♣ or ♠, spend two load tokens, if there aren't any on this card, lose 2 lifes and discard this.", "7", '♦', 3, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Buntline Special", "Armed & Dangerous/Playing cards/Buntline Special", "Your shooting distance is 2. After you play BANG!, which gets cancelled, you may spend 1 load token force the target player to discard a card of their choice form their hand.", "J", '♠', 3, 1, null, null, null, 2));
        cardDatas.Add(Tuplify(0, "Bell Tower", "Armed & Dangerous/Playing cards/Campanile", "Spend 1 load token to see all players at distance 1 for the next card you play.", "7", '♣', 3, 1, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Caravan", "Armed & Dangerous/Playing cards/Carovana", "Draw 2 cards. Spend 2 load tokens from any of your cards to draw an additional card.", "2", '♠', 0, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Crate", "Armed & Dangerous/Playing cards/Cassa", "Spend 2 load tokens to cancel the effect of a card with BANG! symbol.", "3", '♥', 3, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Cat Balou", "Armed & Dangerous/Playing cards/Cat Balou", "Discard a card from any player.", "3", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Tumbleweed", "Armed & Dangerous/Playing cards/Cespuglio", "Spend 1 load token to force a player to repeat a test.", "4", '♣', 3, 1, null, null, null, null));
        cardDatas.Add(Tuplify(0, "A Little Nip", "Armed & Dangerous/Playing cards/Cicchetto", "Restore 1 life. Spend 3 load tokens from any of your cards to restore an additional life.", "5", '♥', 0, 3, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Quick Shot", "Armed & Dangerous/Playing cards/Colpo Rapido", "Deal 1 damage to a player in range. Spend 1 load token from any of your cards to shoot an additional different player.", "3", '♠', 0, 1, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Double Barrel", "Armed & Dangerous/Playing cards/Doppia Canna", "Your shooting distance is 1. If your BANG! is ♦, you may spend 1 load token and it can't be cancelled.", "6", '♣', 3, 1, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Flintlock", "Armed & Dangerous/Playing cards/Flintlock", "Deal 1 damage to a player in range. Spend 1 load token, then if this is cancelled, take this back to your hand.", "A", '♠', 0, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Arrow", "Armed & Dangerous/Playing cards/Freccia", "A target players discards a BANG! from their hand or loses 1 life. Spend 1 load token to target one additional differnet player.", "5", '♦', 3, 1, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Whip", "Armed & Dangerous/Playing cards/Frusta", "Spend 3 load tokens to discard any card in play.", "5", '♣', 3, 3, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Beer Keg ", "Armed & Dangerous/Playing cards/Fusto di Birra", "Spend 3 load tokens to restore 1 life.", "4", '♥', 3, 3, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Duck!", "Armed & Dangerous/Playing cards/Giù la Testa!", "Cancel the effect of a card with BANG! symbol. Spend 2 load tokens from any of your cards to add this card back to your hand.", "3", '♦', 3, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Lock Pick", "Armed & Dangerous/Playing cards/Grimaldello", "Spend 3 load tokens to draw 1 card from the hand of any player.", "2", '♣', 3, 3, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Missed!", "Armed & Dangerous/Playing cards/Mancato!", "Cancel the effect of a card with BANG! symbol.", "K", '♠', 0, null, null, null, null, null));//completed
        cardDatas.Add(Tuplify(0, "Reloading", "Armed & Dangerous/Playing cards/Ricarica", "Add 3 load tokens to your cards and/or your character.", "4", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Rust", "Armed & Dangerous/Playing cards/Ruggine", "All other players move 1 load token from each orange card and their characters to your character.", "9", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Squaw", "Armed & Dangerous/Playing cards/Squaw", "Discard any card from play. Spend 2 load tokens from any of your cards to add the discarded card to your hand.", "3", '♦', 0, 2, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Thunderer", "Armed & Dangerous/Playing cards/Thunderer", "Your shooting distance is 3. After you play BANG!, you may spend 1 load token to take the BANG! back to your hand.", "3", '♣', 3, 1, null, null, null, 3));
        cardDatas.Add(Tuplify(0, "Bandidos", "The Valley of Shadows/Playing cards/Bandidos", "Each player chooses one: discard 2 cards from hand (1 if he only haas 1) or lose 1 life.", "Q", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Ghost", "The Valley of Shadows/Playing cards/Fantasma 0", "Play on any eliminated player. That player is back in the game, but cannot gain nor lose any lifes.", "9", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Ghost", "The Valley of Shadows/Playing cards/Fantasma 1", "Play on any eliminated player. That player is back in the game, but cannot gain nor lose any lifes.", "10", '♠', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Escape", "The Valley of Shadows/Playing cards/Fuga", "May be played out of turn. Avoid effects of a brown card (other than BANG!) that includes you as a target.", "3", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Lemat", "The Valley of Shadows/Playing cards/Lemat", "Your shooting distance is 1. During your turn, you may use any card in your hand as a BANG!.", "4", '♦', 1, null, null, null, null, 1));
        cardDatas.Add(Tuplify(0, "Aim", "The Valley of Shadows/Playing cards/Mira", "Play this card together with BANG!. If the target is hit, he loses 2 lifes.", "6", '♣', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Poker", "The Valley of Shadows/Playing cards/Poker", "All other players discard 1 card from their hand at the same time. If no ace was discarded, you may draw up to 2 of those cards.", "J", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Backfire", "The Valley of Shadows/Playing cards/Ritorno di Fiamma", "Counts as Missed! The player who shot is the target of a BANG!.", "Q", '♣', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Saved!", "The Valley of Shadows/Playing cards/Salvo", "May be played out of turn. Prevent anther player from losing 1 life. If he survives, draw 2 cards from deck or from his hand.", "5", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Shotgun", "The Valley of Shadows/Playing cards/Shotgun", "Your shooting distance is 1. Each time you hit a player, he must discard a card of his choice from his hand.", "K", '♠', 1, null, null, null, null, 1));
        cardDatas.Add(Tuplify(0, "Fanning", "The Valley of Shadows/Playing cards/Sventagliata", "Counts as a normal one BANG! per turn. Also targets a player of your choice at distance 1 from the first target with a BANG!.", "2", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Bounty", "The Valley of Shadows/Playing cards/Taglia", "Play on any player. If that player is hit by a card with BANG! effect, the player who shot him draws 1 from the deck.", "9", '♣', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Tomahawk", "The Valley of Shadows/Playing cards/Tomahawk", "Deal 1 damage to a player at distance 2.", "A", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Tornado", "The Valley of Shadows/Playing cards/Tornado", "Each player discards any card from their hand (if possible), then draws 2.", "A", '♣', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Last Call", "The Valley of Shadows/Playing cards/Ultimo Giro", "Restore 1 life. Can be played with only 2 players remaining.", "8", '♦', 0, null, null, null, null, null));//completed
        cardDatas.Add(Tuplify(0, "BANG!", "Dodge City/Playing cards/Bang 0", "Deal 1 damage to a player in range.", "8", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Dodge City/Playing cards/Bang 1", "Deal 1 damage to a player in range.", "5", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Dodge City/Playing cards/Bang 2", "Deal 1 damage to a player in range.", "6", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "BANG!", "Dodge City/Playing cards/Bang 3", "Deal 1 damage to a player in range.", "K", '♣', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Barrel", "Dodge City/Playing cards/Barile", "When you are target of a BANG!, test a card, if it is ♥, then you are Missed!", "A", '♣', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Bible", "Dodge City/Playing cards/Bibbia", "Cancel the effect of a card with BANG! symbol, then draw 1. Cannot be used this turn.", "10", '♥', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Binocular", "Dodge City/Playing cards/Binocolo", "You view others with -1 distance.", "10", '♦', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Beer", "Dodge City/Playing cards/Birra 0", "Restore 1 life.", "6", '♥', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Beer", "Dodge City/Playing cards/Birra 1", "Restore 1 life.", "6", '♠', 0, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Canteen", "Dodge City/Playing cards/Borraccia", "Restore 1 life. Cannot be used this turn.", "7", '♥', 2, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Can Can", "Dodge City/Playing cards/Can Can", "Discard a card from any player. Cannot be used this turn.", "J", '♣', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Ten Gallon Hat", "Dodge City/Playing cards/Cappello", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "J", '♦', 2, null, null, null, null, null));//completed
        cardDatas.Add(Tuplify(0, "Cat Balou", "Dodge City/Playing cards/Cat Balou", "Discard a card from any player.", "8", '♣', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Conestoga", "Dodge City/Playing cards/Conestoga", "Draw a card from a player. Cannot be used this turn.", "9", '♦', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Derringer", "Dodge City/Playing cards/Derringer", "Deal 1 damage to a player at distance 1, then draw 1. Cannot be used this turn.", "7", '♠', 2, null, null, null, null, null));//completed
        cardDatas.Add(Tuplify(0, "Dynamite", "Dodge City/Playing cards/Dinamite", "Deal 1 damage to a player at distance 1, then draw 1. Cannot be used this turn.", "10", '♣', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "General Store", "Dodge City/Playing cards/Emporio", "Reveal one card for any player, each player draws one, going clockwise.", "10", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Buffalo Rifle", "Dodge City/Playing cards/Fucile da Caccia", "Deal 1 damage to any player. Cannot be used this turn.", "Q", '♣', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Howitzer", "Dodge City/Playing cards/Howitzer", "Deal 1 damage to all other players. Cannot be used this turn.", "9", '♠', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Indians!", "Dodge City/Playing cards/Indiani", "All other players have to play a BANG! or lose 1 life.", "5", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Missed!", "Dodge City/Playing cards/Mancato!", "Cancel the effect of a card with BANG! symbol.", "8", '♦', 0, null, null, null, null, null));//completed
        cardDatas.Add(Tuplify(0, "Mustang", "Dodge City/Playing cards/Mustang", "Others view you with +1 distance.", "5", '♥', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Panic!", "Dodge City/Playing cards/Panico!", "Draw a card from a player at distance 1.", "J", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Pepperbox", "Dodge City/Playing cards/Pepperbox", "Deal 1 damage to a player in range. Cannot be used this turn.", "A", '♥', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Iron Plate", "Dodge City/Playing cards/Placca di Ferro 0", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "A", '♦', 2, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Iron Plate", "Dodge City/Playing cards/Placca di Ferro 1", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "Q", '♠', 2, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Pony Express", "Dodge City/Playing cards/Pony Express", "Draw 3 cards. Cannot be used this turn.", "Q", '♦', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Knife", "Dodge City/Playing cards/Pugnale", "Deal 1 damage to a player at distance 1. Cannot be used this turn.", "8", '♥', 2, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Punch", "Dodge City/Playing cards/Pugno", "Deal 1 damage to a player at distance 1.", "10", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Rag Time", "Dodge City/Playing cards/Rag Time", "Play this card and discard any other card to draw a card from any player.", "9", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Remington", "Dodge City/Playing cards/Remington", "Your shooting distance is 3.", "6", '♦', 1, null, null, null, null, 3));
        cardDatas.Add(Tuplify(0, "Rev. Carabine", "Dodge City/Playing cards/Rev. Carabine", "Your shooting distance is 4.", "5", '♠', 1 , null, null, null, null, 4));
        cardDatas.Add(Tuplify(0, "Hideout", "Dodge City/Playing cards/Riparo", "Others view you with +1 distance.", "K", '♦', 1, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Brawl", "Dodge City/Playing cards/Rissa", "Play this card and discard any other card to discard a card from each player.", "J", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Dodge", "Dodge City/Playing cards/Schivata 0", "Cancel the effect of a card with BANG! symbol, then draw 1.", "7", '♦', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Dodge", "Dodge City/Playing cards/Schivata 1", "Cancel the effect of a card with BANG! symbol, then draw 1.", "K", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Sombrero", "Dodge City/Playing cards/Sombrero", "Cancel the effect of a card with BANG! symbol. Cannot be used this turn.", "7", '♣', 2, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(0, "Springfield", "Dodge City/Playing cards/Springfield", "Play this card and discard any other card to deal 1 damage to any player.", "K", '♠', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Tequila", "Dodge City/Playing cards/Tequila", "Play this card and discard any other card to restore 1 life to any player (including yourself).", "9", '♣', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(0, "Whisky", "Dodge City/Playing cards/Whisky", "Play this card and discard any other card to restore 2 lifes.", "Q", '♥', 0, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "High Noon", "High Noon/Mezzogiorno di Fuoco", "Each player loses 1 life at the start of their turn.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "Blessing", "High Noon/Benedizione", "The suit of all cards is ♥.", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(1, "Ghost Town", "High Noon/Città Fantasma", "During their turn, eliminated players return to the game as ghosts. In phase 1, they draw 3 cards and cannot die. At the end of their turn, they are eliminated again.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "Gold Rush", "High Noon/Corsa all'Oro", "The game proceeds counter-clockwise for one round, starting with Sheriff. Effects proceed clockwise.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "The Daltons", "High Noon/I Dalton", "When the Daltons enter play, each player who has any blue cards in front of him, chooses on of them and discards it.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "The Doctor", "High Noon/Il Dottore", "When the Doctor enters play, the player or player still in the game with the least amount of lifes restore 1 life.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "The Reverend", "High Noon/Il Reverendo", "Players cannot play Beer.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "Train Arrival", "High Noon/Il Treno", "Each players draws 1 extra card at the end of phase 1 of his turn.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "Curse", "High Noon/Maledizione", "The suit of all cards is ♠.", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(1, "Hangover", "High Noon/Sbornia", "All character lose their effects.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "The Sermon", "High Noon/Sermone", "Players cannot play BANG!.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "Thirst", "High Noon/Sete", "Each player only draws 1 card in phase 1.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(1, "Shootout", "High Noon/Sparatoria", "Each player can play a second BANG! during his turn.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "A Fistful of Cards", "A Fistful of Cards/Per un Ugno di Carte", "At the beginning of his turn, the player is target of as many BANGs! as the number of the cards in his hand.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Ambush", "A Fistful of Cards/Agguato", "The distance between any two players is 1. This is modified only by cards in play.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Sniper", "A Fistful of Cards/Cecchino", "During your turn, the player may play 2 BANGs! together againts a player, this counts as a BANG! it may be cancelled only by 2 Missed! effects.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Dead Man", "A Fistful of Cards/Dead Man", "During his turn, the player who was eliminated first comes back to play with 2 lifes and 2 cards.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Blood Brothers", "A Fistful of Cards/Fratelli di Sangue", "At the beginning of his turn, each player may give one of his lifes (except the last one) to any other player.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "The Judge", "A Fistful of Cards/Il Giudice", "You cannot play cards in front of you or any other player.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Lasso", "A Fistful of Cards/Lazo", "Cards in play in front of the players have no effect (excluding characters).", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Law of the West", "A Fistful of Cards/Legge del West", "During his phase 1, each player shows the second card he draws. If he can, he must play it during his phase 2.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Hard Liquor", "A Fistful of Cards/Liquore Forte", "Each player may skip his phase 1 to restore 1 life.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Abandoned Mine", "A Fistful of Cards/Miniera Abbandonata", "During his phase 1, each player draws from the discard pile (if it runs out, the from the deck). In phase 3, he discards face down on the deck.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Peyote", "A Fistful of Cards/Peyote", "Instead of drawing in phase 1, each player guesses if the suit of the top card of the deck is red or black. He then draws and shows it; if he guessed right, he keeps it and guesses again; otherwise he proceeds to phase 2.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Ranch", "A Fistful of Cards/Ranch", "At the end of his phase 1, each player may discard once any number of cards from his hand to draw the same number of cards from the deck.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Rinochet", "A Fistful of Cards/Rimbalzo", "Each player may play BANG! againts a card in play in front of any player; the card is discarded if its owner doesn't play a Missed! effect.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Russian Roulette", "A Fistful of Cards/Roulette Russa", "When Russian Roulette enters play, starting from the Sheriff each player must discard Missed!, until one player doesn't; he loses 2 lifes and the Roulette ends.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(2, "Vendetta", "A Fistful of Cards/Vendetta", "At the end of his turn, each player tests. If it is ♥, he plays another turn (at the end of which he doesn't test for this again).", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Wild West Show", "Wild West Show/WWS cards/Wild West Show", "The goal of each player becomes: \"Be the last one in play!\"", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Ambush", "Wild West Show/WWS cards/Bavaglio", "Players cannot talk. Whoever talks, loses 1 life.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Bone Orchard", "Wild West Show/WWS cards/Camposanto", "At the start of their turn, each eliminated player returns to play with 1 life. Deal them roles at random from those of the eliminated players.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Darling Valentine", "Wild West Show/WWS cards/Darling Valentine", "At the start of his turn (before phase 1), each players discards his hand and draws the same number of cards.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Dorothy Rage", "Wild West Show/WWS cards/Dorothy Rage", "During his turn, each player can force another player to play one of his cards.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Helena Zontero", "Wild West Show/WWS cards/Helena Zontero", "When Helena comes into play, test. If it is ♥ or ♦, shuffle all active roles, except for Sheriff and, deal them at random.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Lady Rose of Texas", "Wild West Show/WWS cards/Lady Rosa del Texas", "During his turn, each player can swap places with the player on his right, who then skips his next turn.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Miss Susanna", "Wild West Show/WWS cards/Miss Susanna", "During phase 2, each player must play at least 3 cards. If he doesn't, he loses 1 life.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Showdown", "Wild West Show/WWS cards/Regolamento di Conti", "All cards may be played as they were BANG!. All BANGs! may be played as they were Missed!.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(3, "Sacagaway", "Wild West Show/WWS cards/Sacagaway", "All players play with their hands revealed.", "", null, null, null, null, null, null, null));
        cardDatas.Add(Tuplify(4, "Shot", "Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", "", null, null, null, 1, 0, null, null));
        cardDatas.Add(Tuplify(4, "Shot", "Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", "", null, null, null, 1, 0, null, null));
        cardDatas.Add(Tuplify(4, "Shot", "Gold Rush/Loot cards/Bicchierino", "Any player of your choice restores 1 life.", "", null, null, null, 1, 0, null, null));
        cardDatas.Add(Tuplify(4, "Bottle", "Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", "", null, null, null, 2, 0, null, null));
        cardDatas.Add(Tuplify(4, "Bottle", "Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", "", null, null, null, 2, 0, null, null));
        cardDatas.Add(Tuplify(4, "Bottle", "Gold Rush/Loot cards/Bottiglia", "May be played as Beer, Panic! or BANG!.", "", null, null, null, 2, 0, null, null));
        cardDatas.Add(Tuplify(4, "Calumet", "Gold Rush/Loot cards/Calumet", "♦ cards played by other players have no effect on you.", "", null, null, null, 3, 1, null, null));
        cardDatas.Add(Tuplify(4, "Gun Belt", "Gold Rush/Loot cards/Cinturone", "Your hand size limit at the end of your turn is 8 cards.", "", null, null, null, 2, 1, null, null));
        cardDatas.Add(Tuplify(4, "Partner in Crime", "Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", "", null, null, null, 2, 0, null, null));
        cardDatas.Add(Tuplify(4, "Partner in Crime", "Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", "", null, null, null, 2, 0, null, null));
        cardDatas.Add(Tuplify(4, "Partner in Crime", "Gold Rush/Loot cards/Complice", "May be played as Duel, General Store or Cat Balou.", "", null, null, null, 2, 0, null, null));
        cardDatas.Add(Tuplify(4, "Gold Rush", "Gold Rush/Loot cards/Corsa all'Oro", "Your turn ends. Restore all your lifes then play another turn.", "", null, null, null, 5, 0, null, null));
        cardDatas.Add(Tuplify(4, "Horseshoe", "Gold Rush/Loot cards/Ferro di Cavallo", "Your turn ends. Restore all your lifes then play another turn.", "", null, null, null, 2, 1, null, null));
        cardDatas.Add(Tuplify(4, "Pickaxe", "Gold Rush/Loot cards/Piccone", "During your phase 1 draw 1 additional card.", "", null, null, null, 4, 1, null, null));
        cardDatas.Add(Tuplify(4, "Wanted", "Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", "", null, null, null, 2, 1, null, null));
        cardDatas.Add(Tuplify(4, "Wanted", "Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", "", null, null, null, 2, 1, null, null));
        cardDatas.Add(Tuplify(4, "Wanted", "Gold Rush/Loot cards/Ricercato", "Play on any player. Whoever eliminates that player draws 2 cards and takes 1 golden nugget.", "", null, null, null, 2, 1, null, null));
        cardDatas.Add(Tuplify(4, "Rhum", "Gold Rush/Loot cards/Rum", "Test 4 cards. Restore 1 life for each different suit.", "", null, null, null, 3, 0, null, null));
        cardDatas.Add(Tuplify(4, "Rhum", "Gold Rush/Loot cards/Rum", "Test 4 cards. Restore 1 life for each different suit.", "", null, null, null, 3, 0, null, null));
        cardDatas.Add(Tuplify(4, "Gold Pan", "Gold Rush/Loot cards/Setaccio", "Pay 1 golden nugget to draw 1. You may use this up to 2 times per turn.", "", null, null, null, 3, 1, null, null));
        cardDatas.Add(Tuplify(4, "Boots", "Gold Rush/Loot cards/Stivali", "Each time you lose a life, draw 1.", "", null, null, null, 3, 1, null, null));
        cardDatas.Add(Tuplify(4, "Lucky Charm", "Gold Rush/Loot cards/Talismano", "Each time you lose a life, take 1 golden nugget.", "", null, null, null, 3, 1, null, null));
        cardDatas.Add(Tuplify(4, "Union Pacific", "Gold Rush/Loot cards/Unoion Pacific", "Draw 4 cards.", "", null, null, null, 4, 0, null, null));
        cardDatas.Add(Tuplify(4, "Rucksack", "Gold Rush/Loot cards/Zaino", "Pay 2 golden nuggets to restore 1.", "", null, null, null, 3, 1, null, null));
        cardDatas.Add(Tuplify(5, "Bart Cassidy", "Vanilla/Characters/Bart Cassidy", "Each time he is hit, he draws a card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Black Jack", "Vanilla/Characters/Black Jack", "He shows the second card he draws in phase 1. ", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Calamity Janet", "Vanilla/Characters/Calamity Janet", "She may play BANG! as Missed! and vice versa.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "El Gringo", "Vanilla/Characters/El Gringo", "Each time he is hit by a player, he draws a card from the hand of that player.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Jesse Jones", "Vanilla/Characters/Jesse Jones", "He may draw his first card from the hand of any player.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Jourdonnais", "Vanilla/Characters/Jourdonnais", "Whenever he is a target of a BANG!, he may test a card, if it is ♥, then he is Missed!", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Kit Carlson", "Vanilla/Characters/Kit Carlson", "In phase 1, he looks on top three cards of the deck and chooses two to draw and discards the other one.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Lucky Duke", "Vanilla/Characters/Lucky Duke", "Each time he tests, he flips the top two cards a chooses one.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Paul Regret", "Vanilla/Characters/Paul Regret", "All others see him with +1 distance.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Pedro Ramirez", "Vanilla/Characters/Pedro Ramirez", "In phase 1, he may draw his first card from the discard pile.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Rose Doolan", "Vanilla/Characters/Rose Doolan", "She sees all players with -1 distance.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Sid Ketchum", "Vanilla/Characters/Sid Ketchum", "He may discard two cards to restore 1 life.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Slab the Killer", "Vanilla/Characters/Slab the Killer", "Players need 2 Missed! effects to cancel his BANG!.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Suzy Lafayette", "Vanilla/Characters/Suzy Lafayette", "As soon as she has no cards in hand, she draws a card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Vulture Sam", "Vanilla/Characters/Vulture Sam", "Whenever a player is eliminated, he takes all the cards of that player to his hand.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Willy the Kid", "Vanilla/Characters/Willy the Kid", "He can play any number of BANGs!.", "", null, null, null, null, null, 4, null));// completed
        cardDatas.Add(Tuplify(5, "Al Preacher", "Armed & Dangerous/Characters/Al Preacher", "If another player plays blue or orange card, you may pay 2 load tokens to draw 1 card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Bass Greeves", "Armed & Dangerous/Characters/Bass Greeves", "Once during your turn, you may discard 1 card from your hand to add 2 load tokens to one of your cards.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Bloody Mary", "Armed & Dangerous/Characters/Bloody Mary", "Each time your BANG! is cancelled, draw 1 card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Frankie Canton", "Armed & Dangerous/Characters/Frankie Canton", "Once during your turn, you may take 1 load token from any card and move it on this card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Julie Cutter", "Armed & Dangerous/Characters/Julie Cutter", "Each time a player makes you lose a life, test. If it is ♥ or ♦, they are target of a BANG!.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Mexicali Kid", "Armed & Dangerous/Characters/Mexicali Kid", "Once during your turn, you may pay 2 load tokens to shoot 1 extra BANG! (no card required).", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Miss Abigail", "Armed & Dangerous/Characters/Miss Abigail", "You may ignore effects of brown cards with values J, Q, K and A if you are the only target.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Red Ringo", "Armed & Dangerous/Characters/Red Ringo", "Starts with 4 load tokens. Once during your turn, you may move up to 2 load tokens from here to your cards.", "", null, null, null, null, null, 5, null));
        cardDatas.Add(Tuplify(5, "Apache Kid", "Dodge City/Characters/Apache Kid", "♦ cards played by other players don't effect him.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Belle Star", "Dodge City/Characters/Belle Star", "During her turn, cards in play in front of other players have no effects.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Bill Noface", "Dodge City/Characters/Bill Noface", "In phase 1, he draws 1 card, plus each wound he has.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Chuck Wengam", "Dodge City/Characters/Chuck Wengam", "During his turn, he may choose to lose 1 life to draw 2 cards.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Doc Holyday", "Dodge City/Characters/Doc Holyday", "During his turn, he may once discard 2 cards from his hand to shoot a BANG! to a player in range.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Elena Fuente", "Dodge City/Characters/Elena Fuente", "She may use any card as Missed!.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Greg Digger", "Dodge City/Characters/Greg Digger", "Each time another player is eliminated, he restores 2 lifes.", "", null, null, null, null, null, 4, null));// completed
        cardDatas.Add(Tuplify(5, "Herb Hunter", "Dodge City/Characters/Herb Hunter", "Each time another player is eliminated, he draws 2 cards.", "", null, null, null, null, null, 4, null));// completed
        cardDatas.Add(Tuplify(5, "José Delgado", "Dodge City/Characters/José Delgado", "Twice in his turn, he may discard a blue card form his hand to draw 2 cards.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Molly Stark", "Dodge City/Characters/Molly Stark", "Each time she uses a card from hand out of her turn, she draws a card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Pat Brennan", "Dodge City/Characters/Pat Brennan", "In phase 1, instead of drawing from the deck, he may draw one card in play in front of any other player.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Pixie Pete", "Dodge City/Characters/Pixie Pete", "In phase 1, he draws 3 cards instead of 2.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Sean Mallory", "Dodge City/Characters/Sean Mallory", "He may hold up to 10 cards at the end of his turn.", "", null, null, null, null, null, 4, null));// completed
        cardDatas.Add(Tuplify(5, "Tequila Joe", "Dodge City/Characters/Tequila Joe", "Each time he plays a Beer, he restores 2 lifes instead of 1.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Vera Custer", "Dodge City/Characters/Vera Custer", "Before phase 1, she chooses another character in play and gains its effect until the start of her next turn.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Don Bell", "Gold Rush/Characters/Don Bell", "At the end of his turn, he tests. If it is ♥ or ♦, he plays an extra turn (at the end of which he doesn't test for this again).", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Dutch Will", "Gold Rush/Characters/Dutch Will", "In phase 1, he draws 2 cards, chooses 1 to discards and takes 1 gold nugget.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Jacky Murieta", "Gold Rush/Characters/Jacky Murieta", "During his turn, he may pay 2 gold nuggets to shoot 1 extra BANG! (no card required).", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Josh McCloud", "Gold Rush/Characters/Josh McCloud", "He may draw the top equipment from the equipment deck by paying 2 gold nuggets.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Madame Yto", "Gold Rush/Characters/Madame Yto", "Each time a Beer is played, she draws 1.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Pretty Luzena", "Gold Rush/Characters/Pretty Luzena", "Once per turn, she may buy 1 equipment at a cost reduced by 1 gold nugget.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Raddie Snake", "Gold Rush/Characters/Raddie Snake", "Twice in his turn, he may pay 1 gold nugget to draw 1.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Simeon Picos", "Gold Rush/Characters/Simeon Picos", "Each time he loses 1 life, he takes 1 gold nugget.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Black Flower", "The Valley of Shadows/Characters/Black Flower", "Once during her turn, she may use any ♣ card as an extra BANG!.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Colorado Bill", "The Valley of Shadows/Characters/Colorado Bill", "Each time he plays a BANG!, he tests. If it is ♠, it cannot be cancelled.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Der Spot - Burst Ringer", "The Valley of Shadows/Characters/Der Spot", "Once during his turn, he may use a BANG! as a Gattling.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Evelyn Shebang", "The Valley of Shadows/Characters/Evelyn Shabang", "She may skip phase 1. For each card skipped, she may shoot a BANG! at a different player in range.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Henry Block", "The Valley of Shadows/Characters/Henry Block", "In player drawing or discarding on of his cards (in hand or in play) is a target of a BANG!.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Lemonade Jim", "The Valley of Shadows/Characters/Lemonade Jim", "Each time another player plays Beer, he may discard any card from his hand to also restore 1 life.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Mick Defender", "The Valley of Shadows/Characters/Mick Defender", "If he is a target of a brown card other than BANG!, he may use Missed! to avoid that card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Tuco Franziskaner", "The Valley of Shadows/Characters/Tuco Franziskaner", "In phase 1, if he has no blue cards in play, he may draw 2 extra cards.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Big Spencer", "Wild West Show/Characters/Big Spencer", "Starts with 5 cards and cannot hold more than 5 cards at the end of his turn. He cannot play Missed!", "", null, null, null, null, null, 9, null));// completed
        cardDatas.Add(Tuplify(5, "Flint Westwood", "Wild West Show/Characters/Flint Westwood", "During his turn, he may trade on card from hand with 2 cards at random from the hand of any other player.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Gary Looter", "Wild West Show/Characters/Gary Looter", "He draws all excess cards discarded by other players at the end of their turn.", "", null, null, null, null, null, 5, null));
        cardDatas.Add(Tuplify(5, "Greygory Deck", "Wild West Show/Characters/Greygory Deck", "At the start of his turn, he may draw 2 characters at random. He has the abilities of those drawn characters.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "John Pain", "Wild West Show/Characters/John Pain", "If he has less than 6 cards in hand, each time any player tests, he will draw that card.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Lee van Kliff", "Wild West Show/Characters/Lee van Klif", "During his turn, he may discard BANG! to repeat an effect of a brown card he just played.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(5, "Teren Kill", "Wild West Show/Characters/Teren Kill", "Each time he would be eliminated, he tests. If it isn't ♠, he stays at 1 life and draws 1.", "", null, null, null, null, null, 3, null));
        cardDatas.Add(Tuplify(5, "Youl Grinner", "Wild West Show/Characters/Youl Grinner", "Before drawing in phase 1, players with more cards in hand than him must give him 1 card of their choice.", "", null, null, null, null, null, 4, null));
        cardDatas.Add(Tuplify(6, "Sheriff", "Vanilla/Roles/Sceriffo", "Kill all Outlaws and Renegades!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Outlaw", "Vanilla/Roles/Fuorilegge", "Kill the Sheriff!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Renegade", "Vanilla/Roles/Rinnegato", "Be the last one in play!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Outlaw", "Vanilla/Roles/Fuorilegge", "Kill the Sheriff!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Deputy", "Vanilla/Roles/Vice", "Protect the Sheriff and kill all Outlaws and Renegades!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Outlaw", "Vanilla/Roles/Fuorilegge", "Kill the Sheriff!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Deputy", "Vanilla/Roles/Vice", "Protect the Sheriff and kill all Outlaws and Renegades!", "", null, null, null, null, null, null, null));// completed
        cardDatas.Add(Tuplify(6, "Renegade", "Vanilla/Roles/Rinnegato", "Be the last one in play!", "", null, null, null, null, null, null, null));// completed
        //shadow renegate}*/
    }

    private Tuple<int, Tuple<string, string, string>, Tuple<string, char?, int?>, int?, Tuple<int?, int?>, int?, int?> Tuplify(int cardType, string cardName, string cardPath, string cardDescription, string playingCardValue, char? playingCardColor, int? playingCardType, int? numberOfLoadTokens, int? lootCardCost, int? lootCardType, int? characterCardLives, int? shootingDistance)
    {
        return Tuple.Create(cardType, Tuple.Create(cardName, "Textures/" + cardPath, cardDescription), Tuple.Create(playingCardValue, playingCardColor, playingCardType), numberOfLoadTokens, Tuple.Create(lootCardCost, lootCardType), characterCardLives, shootingDistance);
    }

    public void GetCardEffect(Card targettingCard, Player targettingPlayer, Player targettedPlayer)
    {
        switch (targettingCard.CardName)
        {
            case "BANG!":
                {
                    if (targettingPlayer.CanPlayBangThisTurn)
                    {
                        if (targettedPlayer.CheckForBangResponse(targettingPlayer))
                        {
                            targettingPlayer.Gold++;
                            CheckIfPlayerDied(targettingCard, targettingPlayer, targettedPlayer);
                        }
                        targettingPlayer.CanPlayBangThisTurn = false;
                    }
                    else Game.instance.InfoMessage.text = "You cannot play more than one BANG! in one turn.";
                    break;
                }
            case "Beer":
                {
                    if (Game.instance.players.Count <= 2) { Game.instance.InfoMessage.text = "You cannot play Beer with only two players alive."; }
                    else targettingPlayer.Lifes++;
                    break;
                }
            case "Canteen":
                {
                    targettingPlayer.Lifes++;
                    break;
                }
            case "Saloon":
                {
                    foreach (Player pl in Game.instance.players) pl.Lifes++;
                    break;
                }
            case "Last Call":
                {
                    if (Game.instance.players.Count != 2) { Game.instance.InfoMessage.text = "Can be played only with two players remaining."; }
                    else targettingPlayer.Lifes++;
                    break;
                }
            case "Stagecoach":
                {
                    for (int i = 0; i < 2; i++) { Game.instance.cardDeck.First().FlipCard(); targettingPlayer.DrawCard(Game.instance.cardDeck.First()); }
                    Game.instance.FlipEffectCards(Game.instance.wildWestDeck, 2);
                    break;
                }
            case "Wells Fargo":
                {
                    for (int i = 0; i < 3; i++) { Game.instance.cardDeck.First().FlipCard(); targettingPlayer.DrawCard(Game.instance.cardDeck.First()); }
                    Game.instance.FlipEffectCards(Game.instance.wildWestDeck, 2);
                    break;
                }
            case "Derringer":
                {
                    if (targettedPlayer.CheckForBangResponse(targettingPlayer))
                    {
                        targettingPlayer.Gold++;
                        CheckIfPlayerDied(targettingCard, targettingPlayer, targettedPlayer);
                    }
                    Game.instance.cardDeck.First().FlipCard();
                    targettingPlayer.DrawCard(Game.instance.cardDeck.First());
                    break;
                }
            case "Missed": case "Ten Gallon Hat": case "Iron Plate": case "Sombrero":
                {
                    break;
                }
        }
    }

    private void CheckIfPlayerDied(Card targettingCard, Player targettingPlayer, Player targettedPlayer)
    {
        if (targettedPlayer.Lifes <= 0)
        {
            if (targettedPlayer.Role.CardName == "Outlaw")
            {
                for (int i = 0; i < 3; i++)
                {
                    Game.instance.cardDeck.First().FlipCard();
                    TurnManager.instance.ActivePlayer.DrawCard(Game.instance.cardDeck.First());
                }
            }
            else if (targettedPlayer.Role.CardName == "Deputy" && targettingPlayer.Role.CardName == "Sheriff")
            {
                List<Card> cardsToRemove = new List<Card>();
                for (int i = 0; i < targettingPlayer.CardsInHand.Count; i++)
                {
                    Card c1 = targettingPlayer.CardsInHand[i];
                    c1.transform.localPosition = new Vector3(10, Game.instance.discardDeck.Count * 0.02f, 0);
                    Game.instance.discardDeck.Add(c1);
                    cardsToRemove.Add(c1);
                    c1.CanBeMoved = false;
                }
                cardsToRemove.ForEach(c => targettingPlayer.RemoveCardFromHand(c, false));
                cardsToRemove.Clear();

                for (int i = 0; i < targettingPlayer.CardsInPlay.Count; i++)
                {
                    Card c2 = targettingPlayer.CardsInPlay[i];
                    c2.transform.localPosition = new Vector3(10, Game.instance.discardDeck.Count * 0.02f, 0);
                    Game.instance.discardDeck.Add(c2);
                    cardsToRemove.Add(c2);
                    c2.CanBeMoved = false;
                }
                cardsToRemove.ForEach(c => targettingPlayer.RemoveCardFromPlay(c, false));
            }
        }
    }
}