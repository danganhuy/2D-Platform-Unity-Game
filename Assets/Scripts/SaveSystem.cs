using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerProgress.SaveData data = new PlayerProgress.SaveData();
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void LoadGame()
    {
        PlayerProgress.SaveData data = new PlayerProgress.SaveData();
        string path = Application.dataPath + "/player.sav";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = binaryFormatter.Deserialize(stream) as PlayerProgress.SaveData;
            data.LoadData();
            stream.Close();
        } else
        {
            data.DefaultData();
        }
    }
    public static void DeleteSave()
    {
        string path = Application.dataPath + "/player.sav";
        string path2 = Application.dataPath + "/player.meta.sav";
        if (File.Exists(path))
        {
            File.Delete(path);
            File.Delete(path2);
        }
    }
    public static void SaveSetting()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/setting.sav";
        FileStream stream = new FileStream(path, FileMode.Create);


        Volume.SaveVolume data = new Volume.SaveVolume();
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void LoadSetting()
    {
        Volume.SaveVolume data = new Volume.SaveVolume();
        string path = Application.dataPath + "/setting.sav";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = binaryFormatter.Deserialize(stream) as Volume.SaveVolume;
            data.LoadVolume();
            stream.Close();
        }
        else
        {
            data.DefaultSetting();
        }
    }
}
