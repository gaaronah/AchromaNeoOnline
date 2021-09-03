using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckActionObject : MonoBehaviour, IPointerClickHandler
{
    public ActionCard actionCard;
    public int amount;

    public Text cardName;
    public Text cardGrade;
    public Text cardAmount;

    public bool movable;

    public CardInfoPanelScript cardInfoPanelScript;

    private void Awake()
    {
        LoadInfo();
    }

    public void LoadCard(ActionCard card, int amt, bool mvbl)
    {
        actionCard = card;
        amount = amt;
        movable = mvbl;

        LoadInfo();
    }

    public void LoadInfo()
    {
        if (actionCard != null)
        {
            cardName.text = actionCard.cardName.ToUpper();
            cardGrade.text = actionCard.cost.ToString();
            cardAmount.text = amount.ToString();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cardInfoPanelScript.gameObject.SetActive(false);
        cardInfoPanelScript.LoadInCard(actionCard.gameObject);
        cardInfoPanelScript.gameObject.SetActive(true);
    }

    public void SearchForInfoPanel()
    {
        cardInfoPanelScript = GameObject.Find("CardInfoDeck").GetComponent<CardInfoPanelScript>();
    }
}
