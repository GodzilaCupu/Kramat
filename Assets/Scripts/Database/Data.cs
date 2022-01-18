using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static void SetSettings(string key, float value) => PlayerPrefs.SetFloat(key, value);

    public static float GetSettings(string key) => PlayerPrefs.GetFloat(key);
}
