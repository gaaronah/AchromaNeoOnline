using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckCharacterInfo : MonoBehaviour, IPointerClickHandler
{
    public CharacterCard characterCard;
    public CardInfoPanelScript cardInfoPanelScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        cardInfoPanelScript.gameObject.SetActive(false);
        cardInfoPanelScript.LoadInCard(characterCard.gameObject);
        cardInfoPanelScript.gameObject.SetActive(true);
    }
}
