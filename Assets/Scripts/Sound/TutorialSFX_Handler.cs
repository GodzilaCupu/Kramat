using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialSFX_Handler : MonoBehaviour
{
    enum enum_TutorialSFX
    {
        Bus,
        TerimakasihPak,
        Hujan,
        Jangkrik,
        Tokek,
        Gamelan,
    }

    [Header("Audio Configuration")]
    [SerializeField] private AudioSource[] a_source;

    [Space(5)]
    [SerializeField] private AudioClip[] Desclimer;
    [SerializeField] private AudioClip[] BGM;
    [SerializeField] private AudioClip[] Gamelan;

    private int currentProgres;

    [SerializeField] bool isPlayDisclimer = false;
    [SerializeField] bool isPlayGamelan = false;
    [SerializeField] bool isPlayBGM = false;

    bool firstGamelan = true;
    bool first = true;
    bool paused ;

    private void Start()
    {
        CheckedAudioClip();
        PlayLooping(false);
        EventsManager.current.onPaused += (v) => paused = v;
    }
    private void OnDisable()
    {
        EventsManager.current.onPaused -= (v) => paused = v;
    }
    private void Update()
    {
        if(paused)
        {
            a_source[0].Pause();
            a_source[1].Pause();
            return;
        }

        if (isPlayDisclimer && first)
            PlayDislaimerSFX();

        if (isPlayBGM)
            PlayBGM();

        if (isPlayGamelan)
            PlayGamelan();
    }


    public void GetProgres(int progres)
    {
        currentProgres = progres;
        switch (currentProgres)
        {
            case ((int)enum_TutorialState.Disclimer):
                isPlayBGM = false; 
                a_source[0].clip = Desclimer[0];
                a_source[1].clip = Desclimer[1];
                break;


            case ((int)enum_TutorialState.DialogGamelan):
                isPlayDisclimer = false;
                isPlayGamelan = true;
                isPlayBGM = false;
                first = true;
                break;

            case ((int)enum_TutorialState.Credits):
                isPlayDisclimer = false;
                isPlayGamelan = true;
                isPlayBGM = false;
                first = true;
                break;

            case ((int)enum_TutorialState.Bumper):
                isPlayDisclimer = false;
                isPlayGamelan = false;
                isPlayBGM = false;
                first = true;
                StopSound();
                break;

            default:
                isPlayDisclimer = false;
                isPlayGamelan = false;
                isPlayBGM = true;
                break;
        }
    }

    private void CheckedAudioClip()
    {
        for (int i = 0; i < a_source.Length; i++)
        {
            a_source[i].playOnAwake = false;
            a_source[i].loop = false;
        }

        if (Desclimer.Length != 2)
        {
            Debug.Log($"{Desclimer}Clip Still Missing");
            return;
        }

        if (BGM.Length != 3)
        {
            Debug.Log($"{BGM}Clip Still Missing");
            return;
        }

        if (Gamelan == null)
        {
            Debug.Log($"{Gamelan}Clip Still Missing");
            return;
        }
    }

    public void StartPlayDisclimer() => isPlayDisclimer = true;

    public void PlayDislaimerSFX()
    {
        a_source[0].PlayDelayed(0.5f);
        a_source[1].Play();
        first = false;
        
    }

    public void PlayBGM()
    {
        if (a_source[0].isPlaying)
            return;

        a_source[0].clip = BGM[0];
        a_source[0].Play();
        PlayLooping(true);
    }

    public void PlayGamelan()
    {
        if (!isPlayGamelan)
            return;

        if (!firstGamelan) return;

        a_source[0].clip = Gamelan[0];
        a_source[1].clip = Gamelan[1];

        a_source[0].volume = 0.2f;

        a_source[0].Play();
        a_source[1].Play();

        PlayLooping(true);
        PlayLooping(true);
        firstGamelan = false;
    }

    public void PlayLooping(bool isLooping)
    {
        for (int i = 0; i < a_source.Length; i++)
            a_source[i].loop = isLooping;
    }

    public void StopSound()
    {
        for (int i = 0; i < a_source.Length; i++)
            a_source[i].Pause();

        PlayLooping(false);
    }

}
