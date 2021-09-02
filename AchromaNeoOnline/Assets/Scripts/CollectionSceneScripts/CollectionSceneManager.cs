using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSceneManager : MonoBehaviour
{
    public GameObject loadPanel;

    public GameObject characterPanel;
    public GameObject actionPanel;
    public GameObject deckPanel;

    public Text title;

    public float loadTime;

    private void Awake()
    {
        loadPanel.SetActive(true);
        Invoke("LoadInPanel", loadTime);
    }

    private void LoadInPanel()
    {
        OpenCharacterPanel();
        loadPanel.SetActive(false);
    }

    public void OpenCharacterPanel()
    {
        actionPanel.SetActive(false);
        deckPanel.SetActive(false);
        characterPanel.SetActive(true);
        title.text = "Collection: Character Cards";
    }

    public void OpenActionPanel()
    {
        deckPanel.SetActive(false);
        characterPanel.SetActive(false);
        actionPanel.SetActive(true);
        title.text = "Collection: Action Cards";
    }

    public void OpenDeckPanel()
    {
        actionPanel.SetActive(false);
        characterPanel.SetActive(false);
        deckPanel.SetActive(true);
        title.text = "Collection: Decks";
    }
}
