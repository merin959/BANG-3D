using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public event Action<Player> EndTurn;

    private Player activePlayer;

    void Start()
    {
        instance = this;
        TargetingSystem.instance.ReturnTargetedCard += OnReturnTargettedCard;
    }

    internal void DoTurn(Player activePlayer)
    {
        this.activePlayer = activePlayer;
        activePlayer.CanClick = true;
        DoPhase1(); 
    }

    private void DoPhase1()
    {
                         // v- this number will change with effects and abilities
        for (int i = 0; i < 2; i++)
        {
            Card c = Game.instance.cardDeck[0];
            activePlayer.DrawCard(c);
            Game.instance.cardDeck.RemoveAt(0);
        }
        DoPhase2();
    }

    private void DoPhase2()
    {

    }

    private void DoPhase3()
    {
        activePlayer.CanClick = false;
        activePlayer = null;
        EndTurn?.Invoke(activePlayer);
    }


    private void OnReturnTargettedCard(Player targetedPlayer, Card targettingCard)
    {
        TargetingSystem.instance.HideTarget();
        CardDatabase.instance.GetCardEffect(targettingCard, activePlayer, targetedPlayer);
        //tohle se zmìní po implementaci multiplayeru, tohle je kvùli testování multiplayeri
        //targetedPlayer.Lifes--;
    }
}
