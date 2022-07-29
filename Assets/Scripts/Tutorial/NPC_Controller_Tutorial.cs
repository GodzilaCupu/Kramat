using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator),typeof(NavMeshAgent))]
public class NPC_Controller_Tutorial : MonoBehaviour
{
    [SerializeField] private Transform finishPos;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float maxDistance = 6;

    private float distanceToPlayer;

    private NavMeshAgent nva_npcAgent;
    private Animator anim;

    void Start()
    {
        nva_npcAgent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        EventsManager.current.onTutorialProgres += GetProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onTutorialProgres -= GetProgres;
    }

    void Update()
    {
        CheckDistance();
    }

    private void GetProgres(int v)
    {
        if(v !=0 || v !> 5)
            WalkToTarget();
    }

    private void CheckDistance()
    {
        distanceToPlayer = Vector3.Distance(this.transform.position, playerPos.position);
        if (distanceToPlayer > maxDistance)
        {
            anim.SetBool("isWalking", false);
            nva_npcAgent.isStopped = true;
            return;
        }
        anim.SetBool("isWalking", true);
        nva_npcAgent.isStopped = false;
    }

    private void WalkToTarget()
    {
        nva_npcAgent.destination = finishPos.position;
        anim.SetBool("isWalking", true);
    }
}
