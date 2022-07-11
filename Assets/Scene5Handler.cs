using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Scene5Handler : MonoBehaviour
{
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject Credits;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clipCredits;
    int playTime;

    private void Start()
    {
        audio.Play();
        audio.loop = true;
        video.GetComponent<VideoPlayer>().Play();

    }

    private void Update()
    {
        if (video.GetComponent<VideoPlayer>().isPlaying == true)
            playTime = playTime == 0 ? 1 : playTime;
        
        if(playTime == 1 && video.GetComponent<VideoPlayer>().isPlaying == false)
            {
                EventsManager.current.OpenPanelCredits();
                return;
            }
    }
}
