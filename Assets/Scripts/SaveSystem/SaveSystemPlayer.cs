using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystemPlayer
{
    /// <summary>
    /// We save the data in the file
    /// </summary>
    /// <param name="player"></param>
    public static void SavePlayerData(Player player)
    {
        string fileName = "/PlayerData.txt";
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + fileName;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// We  load the data from the file 
    /// </summary>
    /// <returns></returns>
    public static PlayerData LoadPlayer()
    {
        string fileName = "/PlayerData.txt";
        string path = Application.persistentDataPath + fileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
