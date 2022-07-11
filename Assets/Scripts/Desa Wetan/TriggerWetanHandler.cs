using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWetanHandler : MonoBehaviour
{
    [SerializeField] private GameObject PanelFade;
    private int wetanProgresID;
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.current.onWetanProgres += (v) => wetanProgresID = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onWetanProgres -= (v) => wetanProgresID = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (wetanProgresID != 8) return;

            if (!PanelFade.activeInHierarchy) PanelFade.SetActive(true);

            if (PanelFade.GetComponent<CanvasGroup>().alpha == 0)           LeanTween.alphaCanvas(PanelFade.GetComponent<CanvasGroup>(), 1, 1f);
        }
    }
}
