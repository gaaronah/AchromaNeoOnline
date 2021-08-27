using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveSystem
{
    public static void SavePlayerDeckInfo(PlayerInfo playerInfo)
    {
        try
        {
            Debug.Log("Saving player data");
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/player.neo";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerDeckData data = new PlayerDeckData(playerInfo);

            formatter.Serialize(stream, data);
            stream.Close();
        } catch (Exception e)
        {
            Debug.LogError("Could not save file. Exception: " + e);
        }
    }

    public static PlayerDeckData LoadPlayerDeckInfo()
    {
        string path = Application.persistentDataPath + "/player.neo";
        if (File.Exists(path))
        {
            Debug.Log("File found! Loading player data...");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDeckData data = formatter.Deserialize(stream) as PlayerDeckData;
            stream.Close();

            return data;
        } 
        else {
            Debug.LogError("File does not exist");
            return null;
        }
    }
}
