using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public event Action<Player> EndTurn;

    private Player activePlayer;

    private int activePhase;
    public int ActivePhase => activePhase;

    void Start()
    {
        instance = this;
        TargetingSystem.instance.ReturnTargetedCard += OnReturnTargettedCard;
    }

    internal void DoTurn(Player activePlayer)
    {
        activePhase = 1;
        this.activePlayer = activePlayer;
        activePlayer.CanClick = true;
        Debug.Log("Draw Cards");
    }

    private void DoPhase1()
    {
        activePhase++;
        Debug.Log("Play turn");
        // v- this number will change with effects and abilities
        for (int i = 0; i < 2; i++) activePlayer.DrawCard(Game.instance.cardDeck.First());
    }

    private void DoPhase2()
    {
        activePhase++;
        Debug.Log("Discrad cards");
    }

    private void DoPhase3()
    {
        activePhase++;
        Debug.Log("Turn ended");
        activePlayer.CanClick = false;
        //EndTurn?.Invoke(activePlayer);
        Game.instance.photonView.RPC("OnEndTurn", RpcTarget.AllBuffered);
        DoTurn(Game.instance.activePlayer);
    }


    private void OnReturnTargettedCard(Player targetedPlayer, Card targettingCard)
    {
        TargetingSystem.instance.HideTarget();
        try
        {
            foreach (Player _player in Game.instance.players)
            {
                _player.photonView.RPC("SetUpCardsInHand", RpcTarget.AllBuffered);
                _player.photonView.RPC("SetUpCardsInPlay", RpcTarget.AllBuffered);
                _player.photonView.RPC("SetUpUI", RpcTarget.AllBuffered);
            }
        }
        catch { }
        CardDatabase.instance.GetCardEffect(targettingCard, activePlayer, targetedPlayer);
        //tohle se zmìní po implementaci multiplayeru, tohle je kvùli testování multiplayeri
        //targetedPlayer.Lifes--;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && activePlayer.photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            switch (activePhase)
            {
                case 1: { DoPhase1(); break; }
                case 2: { DoPhase2(); break; }
                case 3:
                    {
                        if (activePlayer.CardsInHand.Count > activePlayer.MaximumCardsInHand) { Debug.Log("Too much cards in hand"); break; }
                        else DoPhase3();
                        return;
                    }
            }
        }
    }
}
