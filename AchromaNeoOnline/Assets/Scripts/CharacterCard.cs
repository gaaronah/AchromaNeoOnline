using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    public string characterName;
    public int level = 1;
    public int exp = 0;
    public char color; // W, R, G, B, Y, C
    public string currentSkill;
    public string[] characterSkill = new string[3];

    public ActionCard[] relatedActions;

    public Image characterImage;
    public Text characterGrade;


    private void Awake()
    {
        LoadCard();
    }

    public virtual void LevelUp()
    {
        if (level < 3)
        {
            level++;
            LoadCard();
        }
    }

    public virtual void LevelDown()
    {
        if (level > 1)
        {
            level--;
            LoadCard();
        }
    }

    public virtual void ExpUp(int i)
    {
        if (level < 3)
        {
            exp += i;
            if (level == 1)
            {
                if (exp >= Constants.CHAR_MAX_EXP_1)
                {
                    LevelUp();
                    exp -= Constants.CHAR_MAX_EXP_1;
                }
            }
            if (level == 2) {
                if (exp >= Constants.CHAR_MAX_EXP_2)
                {
                    LevelUp();
                    exp = Constants.CHAR_MAX_EXP_2;
                }
            }
        }
    }

    public virtual void LoadCard()
    {
        if (characterImage != null && characterGrade != null)
        {
            characterImage.sprite = sprites[level - 1];
            characterGrade.text = level.ToString();
        }
        currentSkill = characterSkill[level - 1];
    }

    public virtual void ActivateSkill()
    {

    }
}
