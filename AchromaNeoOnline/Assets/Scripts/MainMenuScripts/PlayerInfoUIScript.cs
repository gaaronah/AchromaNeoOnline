using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfoUIScript : MonoBehaviour
{
    public GameObject loadPanel;

    public Text playerNameText;
    public Text playerRankText;

    public GameObject playerPanel;
    public InputField playerPanelNameInput;
    public Text playerPanelNameText;
    public Text playerPanelRankText;
    public Text playerPanelPointsText;
    public Text playerPanelGoldText;
    public Text playerPanelEssenceText;
    public Text playerPanelWinsText;
    public Text playerPanelMatchText;
    public Text playerPanelCharacterCollectionText;
    public Text playerPanelActionCollectionText;

    public float timeToLoad;

    public GameObject codePanel;

    void Awake()
    {
        loadPanel.SetActive(true);
        Invoke("LoadDataToUI", timeToLoad);
    }

    public void LoadDataToUI()
    {
        playerNameText.text = PlayerInfo.playerInfo.playerName;
        playerRankText.text = PlayerInfo.playerInfo.rank.ToString();

        playerPanelNameText.text = PlayerInfo.playerInfo.playerName;

        playerPanelRankText.text = PlayerInfo.playerInfo.rank.ToString();
        playerPanelPointsText.text = "Points: " + PlayerInfo.playerInfo.points.ToString() + "/" + Constants.POINTS_LIMIT;

        playerPanelGoldText.text = "Gold: " + PlayerInfo.playerInfo.gold.ToString();
        playerPanelEssenceText.text = "Essence: " + PlayerInfo.playerInfo.essence.ToString();

        playerPanelWinsText.text = "Wins: " + PlayerInfo.playerInfo.wins.ToString();
        playerPanelMatchText.text = "Matches: " + PlayerInfo.playerInfo.matches.ToString();

        playerPanelCharacterCollectionText.text = "C. Cards: " + PlayerInfo.playerInfo.collection.ownedCharacters.Count.ToString() + "/" + Constants.TOTAL_CHARACTERS;
        playerPanelActionCollectionText.text = "A. Cards: " + PlayerInfo.playerInfo.collection.ownedActions.Count.ToString() + "/" + Constants.TOTAL_ACTIONS;

        loadPanel.SetActive(false);
    }

    public void UpdatePlayerName()
    {
        string newName = playerPanelNameInput.text;

        if (newName.Length > Constants.NAME_MAX_LENGTH || newName == null || newName == "")
        {
            Debug.LogError("Input name invalid! Input name cannot be empty & must be less than " + Constants.NAME_MAX_LENGTH + " characters.");
            return;
        }
        PlayerInfo.playerInfo.UpdateName(newName);
        //LoadDataToUI();
        SceneManager.LoadScene(1);
    }

    public void OpenPlayerPanel()
    {
        playerPanel.SetActive(!playerPanel.activeSelf);
    }

    public void ResetData()
    {
        PlayerInfo.playerInfo.ResetData();
        Debug.Log("reset data");
        //LoadDataToUI();
        SceneManager.LoadScene(1);
    }

    public void OpenCodePanel()
    {
        codePanel.SetActive(true);
    }
}
