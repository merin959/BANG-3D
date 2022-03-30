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
        TargetingSystem.instance.ReturnTargetedCard += OnReturnTargettedCard;
    }

    internal void DoTurn(Player activePlayer)
    {
        DoPhase1(activePlayer); 
    }

    private void DoPhase1(Player activePlayer)
    {
                         // v- this number will change with effects and abilities
        for (int i = 0; i < 2; i++)
        {
            Card c = Game.instance.cardDeck[0];
            activePlayer.DrawCard(c);
            Game.instance.cardDeck.RemoveAt(0);
        }
        /*activePlayer.FixCardAngles();
        Card cc = Game.instance.cardDeck[0];
        cc.FlipCard();
        activePlayer.DrawCard(cc);
        Game.instance.cardDeck.RemoveAt(0);*/
        //activePlayer.FixCardAngles();
        DoPhase2(activePlayer);
    }

    private void DoPhase2(Player activePlayer)
    {

    }
    private void DoPhase3(Player activePlayer)
    {
        //EndTurn?.Invoke(activePlayer);
    }


    private void OnReturnTargettedCard(Player targetedPlayer)
    {
        TargetingSystem.instance.HideTarget();
        //tohle se zmìní po implementaci multiplayeru, tohle je kvùli testování multiplayeri
        targetedPlayer.Lifes--;
    }
}
