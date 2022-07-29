using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Scene5Handler : MonoBehaviour
{
    [SerializeField] AudioSource aSource;
    [SerializeField] private VideoPlayer vPlayer;
    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private GameObject Credits;

    bool isDone = false;
    bool playCredits = false;
    float playTime;

    private void Start()
    {
        aSource.loop = true;
        aSource.Play();
        vPlayer.Play();
        playTime = vPlayer.frameCount - 1;
    }

    private void Update()
    {
        CheckPause();
        if (vPlayer.frame == playTime)
            PlayCredits();
    }

    private void PlayCredits()
    {
        if (playCredits) return;

        EventsManager.current.OpenPanelCredits();
        playCredits = true;
        isDone = true;
    }

    private void CheckPause()
    {
        if(!pausedPanel.activeInHierarchy)
        {
            if (isDone) 
            {
                aSource.Play();

                if (isDone && LeanTween.tweensRunning > 0) return;
                SceneManager.LoadScene("MainMenu");
                return;
            }

            if(vPlayer.isPlaying) return;
            vPlayer.Play();
            aSource.Play();
            return;
        }
        vPlayer.Pause();
        aSource.Pause();

    }
}
