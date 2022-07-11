using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private CanvasGroup cgFade;

    private void Start()
    {
        cgFade = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (cgFade.alpha == 0f)
        {
            EventsManager.current.CheckProgresWetan((int)enum_WetanState.TemuiKepalaDesa);
            EventsManager.current.SetActivationMovement(true);
            this.gameObject.SetActive(false);
            return;
        }
    }
}
