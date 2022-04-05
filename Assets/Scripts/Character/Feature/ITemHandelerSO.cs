using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptibleObject/Item/Item")]
public class ITemHandelerSO : ScriptableObject
{
    public GameObject Item;

    public Transform startPosParent;
    public Transform destinationPosParent;

    public Rigidbody ItemRigidBody => Item.GetComponent<Rigidbody>();

}
