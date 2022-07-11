using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_Data
{
    #region Settings
    public static void SaveSettings(SettingsHandler Settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string savePath = Application.persistentDataPath + "/kramat.settings";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        SettingsData data = new SettingsData(Settings);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save Settings");
    }   

    public static SettingsData LoadSettings()
    {
        string savePath = Application.persistentDataPath + "/kramat.settings";

        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log($"Check ur Data {savePath} is doesn't exist");
            return null;
        }
        Debug.Log("Load Settings");
    }
    #endregion

    #region Progres
    public static void SaveProgres(GameManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string savePath = Application.persistentDataPath + "/kramat.progres";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        ProgresData data = new ProgresData(manager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ProgresData LoadProgres()
    {
        string savePath = Application.persistentDataPath + "/kramat.progres";

        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            ProgresData data = formatter.Deserialize(stream) as ProgresData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log($"Check ur Data {savePath} is doesn't exist");
            return null;
        }
    }
    #endregion
}
