using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleposHandler : MonoBehaviour
{
    public string ItemName;
    public bool IsCarriedSomething;

    public GameObject Item;

    private void Update()
    {
        CheckItem();
    }

    private void CheckItem()
    {
        IsCarriedSomething = gameObject.transform.childCount != 0 ? true : false;
        if (IsCarriedSomething)
        {
            ItemName = gameObject.transform.GetChild(0).name;
            Item = gameObject.transform.GetChild(0).gameObject;
        }
    }

    public void DestroyItem()
    {
        if (IsCarriedSomething)
        {
            Destroy(Item);
        }
    }
}
