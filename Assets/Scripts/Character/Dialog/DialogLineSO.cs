using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manager Dialog", menuName = "ScriptibleObject/Dilog/Line"),System.Serializable]
public class DialogLineSO : ScriptableObject
{
    [Tooltip("Berapa Banyak Percakapan Dalam Satu Dialoge")] public int LineSize;
    [Tooltip("Banyak Orang Dalam Percakapan")] public DialogSO[] Data;
    [Tooltip("Urutan Percakapan Npc")]public int[] OrderData;
    [Tooltip("Urutan Percakapan Dialog")]public int[] OrderLine;

    public string GetNameText(int order)
    {
        return Data[OrderData[order]].DialogName;
    }

    public string GetDialogText(int order) 
    {
        return Data[OrderData[order]].DialogWord[OrderLine[order]];
    }

    public AudioClip GetClip(int order)
    {
        return Data[OrderData[order]].DialogSFX[OrderLine[order]];
    }
}