using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using System.Linq;

public class Player : MonoBehaviourPun, IPunInstantiateMagicCallback     //fix card angles
{
    private string playerName;
    public string PlayerName => playerName;
    private int? lifes;
    public int? Lifes
    {
        get { return lifes; }
        set
        {
            lifes = value;
            //vy�e�it vedle atd...
            photonView.RPC("SetUpUI", RpcTarget.AllBuffered);
        }
    }
    public int? MaximumCardsInHand { get { return (mainCharacter.CardName == "Big Spencer" && lifes > 5) ? 5 : lifes; } }
    private Card role;
    public Card Role
    {
        get { return role; }
        set { role = value; }
    }
    private Card mainCharacter;
    public Card MainCharacter { get { return mainCharacter; } }
    private Card secondaryCharacter;
    public Card SecondaryCharacter { get { return secondaryCharacter; } }
    private List<Card> cardsInHand;
    public List<Card> CardsInHand { get { return cardsInHand; } }
    private List<Card> cardsInPlay;
    public List<Card> CardsInPlay { get { return cardsInPlay; } }
    public List<Card> Characters { get { return new List<Card>() { mainCharacter, secondaryCharacter }; } }
    private int gold;
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            photonView.RPC("SetUpUI", RpcTarget.AllBuffered);
        }
    }
    private Vector3 cardPositions;
    public Vector3 CardPositions
    {
        get { return cardPositions; }
        set { cardPositions = value; }
    }

    private bool isTopOrBottom;
    public bool IsTopOrBottom { get { return isTopOrBottom; } set { isTopOrBottom = value; } }

    private float MAX_X_IN_PLAY = 17.4f;
    private float MAX_Z_IN_PLAY = 28.5f;

    private bool canClick;
    public bool CanClick
    {
        get { return canClick; }
        set { canClick = value; }
    }

    private bool hasActivatedEasterEgg;
    public bool HasActivatedEasterEgg
    {
        get { return hasActivatedEasterEgg; }
        set { hasActivatedEasterEgg = value; }
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        SetUpInfo(info.photonView.InstantiationData);
        HasActivatedEasterEgg = false;
    }

    [PunRPC]
    public void SetUpInfo(object[] datas)
    {
        int ii = (int)datas[2];
        canClick = false;
        cardsInHand = new List<Card>();
        cardsInPlay = new List<Card>();
        transform.SetParent(Canvas.instance.transform.Find("PlayerAreas").transform, false);
        Role = Game.instance.roleDeck[ii];
        mainCharacter = Game.instance.characterDeck[ii];
        //secondaryCharacter = Game.instance.characterDeck.First();

        Lifes = mainCharacter.CharacterCardLives;
        Gold = 0;
        playerName = (string)datas[1];

        IsTopOrBottom = (bool)datas[0];

        if (role.CardName == "Sheriff") transform.Find("PlayerName").GetComponent<Text>().color = new Color(227, 182, 0);

        transform.Find("PlayerName").GetComponent<Text>().text = PlayerName;
        transform.Find("NumberOfGold").GetComponent<Text>().text = gold.ToString();
        transform.Find("NumberOfLives").GetComponent<Text>().text = lifes + "";

        if (!isTopOrBottom)
        {
            transform.Find("PlayerName").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("PlayerName").GetComponent<RectTransform>().localPosition.x, -transform.Find("PlayerName").GetComponent<RectTransform>().localPosition.y, transform.Find("PlayerName").GetComponent<RectTransform>().localPosition.z);
            transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition.x, -transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition.y, transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition.z);
            transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition.x, -transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition.y, transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition.z);
            transform.Find("BulletImage").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("BulletImage").GetComponent<RectTransform>().localPosition.x, -transform.Find("BulletImage").GetComponent<RectTransform>().localPosition.y, transform.Find("BulletImage").GetComponent<RectTransform>().localPosition.z);
            transform.Find("GoldImage").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("GoldImage").GetComponent<RectTransform>().localPosition.x, -transform.Find("GoldImage").GetComponent<RectTransform>().localPosition.y, transform.Find("GoldImage").GetComponent<RectTransform>().localPosition.z);
        }
    }

    public void DrawCard(Card drawnCard)
    {
        cardsInHand.Add(drawnCard);
        if (photonView.IsMine) drawnCard.FlipCard();
        SetUpCardsInHand();
        SetUpCardsInPlay();
    }

    public void AddCardToPlay(Card cardToBeMovedToHand)
    {
        cardsInPlay.Add(cardToBeMovedToHand);
        SetUpCardsInHand();
        SetUpCardsInPlay();
    }

    public void RemoveCardFromHand(Card cardToRemove)
    {
        cardsInHand.Remove(cardToRemove);
        SetUpCardsInHand();
    }

    [PunRPC]
    internal void SetUpCardsInHand()
    {
        int j = 0;
        for (int i = -CardsInHand.Count / 2; i < CardsInHand.Count / 2 + CardsInHand.Count % 2; i++)
        {
            cardsInHand[j].transform.eulerAngles = new Vector3(cardsInHand[j].transform.eulerAngles.x, 0, cardsInHand[j].transform.eulerAngles.z);
            CardsInHand[j].transform.localPosition = new Vector3(
                Characters[0].transform.localPosition.x + (CardsInHand.Count % 2 == 0 ? 2.5f : 0) + i * 5f,
                j * 0.01f,
                Characters[0].transform.localPosition.z > 0 ?
                (CardsInHand.Count % 2 == 0 ? Characters[0].transform.localPosition.z - 8f + Math.Abs(i >= 0 ? i + 1 : i) * 0.5f : Characters[0].transform.localPosition.z - 8f + Math.Abs(i) * 0.5f) :
                CardsInHand.Count % 2 == 0 ? Characters[0].transform.localPosition.z + 8f - Math.Abs(i >= 0 ? i + 1 : i) * 0.5f : Characters[0].transform.localPosition.z + 8f - Math.Abs(i) * 0.5f);
            if (isTopOrBottom) CardsInHand[j].transform.Rotate(0, CardsInHand[j].IsFlipped ? -((CardsInHand.Count % 2 == 0 ? 3.5f : 0) + i * 5f + 180) : ((CardsInHand.Count % 2 == 0 ? 3.5f : 0) + i * 5f + 180), 0);
            else CardsInHand[j].transform.Rotate(0, CardsInHand[j].IsFlipped ? -((CardsInHand.Count % 2 == 0 ? -3.5f : 0) - i * 5f) : ((CardsInHand.Count % 2 == 0 ? -3.5f : 0) - i * 5f), 0);
            j++;
        }
    }

    [PunRPC]
    internal void SetUpCardsInPlay()
    {
        for (int i = 0; i < CardsInPlay.Count; i++)
        {
            CardsInPlay[i].transform.localPosition = new Vector3(
                CardsInPlay.Count - 1 != 0 ? Characters[0].transform.localPosition.x - MAX_X_IN_PLAY + 2 * i * MAX_X_IN_PLAY / (CardsInPlay.Count - 1) : Characters[0].transform.localPosition.x,
                i * 0.01f,
                IsTopOrBottom ? Characters[0].transform.localPosition.z - MAX_Z_IN_PLAY : Characters[0].transform.localPosition.z + MAX_Z_IN_PLAY
                );
            CardsInPlay[i].transform.rotation = Quaternion.identity;
        }
    }

    [PunRPC]
    public void SetUpUI()
    {
        transform.Find("PlayerName").GetComponent<Text>().text = PlayerName;
        transform.Find("NumberOfGold").GetComponent<Text>().text = gold.ToString();
        transform.Find("NumberOfLives").GetComponent<Text>().text = lifes + "";
    }
}
