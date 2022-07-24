using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntroHandler : MonoBehaviour
{
    [SerializeField] private GameObject go_container;

    private GameManager manager;
    private RenderTexture t_video;
    private VideoPlayer videoplayer;

    private bool canPlay;
    private bool isPaused;

    void Start()
    {
        videoplayer = go_container.GetComponent<VideoPlayer>();
        t_video = go_container.GetComponent<RenderTexture>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        EventsManager.current.onPaused += (v) => isPaused = v; 
        EventsManager.current.onTutorialProgres += CheckPlayIntro;
        videoplayer.loopPointReached += CheckIsDone;
    }

    private void OnDisable()
    {
        EventsManager.current.onPaused -= (v) => isPaused = v;
        EventsManager.current.onTutorialProgres -= CheckPlayIntro;
        videoplayer.loopPointReached -= CheckIsDone;
    }

    private void CheckIsDone(VideoPlayer source)
    {
        canPlay = false;
        videoplayer.Stop();
        go_container.SetActive(canPlay);
        manager.SaveProgres(SceneManager.GetActiveScene().name, (int)enum_TutorialState.Bumper);
        SceneManager.LoadScene("Wetan");
    }

    void Update()
    {
        if (isPaused)
        {
            videoplayer.Pause();
            return;
        }

        if (canPlay)
            PlayVideo();
    }

    private void PlayVideo()
    {
        if (!go_container.activeInHierarchy)
            go_container.SetActive(true);


        EventsManager.current.SetActivationMovement(false);
        EventsManager.current.PlaySFXTutorial(((int)enum_TutorialState.Bumper));
        go_container.SetActive(canPlay);
        videoplayer.Play();
    }

    private void CheckPlayIntro(int count) => canPlay = count == ((int)enum_TutorialState.Bumper) ? true : false;
}
