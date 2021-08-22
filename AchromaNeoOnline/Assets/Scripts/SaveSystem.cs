using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public void SavePlayerDeckInfo(PlayerInfo playerInfo)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.neo";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerDeckData data = new PlayerDeckData(playerInfo);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerDeckData LoadPlayerDeckInfo()
    {
        string path = Application.persistentDataPath + "/player.neo";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDeckData data = formatter.Deserialize(stream) as PlayerDeckData;
            stream.Close();

            return data;
        } 
        else {
            Debug.Log("File does not exist");
            return null;
        }
    }
}
