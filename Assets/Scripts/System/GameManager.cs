using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerPos;

    private string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Database.SetLastScene(sceneName);
    }

    public void SavePlayerPos() => Database.SetPlayerPos(PlayerPos.position);

    public void SaveProgres(string thisSceneName, int currentProgres) => Database.SetProgresScene(thisSceneName, currentProgres);
    public void LoadPlayerPos(Transform target) => target.position = Database.GetPlayerPos();

    public int LastProgresTutorial() => Database.GetProgresScene("Tutorial");
    public int LastProgresWetan() => Database.GetProgresScene("Wetan");
    public int LastProgresKulon() => Database.GetProgresScene("Kulon");
    public int LastProgresBosFight() => Database.GetProgresScene("BosFight");
}
