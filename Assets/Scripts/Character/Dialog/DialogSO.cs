using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Dialog", menuName = "ScriptibleObject/Dilog/Data"), System.Serializable]
public class DialogSO : ScriptableObject
{
    public string DialogName;
    [TextArea(5,20),InspectorLabel_Override("Dialogue")]public List<string> DialogWord;

    public List<AudioClip> DialogSFX;
}
