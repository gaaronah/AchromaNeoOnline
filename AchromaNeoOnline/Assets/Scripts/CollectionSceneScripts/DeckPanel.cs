using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckPanel : MonoBehaviour
{
    public List<DeckInfo> decks = new List<DeckInfo>();

    public GameObject[] placehodlers = new GameObject[8];
    public Image[] deckImages = new Image[8];
    public Text[] deckNames = new Text[8];
    public GameObject[] shades = new GameObject[8];

    public GameObject newDeckButton;

    public DeckInfoPanelScript deckDetailsPanel;

    public CardInfoPanelScript cardInfoPanelScript;

    private List<CharacterCard> characters;
    private List<ActionCard> actions;


    private void Awake()
    {
        deckDetailsPanel.gameObject.SetActive(false);
        LoadDecks();
        LoadPage();
    }

    public void LoadDecks()
    {
        decks = new List<DeckInfo>();
        characters = new List<CharacterCard>();
        actions = new List<ActionCard>();

        foreach(DeckInfo deck in PlayerInfo.playerInfo.decks)
        {
            decks.Add(deck);
        }

        foreach(CharacterCard character in PlayerInfo.playerInfo.characterCardList)
        {
            characters.Add(character);
        }

        foreach (ActionCard action in PlayerInfo.playerInfo.actionCardList)
        {
            actions.Add(action);
        }
    }

    public void LoadPage()
    {
        newDeckButton.SetActive(false);
        for (int j = 0; j < 8; j++)
        {
            placehodlers[j].SetActive(false);
            deckImages[j].sprite = null;
            deckNames[j].text = "";
            shades[j].SetActive(false);
        }

        int i = 0;
        foreach(DeckInfo deck in decks)
        {
            placehodlers[i].SetActive(true);
            deckNames[i].text = deck.deckName;
            foreach(CharacterCard character in characters)
            {
                if (character.characterName.Equals(deck.character))
                {
                    deckImages[i].sprite = character.sprites[0];
                }
            }
            i++;
        }

        if (i < 7)
        {
            newDeckButton.SetActive(true);
            newDeckButton.transform.localPosition = placehodlers[i].transform.localPosition;
        }
    }

    public void OpenDeckInfo(int i)
    {
        deckDetailsPanel.LoadDeck(decks[i]);
        deckDetailsPanel.gameObject.SetActive(true);
    }

    public void CloseDeckInfo()
    {
        deckDetailsPanel.gameObject.SetActive(false);
        cardInfoPanelScript.gameObject.SetActive(false);
    }
}
