using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{

    public Save CurrentSave { get; set; }
    public string SavePath = "/GameSaves";

    private void Start()
    {
        CurrentSave = SaveUtility.LoadGame(Application.persistentDataPath + SavePath);
        SavePath = Application.persistentDataPath + SavePath;
    }

    public void Save()
    {
        CurrentSave.SaveGame(SavePath);
    }

    public void Save(Save save)
    {
        save.SaveGame(SavePath);
    }

    public Save Load()
    {
        CurrentSave = SaveUtility.LoadGame(SavePath);
        return CurrentSave;
    }

    private Save Load(string path)
    {
        return SaveUtility.LoadGame(path);
    }
}