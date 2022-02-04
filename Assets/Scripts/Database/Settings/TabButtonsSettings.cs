using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TabButtonsSettings : MonoBehaviour
{
    public TabGroupSettings tabGroup;
    public Button thisBTN;
    public int _id;

    private void Start()
    {
        thisBTN = GetComponent<Button>();
        tabGroup.Suscribe(this);
        thisBTN.onClick.AddListener(() => tabGroup.SelectedTab(this));
    }
}
