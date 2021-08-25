using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelScript : MonoBehaviour
{
    public CharacterCard[] characterCards = new CharacterCard[Constants.TOTAL_CHARACTERS];

    public Image[] placeholders = new Image[5];
    public Image[] shades = new Image[5];
    public Text[] characterNames = new Text[5];

    public GameObject infoPanel;
    public Image infoPanelDisplay;
    public Text infoPanelDescription;
    public Text infoPanelLevel;
}
