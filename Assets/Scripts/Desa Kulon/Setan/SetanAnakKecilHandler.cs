using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetanAnakKecilHandler : MonoBehaviour
{
    [Header("Target / player")]
    [SerializeField] private Transform tr_target;
    [SerializeField] private float f_minDistanceToPlayer;
    private float f_distanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, tr_target.position);
        return distance;
    }
    [Header("Setan Anak Kecil Komponen"), Space(10)]
    [SerializeField] private Ki_DalangHandler kiDalanghandler;
    
    [Tooltip("0 = resetPos," +
             "1 = Inside House 4," +
             "2 = Pointing Drawer," +
             "3 = StartToBosFight" +
             "4 = BosfightFinish  ")]
    [SerializeField] private List<Transform> tr_waypoint;
    [SerializeField] private NavMeshAgent nva_this;
    [SerializeField] private Animator anim_this;

    [Header("Destination"), Space(5)]
    [SerializeField] private bool onDestination = false;
    [SerializeField] private float f_minRangeToDestination;


    public bool OnDestination { get { return onDestination; } }

    private int walkAnimtoHash;
    private int pointingAnimtoHash;

    private int kulonProgres;

    // Start is called before the first frame update
    void Start()
    {
        kiDalanghandler = GameObject.Find("Ki Dalang").GetComponent<Ki_DalangHandler>();
        GetAnimationParameter();
        EventsManager.current.onKulonProgres += CheckProgres;
    }

    private void OnDisable()
    {
        EventsManager.current.onKulonProgres -= CheckProgres;
    }

    private void CheckProgres(int progres) => kulonProgres = progres;

    private void GetAnimationParameter()
    {
        walkAnimtoHash = Animator.StringToHash("isWalking");
        pointingAnimtoHash = Animator.StringToHash("isNunjuk");
    }

    // Update is called once per frame
    void Update()
    {
        TriggerSenter();
        CheckTask(kulonProgres);
    }

    private void CheckTask(int progres)
    {
        switch (progres)
        {
            // Jalan Ke Rumah Nomor 4
            case 0:
                if (f_distanceToPlayer() < f_minDistanceToPlayer)
                    WalkToHouse4();
                CheckInDestination(tr_waypoint[1],f_minRangeToDestination);
                break;

            case 2:
                if (!kiDalanghandler.AlreadyFalling) return;
                PointingDrawer();
                break;

            case 3:
                WalkingToBosFight();
                CheckInDestination(tr_waypoint[3],f_minRangeToDestination);
                break;
        }
    }

    private void TriggerSenter()
    {
        if(f_distanceToPlayer() < 1.5f)
        {
            EventsManager.current.SetFlashlightBlink(true);
            return;
        }
        EventsManager.current.SetFlashlightBlink(false);
    }

    private void CheckInDestination(Transform destination, float minRange)
    {
        float targetDistance = Vector3.Distance(nva_this.transform.position, destination.transform.position);

        if (targetDistance < minRange)
            onDestination = true;
    }

    private void WalkToHouse4()
    {
        nva_this.SetDestination(tr_waypoint[1].position);
        
        //CheckUdahSampe
        if (onDestination)
        {
            nva_this.ResetPath();
            anim_this.SetBool(walkAnimtoHash, false);
            gameObject.transform.position = tr_waypoint[0].position;
            return;
        }

        //CheckJarakKePlayer
        if (f_distanceToPlayer() > 20f)
        {
            nva_this.isStopped = true;
            anim_this.SetBool(walkAnimtoHash, false);
            return;
        }

        // Jalan KeTujuan
        nva_this.isStopped = false;
        anim_this.SetBool(walkAnimtoHash, true);


    }
    
    private void PointingDrawer()
    {
        onDestination = false;
        gameObject.transform.position = tr_waypoint[2].position;
        gameObject.transform.rotation = tr_waypoint[2].rotation;
        anim_this.SetBool(pointingAnimtoHash, true);
    }

    private void WalkingToBosFight()
    {
        if (onDestination)
        {
            nva_this.ResetPath();
            gameObject.transform.rotation = tr_waypoint[4].rotation;
            anim_this.SetBool(pointingAnimtoHash, true);
            return;
        }

        gameObject.transform.position = tr_waypoint[3].position;
        gameObject.transform.rotation = tr_waypoint[3].rotation;
        anim_this.SetBool(pointingAnimtoHash, false);
        nva_this.SetDestination(tr_waypoint[4].position);

        if (f_distanceToPlayer() < f_minDistanceToPlayer)
        {
            nva_this.isStopped = true;
            anim_this.SetBool(walkAnimtoHash, false);
            return;
        }

        nva_this.isStopped = false;
        anim_this.SetBool(walkAnimtoHash, true);
    }

}
