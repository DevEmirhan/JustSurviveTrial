using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveUtility
{
    public static void SaveGame(this Save save, string path)
    {
        var data = JsonUtility.ToJson(save);
        PlayerPrefs.SetString(path, data);
    }

    public static Save LoadGame(string path)
    {
        var data = new Save();
        if (PlayerPrefs.HasKey(path) == false)
        {
            data.SaveGame(path);
        }
        { 
            data  = JsonUtility.FromJson<Save>(PlayerPrefs.GetString(path));
        }
        return data;
    }
}
