using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Task", menuName = "ScriptibleObject/Task/Data")]
public class TaskNotificationSO : ScriptableObject
{
    [TextArea(2, 3)] public string[] TaskWord;
    public enum_ScenesName SceneName;
}
