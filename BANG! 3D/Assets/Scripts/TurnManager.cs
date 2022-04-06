using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    private Player activePlayer;
    public Player ActivePlayer => activePlayer;

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
        this.activePlayer.CanPlayBangThisTurn = true;
        foreach (Card c in this.activePlayer.CardsInHand) c.FlipCard();
        activePlayer.CanClick = true;
        Game.instance.InfoMessage.text = "Phase 1: Press enter to draw cards.";
    }

    private void DoPhase1()
    {
        activePhase++;
        Game.instance.InfoMessage.text = "Phase 2: You can now play cards, press enter to end Phase 2.";
        // v- this number will change with effects and abilities
        for (int i = 0; i < 2; i++)
        {
            Game.instance.cardDeck.First().FlipCard();
            activePlayer.DrawCard(Game.instance.cardDeck.First());
        }
    }

    private void DoPhase2()
    {
        activePhase++;
        Game.instance.InfoMessage.text = "Phase 3: You can now discard excess cards, press enter to end your turn.";
    }

    private void DoPhase3()
    {
        activePlayer.CanClick = false;
        Game.instance.OnEndTurn(activePlayer);
    }

    private void OnReturnTargettedCard(Player targetedPlayer, Card targettingCard)
    {
        TargetingSystem.instance.HideTarget();
        CardDatabase.instance.GetCardEffect(targettingCard, activePlayer, targetedPlayer);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && !TargetingSystem.instance.IsActive && !Game.instance.IsDragAndDropActive)
        {
            switch (activePhase)
            {
                case 1: { DoPhase1(); break; }
                case 2: { DoPhase2(); break; }
                case 3:
                    {
                        if (activePlayer.CardsInHand.Count > activePlayer.MaximumCardsInHand) { Game.instance.InfoMessage.text = "You have too much cards in hand. You need to discard some!"; break; }
                        else DoPhase3();
                        break;
                    }
            }
        }
    }
}
