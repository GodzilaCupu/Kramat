using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KulonStoryHandler : MonoBehaviour
{
    [SerializeField] private DialogHandler dialogHandler;
    [SerializeField] private SetanAnakKecilHandler setanAnakKecil;
    [SerializeField] private NoteHandler noteHandler;
    [SerializeField] private TransitionHandler transitionHandler;
    [SerializeField] private GameObject handpos;

    private int progresID;
    private int dialogProgresID;

    public int ProgresID { get { return progresID; } }
    void Start()
    {
        Database.SetLastScene(SceneManager.GetActiveScene().name);
        handpos = GameObject.Find("Handle Pos");
        noteHandler = GameObject.Find("Panel_Note").GetComponent<NoteHandler>();
        dialogHandler = GameObject.Find("Popup_Percakapan").GetComponent<DialogHandler>();
        transitionHandler.StartTransition();
        EventsManager.current.onKulonProgres += (v) => progresID = v;
        EventsManager.current.onKulonPlayDialog += (v) => dialogProgresID = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= (v) => progresID = v;
        EventsManager.current.onKulonPlayDialog -= (v) => dialogProgresID = v;
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
                Database.SetProgresScene("Kulon", progresID);
                break;

            case 1:
                // Buka Pintu (Ambil Kunci Dulu)
                if (!noteHandler.AlreadyOpen) return;
                Database.SetProgresScene("Kulon", progresID);
                EventsManager.current.CheckKulonProgres(2);
                break;

            case 2:
                if (progresID != 2) return;
                if (handpos.transform.childCount != 1) return;
                if (handpos.transform.GetChild(0).name == "Petromax") EventsManager.current.CheckKulonProgres(3);
                Database.SetProgresScene("Kulon", progresID);
                break;

            case 3:
                // Baca Note + Ambil Kalung akik
                Database.SetProgresScene("Kulon", progresID);
                break;

            case 4:
                // pindah scene 
                transitionHandler.FinishTransition();
                break;
        }
    }
}
