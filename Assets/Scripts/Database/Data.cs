using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static void SetSettings(string key, float value) => PlayerPrefs.SetFloat(key, value);

    public static void SetResolutions(string key, float xValue, float yValue)
    {
        int i = 0;
        string _countI = i.ToString();
        if (i == 0)
        {

            PlayerPrefs.SetFloat(key + _countI, xValue);
            i++;
            if (i != 0)
            {
                PlayerPrefs.SetFloat(key + _countI, yValue);
                i = 0;
            }
        }
    }
    public static void SetPlayerData(string key, float value) => PlayerPrefs.SetFloat(key, value);

    public static float GetSettings(string key) => PlayerPrefs.GetFloat(key);

    public static float GetPlayerData(string key) => PlayerPrefs.GetFloat(key);
}
