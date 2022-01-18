using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject loadingCanvas;
    

    private void Awake()
    {
        
    }

    public void LoadLoadingScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)Enum.LoadingScene) loadingCanvas = GameObject.Find("LoadingCanvas");


    }

}
