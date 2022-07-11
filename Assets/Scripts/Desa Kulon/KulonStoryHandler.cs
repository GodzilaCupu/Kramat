using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KulonStoryHandler : MonoBehaviour
{
    [SerializeField] private DialogHandler dialogHandler;
    [SerializeField] private SetanAnakKecilHandler setanAnakKecil;
    [SerializeField] private NoteHandler noteHandler;
    [SerializeField] private GameObject go_panelTransition;
    [SerializeField] private GameObject go_panelFade;
    [SerializeField] private CanvasGroup cg_transition;
    [SerializeField] private CanvasGroup cg_fade;

    private int progresID;
    private int dialogProgresID;

    public int ProgresID { get { return progresID; } }
    void Start()
    {
        noteHandler = GameObject.Find("Panel_Note").GetComponent<NoteHandler>();
        dialogHandler = GameObject.Find("Popup_Percakapan").GetComponent<DialogHandler>();
        SetTransistion();
        EventsManager.current.onKulonProgres += (v) => progresID = v;
        EventsManager.current.onKulonPlayDialog += (v) => dialogProgresID = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= (v) => progresID = v;

    }

    private void SetTransistion()
    {
        if (!go_panelTransition.activeInHierarchy)
            go_panelTransition.SetActive(true);

        EventsManager.current.SetActivationMovement(false);
        cg_transition = go_panelTransition.GetComponent<CanvasGroup>();

        LeanTween.alphaCanvas(cg_transition, 0, 1f);
        if(cg_transition.alpha == 0)
        {
            go_panelTransition.SetActive(false);
            EventsManager.current.SetActivationMovement(true);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTask();
    }

    private void CheckTask()
    {
        switch (progresID)
        {
            case 0:
                if (dialogProgresID != 2) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckKulonProgres(1);
                break;

            case 1:
                // Buka Pintu (Ambil Kunci Dulu)
                if (!noteHandler.AlreadyOpen) return;
                EventsManager.current.CheckKulonProgres(2);
                break;

            case 2:
                // Baca Note + Ambil Kalung akik
                break;

            case 3:
                // Bawa lentera Ke Trigger + Ikutin Anak Kecil
                break;

            case 4:
                // pindah scene + fading
                go_panelFade.SetActive(true);
                LeanTween.alphaCanvas(cg_fade, 1, 0.5f);
                if (cg_fade.alpha == 1) SceneManager.LoadScene("BosFight");
                break;
        }
    }
}
