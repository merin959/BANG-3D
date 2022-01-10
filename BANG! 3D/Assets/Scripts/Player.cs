using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;   //delete after real player names
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string playerName;
    private int lifes;
    public int Lifes { get { return lifes; } }
    private Card role;
    public Card Role
    {
        get { return role; }
        set { role = value; }
    }
    private Card mainCharacter;
    private Card secondaryCharacter;
    private List<Card> cardsInHand;
    private List<Card> cardsInPlay;
    public List<Card> Characters { get { return new List<Card>() { mainCharacter, secondaryCharacter }; } }
    private int gold;
    private Vector3 cardPositions;
    public Vector3 CardPositions
    {
        get { return cardPositions; }
        set { cardPositions = value; }
    }

    private bool isTopOrBottom;

    public void SetUpPlayerInfo(Card mainCharacter, Card secondaryCharacter, Card role, bool isTopOrBottom)
    {
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
        //drawnCard.transform.localPosition = new Vector3(cardsInHand.Count * 10, 0, 0);
        //cardInHand.Add(card);
    }

    public static string RandomString(int length)
    {
        System.Random random = new System.Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
