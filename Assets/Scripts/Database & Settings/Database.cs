using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Database
{
    #region Settings Data PlayerPrefs
    // Audio
    public static void SetAudio(string key, float value) => PlayerPrefs.SetFloat(key, value);
    public static float GetAudio(string key) => PlayerPrefs.GetFloat(key);

    // Gameplay
    public static void SetGameplay(string key, float value) => PlayerPrefs.SetFloat(key, value);
    public static float GetGameplay(string key) => PlayerPrefs.GetFloat(key);

    // Graphic
    public static void SetGraphic(string key, int value) => PlayerPrefs.SetInt(key, value);
    public static int GetGraphic(string key) => PlayerPrefs.GetInt(key);

    #endregion

    #region Progres Data PlayerPrefs
    
    //PlayerPos
    public static void SetPlayerPos(Vector3 playerpos)
    {
        SetLastPos("X", playerpos.x);
        SetLastPos("Y", playerpos.y);
        SetLastPos("Z", playerpos.z);
    }

    public static Vector3 GetPlayerPos()
    {
        Vector3 lastpost = new Vector3();

        lastpost.x = GetLastPos("X");
        lastpost.y = GetLastPos("Y");
        lastpost.z = GetLastPos("Z");

        return lastpost;
    }

    private static void SetLastPos(string key, float value) => PlayerPrefs.SetFloat(key, value);
    private static float GetLastPos(string key) => PlayerPrefs.GetFloat(key);


    // Progres Scene

    public static void SetLastScene(string value) => PlayerPrefs.SetString("LastScene", value);
    public static string GetLastScene() => PlayerPrefs.GetString("LastScene");

    public static void SetProgresScene(string key, int value) => PlayerPrefs.SetInt(key, value);
    public static int GetProgresScene(string key) => PlayerPrefs.GetInt(key);

    #endregion


    #region Settings Binnary
    //public static void SaveSettings(SettingsHandler Settings)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();

    //    string savePath = Application.persistentDataPath + "/kramat.settings";
    //    FileStream stream = new FileStream(savePath, FileMode.Create);

    //    SettingsData data = new SettingsData(Settings);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //    Debug.Log("Save Settings");
    //}   

    //public static SettingsData LoadSettings()
    //{
    //    string savePath = Application.persistentDataPath + "/kramat.settings";

    //    if (File.Exists(savePath))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(savePath, FileMode.Open);

    //        SettingsData data = formatter.Deserialize(stream) as SettingsData;
    //        stream.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.Log($"Check ur Data {savePath} is doesn't exist");
    //        return null;
    //    }
    //    Debug.Log("Load Settings");
    //}
    #endregion

    #region Progres Binnary
    //public static void SaveProgres(GameManager manager)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();

    //    string savePath = Application.persistentDataPath + "/kramat.progres";
    //    FileStream stream = new FileStream(savePath, FileMode.Create);

    //    ProgresData data = new ProgresData(manager);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}

    //public static ProgresData LoadProgres()
    //{
    //    string savePath = Application.persistentDataPath + "/kramat.progres";

    //    if (File.Exists(savePath))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(savePath, FileMode.Open);

    //        ProgresData data = formatter.Deserialize(stream) as ProgresData;
    //        stream.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.Log($"Check ur Data {savePath} is doesn't exist");
    //        return null;
    //    }
    //}
    #endregion
}
