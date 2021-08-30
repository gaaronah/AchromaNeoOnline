using UnityEngine;
using UnityEngine.UI;

public class ActionCard : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[5]; // N, R, G, B, Y
    
    public string cardName;
    public string cardSkill;
    public int grade;
    public int rarity;

    public int owner;
    public int location;

    public char color; // W, R, G, B, Y, C
    public int currentGrade;

    public string trigger;

    public ActionCard[] relatedActions;

    public Image characterImage;
    public Text actionCost;
    public Text actionTrigger;

    public string set;

    public virtual void PlayAction()
    {
        
    }

    public virtual void AddToHand()
    {

    }

    public virtual void AddToLife()
    {

    }

    public virtual void AddToDrop()
    {

    }

    public virtual void AddToDeck()
    {

    }

    public virtual void AddToBanish()
    {

    }

    public virtual void CheckTrigger()
    {

    }

    public virtual void CheckPhase()
    {

    }
}
