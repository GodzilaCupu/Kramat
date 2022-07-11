using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHandler : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject go_panelNote;
    [SerializeField] private CanvasGroup cg_panelNote;
    [SerializeField] private Button btn_closeNote;

    [Header("Data"), Space(5)]
    [SerializeField] private bool isOpen = false;
    public bool AlreadyOpen = false;

    void Start()
    {
        cg_panelNote = go_panelNote.GetComponent<CanvasGroup>();
        btn_closeNote.onClick.AddListener(CloseNote);
        EventsManager.current.onOpenNote += (v) => isOpen = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onOpenNote -= (v) => isOpen = v;
    }

    private void Update()
    {
        if (!isOpen) return;
        OpenNote();
    }

    public void OpenNote()
    {
        AlreadyOpen = true;
        go_panelNote.SetActive(true);
        LeanTween.alphaCanvas(cg_panelNote, 1, 1f);

        EventsManager.current.SetActivationMovement(false);
        Cursor.visible = true;
    }

    private void CloseNote()
    {
        LeanTween.alphaCanvas(cg_panelNote, 0, 1f);
        Cursor.visible = false;
        EventsManager.current.SetActivationMovement(true);
        go_panelNote.SetActive(false);
    }

}
