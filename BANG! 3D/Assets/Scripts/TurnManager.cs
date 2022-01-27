using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public event Action<Player> EndTurn;
    void Start()
    {
        instance = this;
    }

    internal void DoTurn(Player activePlayer)
    {
        DoPhase1(activePlayer);
        DoPhase2(activePlayer);
        DoPhase3(activePlayer);
    }

    private void DoPhase1(Player activePlayer)
    {
                         // v- this number will change with effects and abilities
        for (int i = 0; i < 2; i++)
        {
            Card c = Game.instance.cardDeck[0];
            c.FlipCard();
            activePlayer.DrawCard(c);
            Game.instance.cardDeck.RemoveAt(0);
        }
        /*activePlayer.FixCardAngles();
        Card cc = Game.instance.cardDeck[0];
        cc.FlipCard();
        activePlayer.DrawCard(cc);
        Game.instance.cardDeck.RemoveAt(0);*/
        //activePlayer.FixCardAngles();
    }
    private void DoPhase2(Player activePlayer)
    {

    }
    private void DoPhase3(Player activePlayer)
    {

    }
}
