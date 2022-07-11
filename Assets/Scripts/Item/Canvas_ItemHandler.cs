using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas_ItemHandler : MonoBehaviour
{
    public List<Sprite> imgItemContainner;
    public List<string> textNPCContainner;
    public List<string> textItemContainner;
    [SerializeField] private CanvasGroup cgItem;
    [SerializeField] private CanvasGroup cgNPC;
    [SerializeField] private GameObject goItem;
    [SerializeField] private GameObject goNPC;

    [SerializeField] private Image imgItem;
    [SerializeField] private Image imgNPC;

    [SerializeField] private TextMeshProUGUI txtItem;
    [SerializeField] private TextMeshProUGUI txtItemNPC;

    private string itemName;
    private string npcName;

    private string sNPC;
    private string sItem;

    private bool canPlay ;
    private bool canNPCPlay;

    private void Start()
    {
        EventsManager.current.onItemName += CheckName;
        EventsManager.current.onNPCName += CheckNPCName;
        EventsManager.current.onDisplayNPC += CanDisplayNPC;
        EventsManager.current.onDisplayItem += CanDisplay;
    }

    private void OnDisable()
    {
        EventsManager.current.onItemName -= CheckName;
        EventsManager.current.onNPCName -= CheckNPCName;
        EventsManager.current.onDisplayNPC -= CanDisplayNPC;
        EventsManager.current.onDisplayItem -= CanDisplay;
    }
    void Update()
    {
        DisplayItem(canPlay);
        DisplayNPC(canNPCPlay);
    }

    private void CheckName(string obj) => itemName = obj;
    private void CheckNPCName(string name) => npcName = name;
    private void CanDisplay(bool canDisplay) => canPlay = canDisplay;
    private void CanDisplayNPC(bool canDisplay) => canNPCPlay = canDisplay;

    private void DisplayItem(bool canDisplay)
    {
        if (imgItem == null)
            imgItem = cgItem.transform.GetChild(0).gameObject.GetComponent<Image>();

        goItem.SetActive(canDisplay);
        SetDisplay();
    }

    private void DisplayNPC(bool canDisplay)
    {
        if (imgItem == null)
            imgNPC = cgItem.transform.GetChild(0).gameObject.GetComponent<Image>();

        goNPC.SetActive(canDisplay);
        SetDisplayNPC();
    }

    private void SetDisplay()
    {
        GetItem(itemName);
        txtItem.text = sItem;
    }

    private void SetDisplayNPC()
    {
        GetNPCName(npcName);
        txtItemNPC.text = sNPC;
    }

    private void GetItem(string nameItem)
    {
        switch (nameItem)
        {
            case "Cangkul":
                imgItem.sprite = imgItemContainner[0];
                sItem = textItemContainner[0];
                break;

            case "Gergaji":
                imgItem.sprite = imgItemContainner[1];
                sItem = textItemContainner[1];
                break;

            case "Kalung":
                imgItem.sprite = imgItemContainner[2];
                sItem = textItemContainner[2];
                break;

            case "Keris":
                imgItem.sprite = imgItemContainner[3];
                sItem = textItemContainner[3];
                break;

            case "Kunci":
                imgItem.sprite = imgItemContainner[4];
                sItem = textItemContainner[4];
                break;

            case "Petromax":
                imgItem.sprite = imgItemContainner[5];
                sItem = textItemContainner[5];
                break;
        }
    }

    private void GetNPCName(string nameNPC)
    {
        switch (nameNPC)
        {
            case "KepalaDesa":
                imgNPC.sprite = imgItemContainner[6];
                sNPC = textNPCContainner[0];
                break;

            case "KetuaAdat":
                imgNPC.sprite = imgItemContainner[6];
                sNPC = textNPCContainner[1];
                break;

            case "Cokro":
                imgNPC.sprite = imgItemContainner[6];
                sNPC = textNPCContainner[2];
                break;

            case "Aji":
                imgNPC.sprite = imgItemContainner[6];
                sNPC = textNPCContainner[3];
                break;
        }
    }
}
