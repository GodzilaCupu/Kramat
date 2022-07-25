using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Wetan_Handler : MonoBehaviour
{
    [SerializeField] private enum_NPCNameWetan npcName;
    [SerializeField] private List<Transform> npcPos;

    [SerializeField] private DialogHandler dialogHandler;
    [SerializeField] private WetanSceneManager storyHandler;

    [SerializeField] private float minDistanceToInteraction;
    [SerializeField] private float minDistanceToTeleport;
    [SerializeField] private bool canMove;  
    private float distanceToPlayer;
    private bool isMove;

    [SerializeField] private Animator anim;

    private GameObject player;
    private CameraRaycast raycast;
    private ControllerPlayer controllerPlayer;
    private HandleposHandler itemCarrier;

    private int npcProgres;
    private bool canTalk;
    private bool canDisplayDialog;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        controllerPlayer = player.GetComponent<ControllerPlayer>();

        storyHandler = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WetanSceneManager>();
        raycast = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraRaycast>();
        dialogHandler = GameObject.Find("Popup_Percakapan").GetComponent<DialogHandler>();
        itemCarrier = GameObject.Find("Handle Pos").GetComponent<HandleposHandler>();

        minDistanceToInteraction = raycast.GetMinRange;

        EventsManager.current.onNPCDialogueTrigger += (v) => canDisplayDialog = v;
        EventsManager.current.onDialougeTrigger += (v) => canTalk = v;
        EventsManager.current.onWetanProgres += (v) => npcProgres = v;
        EventsManager.current.onMoveNPCWetan += (v) => isMove = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onNPCDialogueTrigger -= (v) => canDisplayDialog = v;
        EventsManager.current.onDialougeTrigger -= (v) => canTalk = v;
        EventsManager.current.onWetanProgres -= (v) => npcProgres = v;
        EventsManager.current.onMoveNPCWetan -= (v) => isMove = v;
    }

    private void Update()
    {
        CheckDistanceToPlayer();
        
        TalkingtoPlayer(npcProgres);
        CheckTalkAnimation();
        CheckSpecialAnimation();

        if (!isMove)
            return;

        CheckCanMove();
    }

    #region Animasi
    private void CheckTalkAnimation() => anim.SetBool("isTalk", canTalk);

    private void CheckSpecialAnimation()
    {
        if (!canMove)
            return;

        if(npcName == enum_NPCNameWetan.Budi || npcName == enum_NPCNameWetan.Anto)
        {
            if (npcProgres != 6)
            {
                this.transform.position = npcPos[0].position;
                this.transform.rotation = npcPos[0].rotation;
                return;
            }
            this.transform.position = npcPos[1].position;
            this.transform.rotation = npcPos[1].rotation;
            anim.SetBool("isBerbaring", true);
        }
    }
    #endregion

    #region Move NPC

    private void CheckDistanceToPlayer() => distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

    private void CheckCanMove()
    {
        if (distanceToPlayer < minDistanceToTeleport) return;
        GetUpdatePosition();
    }

    public void GetUpdatePosition()
    {
        if (!canMove)
            return;

        switch (npcName)
        {
            case enum_NPCNameWetan.KepalaDesa:
                switch (npcProgres)
                {
                    case ((int)enum_WetanState.TemuiKepalaDesa):
                        this.transform.position = npcPos[0].position;
                        this.transform.rotation = npcPos[0].rotation;
                        EventsManager.current.MoveNPCWetan(false);
                        break;

                    case ((int)enum_WetanState.MengambilPacul):
                        this.transform.position = npcPos[1].position;
                        this.transform.rotation = npcPos[1].rotation;
                        EventsManager.current.MoveNPCWetan(false);
                        break;
                }
                break;

            case enum_NPCNameWetan.KetuaAdat:
                switch (npcProgres)
                {
                    case ((int)enum_WetanState.PergiKePakCokro):
                        this.transform.position = npcPos[0].position;
                        this.transform.rotation = npcPos[0].rotation;
                        EventsManager.current.MoveNPCWetan(false);
                        break;

                    case ((int)enum_WetanState.KembaliKeKetuaAdat):
                        this.transform.position = npcPos[1].position;
                        this.transform.rotation = npcPos[1].rotation;
                        EventsManager.current.MoveNPCWetan(false);
                        break;

                    case ((int)enum_WetanState.PergiKeBalaiDesa):
                        this.transform.position = npcPos[2].position;
                        this.transform.rotation = npcPos[2].rotation;
                        EventsManager.current.MoveNPCWetan(false);
                        break;

                }
                break;
        }
    }
    #endregion

    #region Dialouge

    private void TalkingtoPlayer(int progres)
    {
        if (distanceToPlayer > minDistanceToInteraction)
        {
            canDisplayDialog = false;
            return;
        }

        if (!canDisplayDialog) return;

        EventsManager.current.DialougeTrigger(true);

        switch (npcName)
        {
            case enum_NPCNameWetan.KepalaDesa:
                KepalaDesa(progres);
                break;

            case enum_NPCNameWetan.KetuaAdat:
                KetuaAdat(progres);
                break;

            case enum_NPCNameWetan.Cokro:
                Cokro(progres);
                break;

            case enum_NPCNameWetan.Aji:
                Aji(progres);
                break;
        }
    }

    private void KepalaDesa(int progres)
    {
        switch (progres)
        {
            case ((int)enum_WetanState.TemuiKepalaDesa):
                if (!canTalk)
                    return;
                if (dialogHandler.IsFinished) EventsManager.current.CheckProgresWetan(1);

                EventsManager.current.DialogWetanProgres(1);
                break;

            case ((int)enum_WetanState.MengambilPacul):
                if (!canTalk)
                    return;

                if (itemCarrier.IsCarriedSomething && itemCarrier.ItemName == "Cangkul")
                    EventsManager.current.DialogWetanProgres(2);
                break;

            case ((int)enum_WetanState.MenggemburkanTanah):
                if (!canTalk)
                    return;

                if (storyHandler.SawahDone) EventsManager.current.DialogWetanProgres(3);
                break;

            default:
                if (!canTalk)
                    return;

                EventsManager.current.DialogWetanProgres(0);
                break;
        }
    }

    private void KetuaAdat(int progres)
    {
        switch (progres)
        {
            case ((int)enum_WetanState.TemuiKetuaAdat):
                if (!canTalk)
                    return;

                EventsManager.current.DialogWetanProgres(4);
                break;

            case ((int)enum_WetanState.KembaliKeKetuaAdat):
                if (!canTalk)
                    return;

                if (itemCarrier.IsCarriedSomething && itemCarrier.ItemName == "Gergaji")
                    EventsManager.current.DialogWetanProgres(7);
                break;

            case ((int)enum_WetanState.PergiKeBalaiDesa):
                if (!canTalk)
                    return;

                EventsManager.current.DialogWetanProgres(8);
                break;

            default:
                if (!canTalk)
                    return;

                EventsManager.current.DialogWetanProgres(0);
                break;
        }
    }

    private void Cokro(int progres)
    {
        if(progres == ((int)enum_WetanState.PergiKePakCokro))
        {
            if (!canTalk)
                return; 

            EventsManager.current.DialogWetanProgres(5);
     
            return;
        }
        if (!canTalk)
            return; 
       
        EventsManager.current.DialogWetanProgres(0);
    }

    private void Aji(int progres)
    {
        if (progres == ((int)enum_WetanState.PergiKePakAji))
        {
            if (!canTalk)
                return;

            EventsManager.current.DialogWetanProgres(6);
            return;
        }

        if (!canTalk)
            return;

        EventsManager.current.DialogWetanProgres(0);
    }
    #endregion
}
