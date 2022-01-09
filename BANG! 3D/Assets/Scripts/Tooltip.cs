using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;

    private Text tooltipText;
    private RectTransform backgroundRectTransform;
    private RectTransform textRectTransform;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        tooltipText = transform.Find("Text").GetComponent<Text>();
        textRectTransform = transform.Find("Text").GetComponent<RectTransform>();
        //ShowTooltip("Instead of drawing in phase 1, each player guesses if the suit of the top card of the deck is red or black. He then draws and shows it; if he guessed right, he keeps it and guesses again; otherwise he proceeds to phase 2.");
    }

    private void Update()
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out anchoredPosition);

        transform.position = new Vector2(anchoredPosition.x > 0 ? anchoredPosition.x + 960 - backgroundRectTransform.sizeDelta.x / 2 : anchoredPosition.x + 960 + backgroundRectTransform.sizeDelta.x / 2,
                                         anchoredPosition.y > 0 ? anchoredPosition.y + 540 - backgroundRectTransform.sizeDelta.y / 2 : anchoredPosition.y + 540 + backgroundRectTransform.sizeDelta.y / 2);
    }

    public void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        this.tooltipText.text = tooltipString;
        float textPaddingSize = 5f;
        backgroundRectTransform.sizeDelta = new Vector2((tooltipText.preferredWidth + textPaddingSize * 2f) > 550 ? 550 : tooltipText.preferredWidth + textPaddingSize * 4f, tooltipText.preferredHeight + textPaddingSize * 2f);
        textRectTransform.sizeDelta = new Vector2(tooltipText.preferredWidth > 540 ? 540 : tooltipText.preferredWidth, tooltipText.preferredHeight);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
