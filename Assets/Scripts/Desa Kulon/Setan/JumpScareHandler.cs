using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JumpScareHandler : MonoBehaviour
{
    private AudioSource asource;

    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            asource.Play();

    }
}
