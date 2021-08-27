using UnityEngine;

public class ActionCard : MonoBehaviour
{
    public Sprite sprite;
    
    public string cardName;
    public string cardSkill;
    public int grade;
    public int rarity;

    public int owner;
    public int location;

    public char color; // W, R, G, B, Y, C
    public int currentGrade;

    public ActionCard[] relatedActions;

    public void PlayAction()
    {
        
    }
}
