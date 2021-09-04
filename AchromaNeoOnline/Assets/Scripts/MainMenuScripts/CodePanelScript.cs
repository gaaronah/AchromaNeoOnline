using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanelScript : MonoBehaviour
{
    public InputField codeInput;
    public PlayerInfoUIScript playerInfoUIScript;

    public void InputCode()
    {
        switch(codeInput.text.ToLower())
        {
            case ("reset"):
                PlayerInfo.playerInfo.ResetData();
                break;
            case ("fcwl"):
                PlayerInfo.playerInfo.ObtainSet("FCWL");
                break;
            case ("thnt"):
                PlayerInfo.playerInfo.ObtainSet("THNT");
                break;
            case ("unlock"):
                PlayerInfo.playerInfo.ObtainSet("all");
                break;
        }
        playerInfoUIScript.CloseCodePanel();
        playerInfoUIScript.ReloadScene();
    }
}
