using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BanaspatiHandler : MonoBehaviour
{
    [Header("Agent Configuration")]
    private Animator anim_banaspati;
    private NavMeshAgent nva_banaspatiAgent;
        
    [Header("Target Configuration")]
    [SerializeField] private GameObject go_player;

    [Header("Start Configuration"),Space(5)]
    [SerializeField] private Transform baseStart;
    [SerializeField] private Transform StartToChasePos;

    public bool CanChasing;
    private float f_distanceFromStart()
    {
        float distance = Vector3.Distance(this.transform.position, baseStart.position);
        return distance;
    }

    [Header("Progres Configuration"), Space(5)]
    public int kulonProgres;

    private void Start()
    {
        
        EventsManager.current.onKulonProgres += GetProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= GetProgres;
    }

    private void GetProgres(int progres) => kulonProgres = progres;

    private void Update()
    {
        if (CanChasing == true) ChassePlayer();
    }

    public void ChassePlayer()
    {
        AnimOut();
        float distanceToPlayer = Vector3.Distance(this.transform.position, go_player.transform.position);

        if (distanceToPlayer < 3f && f_distanceFromStart() < 10f)
        {
            nva_banaspatiAgent.SetDestination(go_player.transform.position);
            nva_banaspatiAgent.speed *= 2;
            if (nva_banaspatiAgent.remainingDistance < 0.3f)
                EventsManager.current.ResetPlayerPosition();
        }
        else
        {
            nva_banaspatiAgent.ResetPath();
            nva_banaspatiAgent.SetDestination(StartToChasePos.position);
            nva_banaspatiAgent.speed /= 2;
            if (nva_banaspatiAgent.remainingDistance < 0.3f)
                AnimIn();
        }
    }

    private void AnimOut() => LeanTween.move(this.gameObject, StartToChasePos.position, 1f);

    private void AnimIn() => LeanTween.move(this.gameObject, baseStart.position, 1f);

}
