using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum enum_ItemName
{
    Cangkul,
    Gergaji,
    Keris,
    Key,
    Necklance,
    Petromax,
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptibleObject/Item/Canvas Item")]
public class ItemHandlerSO : ScriptableObject
{
    public List<Sprite> imgItem;

    public List<string> textItem;

    public Image displayImageItem;
    public string displayTextItem;

    public void GetItem(string nameItem)
    {
        switch (nameItem)
        {
            case "Cangkul":
                displayImageItem.sprite = imgItem[0];
                displayTextItem = textItem[0];
                break;

            case "Gergaji":
                displayImageItem.sprite = imgItem[1];
                displayTextItem = textItem[1];
                break;

            case "Necklance":
                displayImageItem.sprite = imgItem[4];
                displayTextItem = textItem[4];
                break;

            case "Keris":
                displayImageItem.sprite = imgItem[2];
                displayTextItem = textItem[2];
                break;

            case "Key":
                displayImageItem.sprite = imgItem[3];
                displayTextItem = textItem[3];
                break;

            case "Petromax":
                displayImageItem.sprite = imgItem[5];
                displayTextItem = textItem[5];
                break;
        }
    }
}
