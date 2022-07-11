using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ki_DalangHandler : MonoBehaviour
{
    [Header("Tergantung")]
    [SerializeField] private ControllerPlayer controllerPlayer;
    [SerializeField] private Rigidbody rb_kidalang;
    [SerializeField] private Animator anim;

    [Header("Data")]
    [SerializeField] private float f_minDistance;
    [SerializeField] private float f_distanceToPlayer;
    private int progresID;
    public bool AlreadyFalling = false;


    // Start is called before the first frame update
    void Start()
    {
        controllerPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerPlayer>();
        rb_kidalang = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        rb_kidalang.isKinematic = true;
        rb_kidalang.useGravity = false;
        EventsManager.current.onKulonProgres += (v) => progresID = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= (v) => progresID = v;
    }

    // Update is called once per frame
    void Update()
    {
        if (progresID != 2) return;

        f_distanceToPlayer = Vector3.Distance(controllerPlayer.gameObject.transform.position, this.transform.position);

        if (AlreadyFalling) return;

        if(f_distanceToPlayer < f_minDistance)
        {
            anim.enabled = false;
            rb_kidalang.isKinematic = false;
            rb_kidalang.useGravity = true;
            AlreadyFalling = true;
        }
    }
}
