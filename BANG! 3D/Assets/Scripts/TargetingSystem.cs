using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetingSystem : MonoBehaviour
{
    public static TargetingSystem instance;
    private RectTransform target;
    private RectTransform gun;

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
        }
    }

    public void ShowTarget()
    {
        gameObject.SetActive(true);
        target.position = Input.mousePosition;
        gun.position = Game.instance.activePlayer.transform.position;
    }

    public void HideTarget()
    {
        gameObject.SetActive(false);
    }
}
