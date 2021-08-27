using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelScript : MonoBehaviour
{
    public CharacterCard[] characterCards = new CharacterCard[Constants.TOTAL_CHARACTERS];

    public Image[] placeholders = new Image[5];
    public GameObject[] shades = new GameObject[5];
    public Text[] characterNames = new Text[5];

    public bool showUnowned = false;
    public int currentPage = 0;

    public GameObject nextPageButton;
    public GameObject prevPageButton;
    public Text pageNumber;

    public CardInfoPanelScript cardInfoPanelScript;

    private List<CharacterCard> ownedCards;
    private GameObject[] currentPageCharacter = new GameObject[5];


    private void Awake()
    {
        LoadOwnedCards();
        LoadPage();
    }

    public void LoadOwnedCards()
    {
        ownedCards = new List<CharacterCard>();
        // To keep it in order:
        for (int i = 0; i < characterCards.Length; i++)
        {
            if (characterCards[i] != null)
            {
                if (PlayerInfo.playerInfo.collection.ownedCharacters.Contains(characterCards[i].characterName))
                {
                    ownedCards.Add(characterCards[i]);
                }
            }
        }
    }

    public void ChangePage(bool next)
    {
        if (next)
        {
            currentPage++;
        }
        else
        {
            currentPage--;
        }
        LoadPage();
    }

    public void ChangeShowUnowned()
    {
        showUnowned = !showUnowned;
        LoadPage();
    }

    public void LoadPage()
    {
        // Resets placeholders
        for (int i = 0; i <  5; i++)
        {
            placeholders[i].sprite = null;
            placeholders[i].color = new Color(0.6f, 0.6f, 0.6f, 1);
            characterNames[i].text = "";
            shades[i].SetActive(false);
            nextPageButton.SetActive(false);
            prevPageButton.SetActive(false);

            currentPageCharacter[i] = null;
        }

        if (showUnowned)
        {
            int j = 0;
            for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
            {
                if (i >= Constants.TOTAL_CHARACTERS)
                {
                    break;
                }
                placeholders[j].sprite = characterCards[i].sprites[0];
                placeholders[j].color = new Color(1, 1, 1, 1);
                characterNames[j].text = characterCards[i].characterName;
                if (!PlayerInfo.playerInfo.collection.ownedCharacters.Contains(characterCards[i].characterName))
                {
                    shades[j].SetActive(true);
                } else
                {
                    shades[j].SetActive(false);
                }
                currentPageCharacter[j] = characterCards[i].gameObject;
                j++;
            }
            if (currentPage * 5 + 5 < characterCards.Length)
            {
                nextPageButton.SetActive(true);
            }
            else
            {
                nextPageButton.SetActive(false);
            }
            pageNumber.text = (currentPage + 1).ToString() + " / " + Mathf.CeilToInt((float)Constants.TOTAL_CHARACTERS / 5f).ToString();
        } 
        else
        {
            int j = 0;
            for (int i = currentPage * 5; i < currentPage * 5 + 5; i++)
            {
                if (i >= ownedCards.Count)
                {
                    break;
                }
                placeholders[j].sprite = ownedCards[i].sprites[0];
                placeholders[j].color = new Color(1, 1, 1, 1);
                characterNames[j].text = ownedCards[i].characterName;
                currentPageCharacter[j] = ownedCards[i].gameObject;
                j++;
            }
            if (currentPage * 5 + 5 < ownedCards.Count)
            {
                nextPageButton.SetActive(true);
            }
            else
            {
                nextPageButton.SetActive(false);
            }
            pageNumber.text = (currentPage + 1).ToString() + " / " + Mathf.CeilToInt((float)ownedCards.Count / 5f).ToString();
        }


        if (currentPage > 0)
        {
            prevPageButton.SetActive(true);
        }
        else
        {
            prevPageButton.SetActive(false);
        }
    }

    public void OpenCardInfoPanel(int i)
    {
        if (currentPageCharacter[i] == null)
        {
            Debug.LogError("Card doesn't exist");
            return;
        }
        cardInfoPanelScript.LoadInCard(currentPageCharacter[i]);
        cardInfoPanelScript.gameObject.SetActive(true);
    }

    public void CloseCardInfoPanel()
    {
        cardInfoPanelScript.gameObject.SetActive(false);
    }
}
