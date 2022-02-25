using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;   //delete after real player names
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    PhotonView view;

    private string playerName;
    private int lifes;
    public int Lifes
    {
        get { return lifes; }
        set
        {
            lifes = value;
            //vyøešit vedle atd...
            transform.Find("NumberOfLives").GetComponent<Text>().text = lifes + "";
        }
    }
    public int MaximumCardsInHand { get { return (mainCharacter.CardName == "Big Spencer" && lifes > 5) ? 5 : lifes; } }
    private Card role;
    public Card Role
    {
        get { return role; }
        set { role = value; }
    }
    private Card mainCharacter;
    public Card MainCharacter { get { return mainCharacter; } }
    private Card secondaryCharacter;
    private List<Card> cardsInHand;
    public List<Card> CardsInHand { get { return cardsInHand; } }
    private List<Card> cardsInPlay;
    public List<Card> CardsInPlay { get { return cardsInPlay; } }
    public List<Card> Characters { get { return new List<Card>() { mainCharacter, secondaryCharacter }; } }
    private int gold;
    private Vector3 cardPositions;
    public Vector3 CardPositions
    {
        get { return cardPositions; }
        set { cardPositions = value; }
    }

    private bool isTopOrBottom;
    public bool IsTopOrBottom { get { return isTopOrBottom; } }

    private float MAX_X_IN_PLAY = 17.4f;
    private float MAX_Z_IN_PLAY = 28.5f;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }   

    public void SetUpPlayerInfo(Card mainCharacter, Card secondaryCharacter, Card role, bool isTopOrBottom)
    {
        cardsInHand = new List<Card>();
        cardsInPlay = new List<Card>();
        this.playerName = RandomString(25);
        this.role = role;
        this.mainCharacter = mainCharacter;
        this.secondaryCharacter = secondaryCharacter;
        this.lifes = mainCharacter.CharacterCardLives;
        this.gold = 0;
        this.isTopOrBottom = isTopOrBottom;
        SetUpInfo();
    }

    public void SetUpInfo(){ 
        transform.Find("PlayerName").GetComponent<Text>().text = playerName;
        if (role.CardName == "Sheriff") transform.Find("PlayerName").GetComponent<Text>().color = new Color(227, 182, 0);
        if(!isTopOrBottom) transform.Find("PlayerName").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("PlayerName").GetComponent<RectTransform>().localPosition.x, -transform.Find("PlayerName").GetComponent<RectTransform>().localPosition.y, transform.Find("PlayerName").GetComponent<RectTransform>().localPosition.z);
        transform.Find("NumberOfLives").GetComponent<Text>().text = lifes.ToString();
        if (!isTopOrBottom) transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition.x, -transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition.y, transform.Find("NumberOfLives").GetComponent<RectTransform>().localPosition.z);
        transform.Find("NumberOfGold").GetComponent<Text>().text = gold.ToString();
        if (!isTopOrBottom) transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition.x, -transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition.y, transform.Find("NumberOfGold").GetComponent<RectTransform>().localPosition.z);
        if (!isTopOrBottom) transform.Find("BulletImage").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("BulletImage").GetComponent<RectTransform>().localPosition.x, -transform.Find("BulletImage").GetComponent<RectTransform>().localPosition.y, transform.Find("BulletImage").GetComponent<RectTransform>().localPosition.z);
        if (!isTopOrBottom) transform.Find("GoldImage").GetComponent<RectTransform>().localPosition = new Vector3(transform.Find("GoldImage").GetComponent<RectTransform>().localPosition.x, -transform.Find("GoldImage").GetComponent<RectTransform>().localPosition.y, transform.Find("GoldImage").GetComponent<RectTransform>().localPosition.z);
    }

    public void DrawCard(Card drawnCard)
    {
        cardsInHand.Add(drawnCard);
        SetUpCardsInHand();
        FixCardAngles();
    }

    public void AddCardToPlay(Card cardToBeMovedToHand)
    {
        cardsInPlay.Add(cardToBeMovedToHand);
        SetUpCardsInPlay();
        //foreach (Card c in CardsInHand) c.transform.eulerAngles = new Vector3(c.transform.eulerAngles.x, -c.transform.eulerAngles.y, c.transform.eulerAngles.z);
    }

    public void RemoveCardFromHand(Card cardToRemove)
    {
        cardsInHand.Remove(cardToRemove);
        SetUpCardsInHand();
        FixCardAngles();
    }

    private static string RandomString(int length)
    {
        System.Random random = new System.Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

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
                (CardsInHand.Count % 2 == 0 ? Characters[0].transform.localPosition.z - 8f  + Math.Abs(i >= 0 ? i + 1: i) * 0.5f: Characters[0].transform.localPosition.z - 8f + Math.Abs(i) * 0.5f) :
                CardsInHand.Count % 2 == 0 ? Characters[0].transform.localPosition.z + 8f - Math.Abs(i >= 0 ? i + 1: i) * 0.5f : Characters[0].transform.localPosition.z + 8f - Math.Abs(i) * 0.5f);
            if (isTopOrBottom) CardsInHand[j].transform.Rotate(0, (CardsInHand.Count % 2 == 0 ? 3.5f : 0) + i * 5f + 180, 0);
            else CardsInHand[j].transform.Rotate(0, (CardsInHand.Count % 2 == 0 ? -3.5f : 0) - i * 5f, 0);
            j++;
        }
        SetUpCardsInPlay();
    }

    internal void SetUpCardsInPlay()
    {
        for (int i = 0; i < CardsInPlay.Count; i++)
        {
            CardsInPlay[i].transform.localPosition = new Vector3(
                CardsInPlay.Count - 1 != 0 ? Characters[0].transform.localPosition.x - MAX_X_IN_PLAY + 2 * i * MAX_X_IN_PLAY / (CardsInPlay.Count - 1) : Characters[0].transform.localPosition.x,
                i * 0.01f,
                IsTopOrBottom ? Characters[0].transform.localPosition.z - MAX_Z_IN_PLAY : Characters[0].transform.localPosition.z + MAX_Z_IN_PLAY
                );
        }
    }

    internal void FixCardAngles()
    {
        foreach (Card c in CardsInHand) c.transform.eulerAngles = new Vector3(c.transform.eulerAngles.x, -c.transform.eulerAngles.y, c.transform.eulerAngles.z);
    }
}
