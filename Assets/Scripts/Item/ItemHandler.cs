using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject outline;
    private bool outlineOn = false;
    
    // Start is called before the first frame update


    private void Update()
    {
        if (outline == null)
        {
            outline = transform.GetChild(0).gameObject;
            SetItem();
        }
        outline.SetActive(outlineOn);
    }

    private void SetItem()
    {
        if (outline.GetComponent<Rigidbody>() != null)
            Destroy(outline.GetComponent<Rigidbody>());
        outline.transform.position = gameObject.transform.position;
        outline.transform.localScale = Vector3.one;
        Collider[] outlines = outline.GetComponents<Collider>();
        for (int i = 0; i < outlines.Length; i++)
        {
            outlines[i].enabled = false;
        }
    }
}
