using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckInfoPanelScript : MonoBehaviour
{
    public Text deckName;
    public Image[] deckColors = new Image[3];
    public Text charName;

    public Transform scrollRect;
    public Image container;

    public GameObject deckActionPrefab;

    public int firstHeight = 160;
    public int diffHeight = 50;

    public CardInfoPanelScript cardInfoPanelScript;

    public DeckCharacterInfo deckCharacterInfo;

    public void ResetState()
    {
        deckName.text = "";
        foreach (Image deckColor in deckColors)
        {
            deckColor.color = new Color(1, 1, 1, 1);
        }

        charName.text = "";

        foreach (Transform child in scrollRect)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void LoadDeck(DeckInfo deck)
    {
        ResetState();
        CharacterCard character = null;

        foreach(CharacterCard characterCard in PlayerInfo.playerInfo.characterCardList)
        {
            if (characterCard.characterName.Equals(deck.character))
            {
                character = characterCard;
                break;
            }
        }

        deckCharacterInfo.characterCard = character;

        deckName.text = deck.deckName;
        foreach (Image deckColor in deckColors)
        {
            switch(character.color)
            {
                case ('R'):
                    deckColor.color = new Color(1, 0, 0.118f);
                    break;
                case ('G'):
                    deckColor.color = new Color(0, 0.8f, 0);
                    break;
                case ('B'):
                    deckColor.color = new Color(0.012f, 0, 1);
                    break;
                case ('Y'):
                    deckColor.color = new Color(0.906f, 0.906f, 0);
                    break;
            }
        }
        charName.text = deck.character;

        LoadActions(deck);
    }

    public void LoadActions(DeckInfo deck)
    {
        List<ActionCard> cost1Actions = new List<ActionCard>();
        List<ActionCard> cost2Actions = new List<ActionCard>();
        List<ActionCard> cost4Actions = new List<ActionCard>();

        foreach(ActionCard actionCard in PlayerInfo.playerInfo.actionCardList)
        {
            switch (actionCard.cost)
            {
                case (1):
                    if (!actionCard.cardName.Equals("Attack") && !actionCard.cardName.Equals("Chroma Attack"))
                    {
                        cost1Actions.Add(actionCard);
                    }
                    break;
                case (2):
                    cost2Actions.Add(actionCard);
                    break;
                case (4):
                    cost4Actions.Add(actionCard);
                    break;
            }
        }

        cardInfoPanelScript.gameObject.SetActive(true);

        int baseHeight = firstHeight;

        foreach(ActionCard actionCard in cost1Actions)
        {
            if (deck.actionCards.ContainsKey(actionCard.cardName))
            {
                GameObject e = Instantiate(deckActionPrefab);
                e.transform.SetParent(scrollRect);
                e.GetComponent<DeckActionObject>().LoadCard(actionCard, deck.actionCards[actionCard.cardName], false);
                e.GetComponent<DeckActionObject>().SearchForInfoPanel();

                baseHeight += diffHeight;
            }
        }
        foreach (ActionCard actionCard in cost2Actions)
        {
            if (deck.actionCards.ContainsKey(actionCard.cardName))
            {
                GameObject e = Instantiate(deckActionPrefab);
                e.transform.SetParent(scrollRect);
                e.GetComponent<DeckActionObject>().LoadCard(actionCard, deck.actionCards[actionCard.cardName], false);
                e.GetComponent<DeckActionObject>().SearchForInfoPanel();

                baseHeight += diffHeight;
            }
        }
        foreach (ActionCard actionCard in cost4Actions)
        {
            if (deck.actionCards.ContainsKey(actionCard.cardName))
            {
                GameObject e = Instantiate(deckActionPrefab);
                e.transform.SetParent(scrollRect);
                e.GetComponent<DeckActionObject>().LoadCard(actionCard, deck.actionCards[actionCard.cardName], false);
                e.GetComponent<DeckActionObject>().SearchForInfoPanel();

                baseHeight += diffHeight;
            }
        }

        container.rectTransform.sizeDelta = new Vector2(310, baseHeight);
        cardInfoPanelScript.gameObject.SetActive(false);
    } 

    public void CloseInfoPanel()
    {
        cardInfoPanelScript.gameObject.SetActive(false);
    }
}
