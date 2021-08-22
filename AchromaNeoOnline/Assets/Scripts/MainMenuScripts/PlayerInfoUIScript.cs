using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUIScript : MonoBehaviour
{
    public GameObject loadPanel;

    public Text playerNameText;
    public Text playerRankText;

    public float timeToLoad;

    void Awake()
    {
        loadPanel.SetActive(true);
        Invoke("LoadDataToUI", timeToLoad);
    }

    public void LoadDataToUI()
    {
        playerNameText.text = PlayerInfo.playerInfo.playerName;
        playerRankText.text = PlayerInfo.playerInfo.rank.ToString();

        loadPanel.SetActive(false);
    }
}
