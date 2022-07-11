using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumurHandler : MonoBehaviour
{
    [SerializeField] GameObject[] go_sumur;
    [SerializeField] Animator anim_sumur;
    [SerializeField] AudioSource asource_sumur;

    private bool isPlaying()
    {
        if (anim_sumur.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            return false;
        else
            return true;
    }

    private void Start()
    {
        EventsManager.current.onSumurPlay += PlaySumur;
    }
    private void OnDisable()
    {    
        EventsManager.current.onSumurPlay += PlaySumur;
    }

    private void ChangeSumur()
    {
        go_sumur[0].SetActive(false);
        go_sumur[1].SetActive(true);
    }

    private void PlaySumur()
    {
        EventsManager.current.SetActivationMovement(false);
        anim_sumur.SetTrigger("isPlaying");
        StartCoroutine(PlayBabySound());

        if (isPlaying() == false)
            EventsManager.current.SetActivationMovement(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TuasSumur")
        {
            collision.gameObject.SetActive(false);
            ChangeSumur();
        }
    }
    
    private IEnumerator PlayBabySound()
    {
        yield return new WaitForSeconds(3f);
        asource_sumur.Play();
    }

}
