using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum enum_WetanState
{
    TemuiKepalaDesa,
    MengambilPacul,
    MenggemburkanTanah,
    TemuiKetuaAdat,
    PergiKePakCokro,
    PergiKePakAji,
    KembaliKeKetuaAdat,
    PergiKeBalaiDesa,
}

public class WetanSceneManager : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private ControllerPlayer playerController;
    [SerializeField] private TaskSawahHandler sawahHandler;
    [SerializeField] private HandleposHandler itemCarrier;
    [SerializeField] private DialogHandler dialogHandler;
    [SerializeField] private GameObject panelFade;
    [SerializeField] private bool readybuild;

    [SerializeField] private int dialogProgresID;
    [SerializeField] private int wetanProgresID;

    [SerializeField] private Material[] skyBoxReplacement = new Material[3];

    private Animator playerAnim;
    private CanvasGroup cgFade;

    public bool SawahDone = false;

    private void Start()
    {
        Database.SetLastScene(SceneManager.GetActiveScene().name);
        dialogHandler = GameObject.Find("Popup_Percakapan").GetComponent<DialogHandler>();
        itemCarrier = GameObject.Find("Handle Pos").GetComponent<HandleposHandler>();
        playerAnim = playerController.gameObject.GetComponent<Animator>();
        RenderSettings.skybox = skyBoxReplacement[0];
        SetBangun();
        CheckSawah();

        EventsManager.current.onWetanProgres += (v) => wetanProgresID = v;
        EventsManager.current.onWetanDialogProgres += (v) => dialogProgresID = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onWetanProgres -= (v) => wetanProgresID = v;
        EventsManager.current.onWetanDialogProgres -= (v) => dialogProgresID = v;
    }

    private void Update()
    {
        CheckProgres();
    }

    private void CheckProgres()
    {
        Database.SetProgresScene("Wetan", wetanProgresID);
        switch (wetanProgresID)
        {
            // Bangun Tidur (Task Ke Kades)
            case 0:
                if (dialogProgresID != 1) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(1);
                break;

            // Ambil Pacul (Task Ambil Pacul Dan Kembali Ke Kades)
            case 1:
                if (dialogProgresID != 2) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(2);
                break;

            // Menggemburkan Sawah (Task Gemburin Sawah + Ganti SkyBox 2 Kali)
            case 2:
                CheckSawah();
                if (dialogProgresID != 3) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(3);
                break;

            // Pergi Ke Ketua Adat ( Nyamperin Kadat )
            case 3:
                if (dialogProgresID != 4) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(4);
                break;

            // Pergi Ke Cokro ( Nyamperin Cokro )
            case 4:
                if (dialogProgresID != 5) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(5);
                break;

            // Pergi Ke Aji ( Nyamperin Aji )
            case 5:
                if (dialogProgresID != 6) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(6);
                break;

            // Kembali dengan gergaji ke kadat ( Nyamperin Kadat )
            case 6:
                if (dialogProgresID != 7) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(7);
                break;

            // Pergi Ke Balai Desa ( Nunggu Kadat )
            case 7:
                if (dialogProgresID != 8) return;
                if (!dialogHandler.IsFinished) return;
                EventsManager.current.CheckProgresWetan(8);
                break;

            case 8:
                if (cgFade.alpha == 1)
                    SceneManager.LoadScene("Kulon");
                break;
        }
    }

    private void SetBangun()
    {
        if (!panelFade.activeInHierarchy)
            panelFade.SetActive(true);

        EventsManager.current.SetActivationMovement(false);
        cgFade = panelFade.GetComponent<CanvasGroup>();

        LeanTween.alphaCanvas(cgFade, 0, 0.5f);
        playerAnim.SetTrigger("isBangun");
        if (cgFade.alpha == 0)
        {
            panelFade.SetActive(false);
            EventsManager.current.CheckProgresWetan(0);
            return;
        }
    }

    private void CheckSawah()
    {
        if (panelFade.GetComponent<CanvasGroup>().alpha == 1)
        {
            if (sawahHandler.sawahDone < 1)
            {
                RenderSettings.skybox = skyBoxReplacement[0];
                sun.intensity = 0.8f;
                return;
            }

            if (sawahHandler.sawahDone > 3)
            {
                RenderSettings.skybox = skyBoxReplacement[2];
                sun.intensity = 0.4f;
                SawahDone = true;
                itemCarrier.DestroyItem();
                return;
            }

            RenderSettings.skybox = skyBoxReplacement[1];
            sun.intensity = 1f;
        }
    }

}
