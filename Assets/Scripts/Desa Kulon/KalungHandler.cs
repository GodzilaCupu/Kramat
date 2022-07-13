using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalungHandler : MonoBehaviour
{
    [SerializeField] private GameObject goKidalang;
    [SerializeField] private GameObject goItemContainner;

    private Animator animKidalang;

    private void Start()
    {
        animKidalang = goKidalang.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animKidalang.enabled) return;

        this.gameObject.transform.parent = goItemContainner.transform;
        if (gameObject.GetComponent<Rigidbody>() != null) return;
        gameObject.AddComponent<Rigidbody>();
    }
}
