using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelScript : MonoBehaviour
{
    public ActionCard[] actionCards = new ActionCard[Constants.TOTAL_ACTIONS];

    public Image[] placeholders = new Image[10];
    public GameObject[] shades = new GameObject[10];
    public Text[] actionNames = new Text[10];

    public bool showUnowned = false;
    public int currentPage = 0;

    public GameObject nextPageButton;
    public GameObject prevPageButton;
    public Text pageNumber;

    public CardInfoPanelScript cardInfoPanelScript;

    private List<ActionCard> ownedCards;
    private GameObject[] currentPageAction = new GameObject[10];


    private void Awake()
    {
        LoadOwnedCards();
        LoadPage();
    }

    public void LoadOwnedCards()
    {
        ownedCards = new List<ActionCard>();
        // To keep it in order:
        for (int i = 0; i < actionCards.Length; i++)
        {
            if (actionCards[i] != null)
            {
                if (PlayerInfo.playerInfo.collection.ownedActions.Contains(actionCards[i].cardName))
                {
                    ownedCards.Add(actionCards[i]);
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
        for (int i = 0; i < 10; i++)
        {
            placeholders[i].sprite = null;
            placeholders[i].color = new Color(0.6f, 0.6f, 0.6f, 1);
            actionNames[i].text = "";
            shades[i].SetActive(false);
            nextPageButton.SetActive(false);
            prevPageButton.SetActive(false);

            currentPageAction[i] = null;
        }

        if (showUnowned)
        {
            int j = 0;
            for (int i = currentPage * 10; i < currentPage * 10 + 10; i++)
            {
                if (i >= Constants.TOTAL_ACTIONS)
                {
                    break;
                }
                placeholders[j].sprite = actionCards[i].sprites[0];
                placeholders[j].color = new Color(1, 1, 1, 1);
                actionNames[j].text = actionCards[i].cardName;
                if (!PlayerInfo.playerInfo.collection.ownedActions.Contains(actionCards[i].cardName))
                {
                    shades[j].SetActive(true);
                }
                else
                {
                    shades[j].SetActive(false);
                }
                currentPageAction[j] = actionCards[i].gameObject;
                j++;
            }
            if (currentPage * 5 + 5 < actionCards.Length)
            {
                nextPageButton.SetActive(true);
            }
            else
            {
                nextPageButton.SetActive(false);
            }
            pageNumber.text = (currentPage + 1).ToString() + " / " + Mathf.CeilToInt((float)Constants.TOTAL_ACTIONS / 5f).ToString();
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
                actionNames[j].text = ownedCards[i].cardName;
                currentPageAction[j] = ownedCards[i].gameObject;
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
        if (currentPageAction[i] == null)
        {
            Debug.LogError("Card doesn't exist");
            return;
        }
        cardInfoPanelScript.LoadInCard(currentPageAction[i]);
        cardInfoPanelScript.gameObject.SetActive(true);
    }

    public void CloseCardInfoPanel()
    {
        cardInfoPanelScript.gameObject.SetActive(false);
    }
}
