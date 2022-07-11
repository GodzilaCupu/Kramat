using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgresBar : MonoBehaviour
{
    public float MaximumValue = 1f;
    public float CurrentValue;

    public Image mask;
    [SerializeField] private LoadingProgresSO so_progres;

    // Update is called once per frame
    void Update()
    {
        GetFillAmount();
    }

    public void GetFillAmount()
    {
        CurrentValue = so_progres._loadingProgres;
        float fillAmount = CurrentValue / MaximumValue;
        mask.fillAmount = fillAmount;
    }
}
