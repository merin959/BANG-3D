using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Card : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    private int cardType;             // 0 = playing card, 1 = High Noon card, 2 = Fistful card, 3 = Wild West card, 4 = Gold Rush loot card, 5 = character card, 6 = role card
    public int CardType { get { return cardType; } }
    private string cardName;
    public string CardName { get { return cardName; } }
    private Sprite cardImage;
    public Sprite CardImage { get { return cardImage; } }
    private Sprite cardBack;
    public GameObject front;
    public GameObject back;
    public Material frontMaterial;
    public Material backMaterial;
    private string cardDescription;
    private string playingCardValue;
    private char? playingCardColor;
    public char? PlayingCardColor => playingCardColor;
    private int? playingCardType;      // 0 = brown, 1 = blue, 2 = green, 3 = orange
    private int? numberOfLoadTokens;
    //private Effect cardEffect;
    private int? lootCardCost;
    private int? lootCardType;        // 0 = brown, 1 = black
    private int? shootingDistance;
    public int? ShootingDistance => shootingDistance;
    private int? characterCardLives;
    public int? CharacterCardLives { get { return characterCardLives; } }
    private bool isFlipped;
    public bool IsFlipped { get { return isFlipped; } set { isFlipped = value; } }
    private bool canBeMoved;
    public bool CanBeMoved { get { return canBeMoved && photonView.IsMine; } set { canBeMoved = value; } }

    private string eligibleDestination;

    public string EligibleDestination { get { return eligibleDestination; } set { eligibleDestination = value; } }

    public string TooltipData { get { return cardName + (cardType == 0 ? " (" + playingCardValue + playingCardColor + ")" : "") + "\n" + cardDescription; } }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        SetUpCard(info.photonView.InstantiationData);
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;
        transform.Rotate(new Vector3(0, 0, 180));
    }

    public void SetUpCard(object[] cardInfo)
    {
        transform.SetParent(Game.instance.GameArea.transform, false);
        isFlipped = true;
        CanBeMoved = false;
        cardType = (int)cardInfo[0];
        cardName = (string)cardInfo[1];
        cardImage = Resources.Load<Sprite>((string)cardInfo[2]);
        cardDescription = (string)cardInfo[3];
        playingCardValue = (string)cardInfo[4];
        if ((string)cardInfo[5] == "0") playingCardColor = null; else playingCardColor = char.Parse((string)cardInfo[5]);
        playingCardType = (int?)cardInfo[6];
        numberOfLoadTokens = (int?)cardInfo[7];
        lootCardCost = (int?)cardInfo[8];
        lootCardType = (int?)cardInfo[9];
        characterCardLives = (int?)cardInfo[10];
        shootingDistance = (int?)cardInfo[11];
        switch (cardType)
        {
            case 0:
                {
                    if (playingCardType == 0) eligibleDestination = "Discard deck";
                    else eligibleDestination = "In front of a player";
                    CanBeMoved = true;
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
        SetUpCardTexture();
    }

    private void SetUpCardTexture()
    {
        transform.Find("Front").GetComponent<MeshRenderer>().material.mainTextureScale = frontMaterial.mainTextureScale;
        transform.Find("Back").GetComponent<MeshRenderer>().material.mainTextureScale = backMaterial.mainTextureScale;

        transform.Find("Front").GetComponent<MeshRenderer>().material.mainTextureOffset = frontMaterial.mainTextureOffset;
        transform.Find("Back").GetComponent<MeshRenderer>().material.mainTextureOffset = backMaterial.mainTextureOffset;

        transform.Find("Front").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", cardImage.texture);
        transform.Find("Back").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", cardBack.texture);
    }

    public void ChangeOwner(Photon.Realtime.Player player)
    {
        photonView.TransferOwnership(player);
    }
}
