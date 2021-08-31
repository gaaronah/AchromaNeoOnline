using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoPanelScript : MonoBehaviour
{
    public ActionCard actionCard = null;
    public CharacterCard characterCard = null;

    public Image placeHolder;

    public Text description;
    public Text cardName;
    public Text cardGrade;

    public GameObject nextPageButton;
    public GameObject prevPageButton;

    public Sprite[] gradeBorderSprites = new Sprite[6]; // Grey, White, Red, Green, Blue, Yellow
    public Image gradeBorder;

    private int currentPage = 0;


    public void LoadInCard(GameObject card)
    {
        currentPage = 0;
        placeHolder.sprite = null;

        actionCard = null;
        characterCard = null;

        if (card.GetComponent<CharacterCard>() != null) // Case where it is character card
        {
            characterCard = card.GetComponent<CharacterCard>();
            description.text = characterCard.characterSkill[currentPage];
            placeHolder.sprite = characterCard.sprites[currentPage];
            cardName.text = characterCard.characterName.ToUpper();
            cardGrade.text = 1.ToString();

            gradeBorder.sprite = gradeBorderSprites[1];
            switch (characterCard.color)
            {
                case ('R'):
                    gradeBorder.sprite = gradeBorderSprites[2];
                    break;
                case ('G'):
                    gradeBorder.sprite = gradeBorderSprites[3];
                    break;
                case ('B'):
                    gradeBorder.sprite = gradeBorderSprites[4];
                    break;
                case ('Y'):
                    gradeBorder.sprite = gradeBorderSprites[5];
                    break;
            }

            nextPageButton.SetActive(true);
            prevPageButton.SetActive(false);
        }
        else if (card.GetComponent<ActionCard>() != null) // Case where it is action card
        {
            actionCard = card.GetComponent<ActionCard>();

            description.text = actionCard.cardSkill;
            placeHolder.sprite = actionCard.sprites[0];
            cardName.text = actionCard.cardName.ToUpper();
            cardGrade.text = actionCard.cost.ToString();

            gradeBorder.sprite = gradeBorderSprites[0];

            nextPageButton.SetActive(false);
            prevPageButton.SetActive(false);

            if (actionCard.relatedActions.Length > 0)
            {
                nextPageButton.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Could not load card. Does not contain ActionCard / CharacterCard.");
            return;
        }
    }

    public void NextCard(bool next)
    {
        if (next)
        {
            if (characterCard != null)
            {
                if(currentPage < 2)
                {
                    currentPage++;
                    description.text = characterCard.characterSkill[currentPage];
                    placeHolder.sprite = characterCard.sprites[currentPage];
                    cardName.text = characterCard.characterName.ToUpper();
                    cardGrade.text = (currentPage + 1).ToString();
                } 
                else
                {
                    currentPage++;
                    description.text = characterCard.relatedActions[currentPage - 2].cardSkill;
                    placeHolder.sprite = characterCard.relatedActions[currentPage - 2].sprites[0];
                    cardName.text = characterCard.relatedActions[currentPage - 2].cardName.ToUpper();
                    cardGrade.text = characterCard.relatedActions[currentPage - 2].cost.ToString();
                }
                prevPageButton.SetActive(true);
                nextPageButton.SetActive(false);
                if (currentPage < 2 || currentPage - 2 < characterCard.relatedActions.Length)
                {
                    nextPageButton.SetActive(true);
                }
            }
            else if (actionCard != null)
            {
                currentPage++;
                description.text = actionCard.relatedActions[currentPage - 1].cardSkill;
                placeHolder.sprite = actionCard.relatedActions[currentPage - 1].sprites[0];
                cardName.text = actionCard.relatedActions[currentPage - 1].cardName.ToUpper();
                cardGrade.text = actionCard.relatedActions[currentPage - 1].cost.ToString();

                nextPageButton.SetActive(false);
                if (currentPage - 1 < actionCard.relatedActions.Length)
                {
                    nextPageButton.SetActive(true);
                }
            }
        } 
        else
        {
            if (characterCard != null)
            {
                if (currentPage <= 3)
                {
                    currentPage--;
                    description.text = characterCard.characterSkill[currentPage];
                    placeHolder.sprite = characterCard.sprites[currentPage];
                    cardName.text = characterCard.characterName.ToUpper();
                    cardGrade.text = (currentPage + 1).ToString();

                    if (currentPage == 0)
                    {
                        prevPageButton.SetActive(false);
                    }
                }
                else
                {
                    currentPage--;
                    description.text = characterCard.relatedActions[currentPage - 2].cardSkill;
                    placeHolder.sprite = characterCard.relatedActions[currentPage - 2].sprites[0];
                    cardName.text = characterCard.relatedActions[currentPage - 2].cardName.ToUpper();
                    cardGrade.text = characterCard.relatedActions[currentPage - 2].cost.ToString();
                }
            } 
            else if (actionCard != null)
            {
                currentPage--;
                if (currentPage > 0)
                {
                    description.text = actionCard.relatedActions[currentPage - 1].cardSkill;
                    placeHolder.sprite = actionCard.relatedActions[currentPage - 1].sprites[0];
                    cardName.text = actionCard.relatedActions[currentPage - 1].cardName.ToUpper();
                    cardGrade.text = actionCard.relatedActions[currentPage - 1].cost.ToString();
                } 
                else
                {
                    description.text = actionCard.cardSkill;
                    placeHolder.sprite = actionCard.sprites[0];
                    cardName.text = actionCard.cardName.ToUpper();
                    cardGrade.text = actionCard.cost.ToString();

                    prevPageButton.SetActive(false);
                }
            }
            nextPageButton.SetActive(true);
        }
    }
}
