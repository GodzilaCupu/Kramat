using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawahHandler : MonoBehaviour
{
    public int idSawah;
    [SerializeField] private TaskSawahHandler handler;
    [SerializeField] private GameObject petakSawah;
    [SerializeField] private GameObject fadePanel;

    private int TaskSawah = ((int)enum_WetanState.MenggemburkanTanah);
    private int progresId;

    public bool canplay;
    public bool isDone = false;

    private void OnDisable()
    {
        EventsManager.current.onWetanProgres -= GetProgres;

    }
    private void Start()
    {
        EventsManager.current.onWetanProgres += GetProgres;
        petakSawah = this.transform.GetChild(0).gameObject;
        petakSawah.SetActive(false);
    }
    private void GetProgres(int progres)
    {
        progresId = progres;
        canplay = progresId == TaskSawah ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isDone )
        {
            SetActivePanel(idSawah);
        }
    }

    private void SetActivePanel(int id)
    {
        if (progresId != TaskSawah)
        {
            petakSawah.SetActive(false);
            return;
        }

        if(idSawah == id)
        {
            handler.sawahDone++;
            fadePanel.SetActive(true);
            CanvasGroup cgFade = fadePanel.GetComponent<CanvasGroup>();
            LeanTween.alphaCanvas(cgFade, 1, 1.5f);

            StartCoroutine(DelayDeactivation(2f));
        }
    }

    private void DeactivePanel()
    {
        CanvasGroup cgFade = fadePanel.GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(cgFade, 0, 1.5f);
        
        fadePanel.SetActive(false);
        petakSawah.SetActive(true);
        isDone = true;
    }

    IEnumerator DelayDeactivation(float timer)
    {
        yield return new WaitForSeconds(timer);
        DeactivePanel();
    }
}
