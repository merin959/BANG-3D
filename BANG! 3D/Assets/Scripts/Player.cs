using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int lifes;
    public int Lifes { get { return lifes; } }
    private Card role;
    private Card character;
    private List<Card> cardsInHand;
    private List<Card> cardsInPlay;
    private int gold;

    public void SetUpPlayerInfo(Card role, Card character, int lifes)
    {
        this.role = role;
        this.character = character;
        this.lifes = lifes;
        this.gold = 0;
    }

    public void DrawCard(Card drawnCard)
    {
        //drawnCard.transform.localPosition = new Vector3(cardsInHand.Count * 10, 0, 0);
        //cardInHand.Add(card);
    }
}
