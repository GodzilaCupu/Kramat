using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPC_Wetan_Sawah_Handler : MonoBehaviour
{
    [SerializeField] private float timer;
    Animator anim_NPC;
    // Start is called before the first frame update
       
    void Start() => anim_NPC = GetComponent<Animator>();

    // Update is called once per frame
    void Update()
    {

        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            anim_NPC.SetTrigger("playCangkul");
            timer = 0;
            Destroy(this);
        }
    }
}
