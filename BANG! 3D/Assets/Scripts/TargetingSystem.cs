using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class TargetingSystem : MonoBehaviourPun
{
    public event Action<Player, Card> ReturnTargetedCard;
    public static TargetingSystem instance;
    private RectTransform target;
    private RectTransform gun;

    private Card targettingCard;

    private bool isActive;
    public bool IsActive => isActive;

    private void Awake()
    {
        instance = this;
        target = transform.Find("Target").GetComponent<RectTransform>();
        gun = transform.Find("Gun").GetComponent<RectTransform>();
        HideTarget();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            target.position = Input.mousePosition;
            RaycastHit hit = Game.instance.CastRay();

            if (hit.collider != null)
            {
                if (!hit.collider.CompareTag("Drag")) return;
                if (hit.collider.gameObject.GetComponent<Card>().CardType == 5 && hit.collider.gameObject.GetComponent<Card>() != Game.instance.activePlayer.MainCharacter) target.GetComponent<Image>().color = new Color32(0, 215, 0, 169);
                else target.GetComponent<Image>().color = new Color32(215, 0, 10, 169);
            }
                
            if (target.position.x <= gun.position.x) gun.rotation = Quaternion.Euler(0, 180, 180f - (float)(Math.Atan2(Input.mousePosition.y - gun.position.y, Input.mousePosition.x - gun.position.x) / Math.PI * 180.0));
            if (target.position.x > gun.position.x) gun.rotation = Quaternion.Euler(0, 0, (float)(Math.Atan2(Input.mousePosition.y - gun.position.y, Input.mousePosition.x - gun.position.x) / Math.PI * 180.0));
            if (Input.GetMouseButton(0) && target.GetComponent<Image>().color == new Color32(0, 215, 0, 169)) ProcessTargetting(hit.collider.gameObject.GetComponent<Card>());
        }
    }

    private void ProcessTargetting(Card targetedCard)
    {
        ReturnTargetedCard?.Invoke(GetPlayerFromCharacter(targetedCard), targettingCard);
    }

    public void ShowTarget(Card card)
    {
        gameObject.SetActive(true);
        isActive = true;
        targettingCard = card;

        target.position = Input.mousePosition;
        gun.position = Game.instance.activePlayer.transform.position;
        //gun type
        //tohle je pokud není zbraò, jinak se musí zmìnit a na 255
        gun.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

    public void HideTarget()
    {
        isActive = false;
        targettingCard = null;
        try { foreach (Player p in Game.instance.players) p.photonView.RPC("SetUpUI", RpcTarget.AllBuffered); }
        catch { }
        gameObject.SetActive(false);
    }

    private Player GetPlayerFromCharacter(Card character)
    {
        foreach(Player p in Game.instance.players) if (p.MainCharacter.CardName == character.CardName) return p;
        return null;
    }
}
