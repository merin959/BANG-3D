using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private int cardType;             // 0 = playing card, 1 = High Noon card, 2 = Fistful card, 3 = Wild West card, 4 = Gold Rush loot card, 5 = character card, 6 = role card
    private string cardName;
    private Sprite cardImage;
    private Sprite cardBack;
    public GameObject front;
    public GameObject back;
    public Material frontMaterial;
    public Material backMaterial;
    private string cardDescription;
    private string playingCardValue;
    private char playingCardColor;
    private int playingCardType;      // 0 = brown, 1 = blue, 2 = green, 3 = orange
    private int numberOfLoadTokens;
    //private Effect cardEffect;
    private int lootCardCost;
    private int lootCardType;        // 0 = brown, 1 = black    
    private int characterCardLives;
    public int CharacterCardLives { get { return characterCardLives; } }
    private bool isFlipped;
    private int x = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (isFlipped)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -25);
        } 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isFlipped)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        /*clicked++;
        if (clicked == 1) clicktime = Time.time;

        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            this.FlipCard();

        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;*/
        //if (isFlipped) transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    public void FlipCard()
    {
        /*if (x != 0) isFlipped = !isFlipped;
        if (!isFlipped)
            this.gameObject.GetComponent<Image>().sprite = cardBack;
        else
            this.gameObject.GetComponent<Image>().sprite = cardImage;
        x = 1;*/
    }

    public void SetUpCard(int cardType, string cardName, string cardPath, string cardDescription)
    {
        this.cardType = cardType;
        switch (cardType)
        {
            case 0:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/Playing Card Background");
                    break;
                }
            case 1:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/High Noon Background");
                    break;
                }
            case 2:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/Fistful Background");
                    break;
                }
            case 3:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/Wild West Background");
                    break;
                }
            case 4:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/Gold Rush Background");
                    break;
                }
            case 5:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/Character Background");
                    break;
                }
            case 6:
                {
                    cardBack = Resources.Load<Sprite>("Textures/Card backs/Role Background");
                    break;
                }
        }
        this.cardName = cardName;
        this.cardImage = Resources.Load<Sprite>(cardPath);
        this.cardDescription = cardDescription;
        SetUpCardTexture();
    }

    public void SetUpPlayingCard(int cardType, string cardName, string cardPath, string cardDescription, string playingCardValue, char playingCardColor, int playingCardType)
    {
        SetUpCard(cardType, cardName, cardPath, cardDescription);
        this.playingCardValue = playingCardValue;
        this.playingCardColor = playingCardColor;
        this.playingCardType = playingCardType;
    }

    public void SetUpLootCard(int cardType, string cardName, string cardPath, string cardDescription, int lootCardCost, int lootCardType)
    {
        SetUpCard(cardType, cardName, cardPath, cardDescription);
        this.lootCardCost = lootCardCost;
        this.lootCardType = lootCardType;
    }

    public void SetUpCharacterCard(int cardType, string cardName, string cardPath, string cardDescription, int characterCardLives)
    {
        SetUpCard(cardType, cardName, cardPath, cardDescription);
        this.characterCardLives = characterCardLives;
    }

    public void SetUpADPlayingCard(int cardType, string cardName, string cardPath, string cardDescription, string playingCardValue, char playingCardColor, int playingCardType, int numberOfLoadTokens)
    {
        SetUpPlayingCard(cardType, cardName, cardPath, cardDescription, playingCardValue, playingCardColor, playingCardType);
        this.numberOfLoadTokens = numberOfLoadTokens;
    }


    private void SetUpCardTexture()
    {
        this.transform.Find("Front").GetComponent<MeshRenderer>().material.mainTextureScale = frontMaterial.mainTextureScale;
        this.transform.Find("Back").GetComponent<MeshRenderer>().material.mainTextureScale = backMaterial.mainTextureScale;

        this.transform.Find("Front").GetComponent<MeshRenderer>().material.mainTextureOffset = frontMaterial.mainTextureOffset;
        this.transform.Find("Back").GetComponent<MeshRenderer>().material.mainTextureOffset = backMaterial.mainTextureOffset;

        this.transform.Find("Front").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", cardImage.texture);
        this.transform.Find("Back").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", cardBack.texture);
    }
}
