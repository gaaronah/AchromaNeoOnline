using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSceneManager : MonoBehaviour
{
    public GameObject loadPanel;

    public GameObject characterPanel;
    public GameObject actionPanel;
    public GameObject deckPanel;

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

    private void OpenCharacterPanel()
    {
        actionPanel.SetActive(false);
        deckPanel.SetActive(false);
        characterPanel.SetActive(true);
    }

    private void OpenActionPanel()
    {
        deckPanel.SetActive(false);
        characterPanel.SetActive(false);
        actionPanel.SetActive(true);
    }

    private void OpenDeckPanel()
    {
        actionPanel.SetActive(false);
        characterPanel.SetActive(false);
        deckPanel.SetActive(true);
    }
}
