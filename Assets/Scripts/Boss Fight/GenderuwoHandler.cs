using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class GenderuwoHandler : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private float startToInterval = 5;
    [SerializeField] private float minRangeToAttack = 5;
    [SerializeField] private GameObject go_player;
    [SerializeField] private GameObject go_PanelBerdarah;
    [SerializeField] private GameObject go_panelRetry;
    private Transform t_player;

    private Animator anim_Genderuwo;
    private NavMeshAgent nm_Genderuwo;

    private float jarak;

    private bool isAttacking;
    private bool isBleeding;
    private bool isPaused;
    private bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private int isWalkingtoHash;
    private int isDeathtoHash;
    private int isAttacktoHash;
    private int attackLeft = 3;
    private Fade fade;

    private bool canMove = false;
    private void Start()
    {
        t_player = go_player.GetComponent<Transform>();
        anim_Genderuwo = GetComponent<Animator>();
        nm_Genderuwo = GetComponent<NavMeshAgent>();
        fade = GameObject.Find("Fade").GetComponent<Fade>();

        isWalkingtoHash = Animator.StringToHash("isWalking");
        isAttacktoHash = Animator.StringToHash("isAttack");
        isDeathtoHash = Animator.StringToHash("isDeath");

        EventsManager.current.onBosFightProgres += CheckMovement;
        EventsManager.current.onPaused += (v) => isPaused = v;
    }

    private void OnDisable()
    {
        EventsManager.current.onBosFightProgres -= CheckMovement;
        EventsManager.current.onPaused -= (v) => isPaused = v;
    }

    private void Update()
    {
        if (!canMove) return;
        if (isPaused) return;

        MoveGenderuwo();
        Attack();
        CheckBerdarah();
    }

    private void CheckMovement(int progres) => canMove = progres == 2 ?true:false; 

    private void MoveGenderuwo()
    {
        nm_Genderuwo.destination = t_player.position;
        nm_Genderuwo.isStopped = false;
        anim_Genderuwo.SetBool(isWalkingtoHash, true);

        jarak = Vector3.Distance(this.transform.position, t_player.position);
        if (jarak < minRangeToAttack)
        {
            nm_Genderuwo.isStopped = true;
            isAttacking = true;
            canMove = false;
        }
    }

    private void CheckBerdarah()
    {
        if (!isBleeding)
            return;

        go_PanelBerdarah.SetActive(true);
        go_PanelBerdarah.GetComponent<CanvasGroup>().alpha = 1;
        LeanTween.alphaCanvas(go_PanelBerdarah.GetComponent<CanvasGroup>(), 0, 5f);
        if (go_PanelBerdarah.GetComponent<CanvasGroup>().alpha == 0)
        {
            go_PanelBerdarah.GetComponent<CanvasGroup>().alpha = 1;
            go_PanelBerdarah.SetActive(false);
            isBleeding = false;
        }
    }

    private void Attack()
    {
        if (!isAttacking)
            return;


        if (attackLeft == 0)
        {
            go_panelRetry.SetActive(true);

            LeanTween.alphaCanvas(go_panelRetry.GetComponent<CanvasGroup>(), 1, 0.5f);
            EventsManager.current.SetActivationMovement(false);
            nm_Genderuwo.ResetPath();
            canMove = false;
            isAttacking = false;
            attackLeft = 0;
            anim_Genderuwo.SetBool(isWalkingtoHash, false);
            Cursor.visible = true;
            return;
        }

        canMove = false;
        nm_Genderuwo.ResetPath();
        anim_Genderuwo.SetTrigger(isAttacktoHash);

        if (isPlaying(anim_Genderuwo, "Attack")) attackLeft--;

        StartCoroutine(WaitToStartAttack());
        isBleeding = true;
        isAttacking = false;
    }

    public void Death() => StartCoroutine(StartDeath());

    IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(5);
        anim_Genderuwo.SetBool(isDeathtoHash, true);
        if (anim_Genderuwo.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f) fade.FadeIn();
    }

    IEnumerator WaitToStartAttack()
    {
        yield return new WaitForSeconds(startToInterval);
        canMove = true;
    }
}
