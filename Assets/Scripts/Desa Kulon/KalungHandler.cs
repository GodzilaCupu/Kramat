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
        this.gameObject.transform.parent = goItemContainner.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (animKidalang.enabled) return;

        if (gameObject.GetComponent<Rigidbody>() != null) return;
        gameObject.AddComponent<Rigidbody>();
    }
}
