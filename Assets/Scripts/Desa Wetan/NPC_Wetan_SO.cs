using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data NPC", menuName = "ScriptibleObject/NPC/Data")]
public class NPC_Wetan_SO : ScriptableObject
{
    public enum_NPCNameWetan name;
    public List<enum_WetanState> Task;

}
