using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerPos;

    private string sceneName;
    public string LastSceneName;

    public int TutorialProgres;
    public int WetanProgres;
    public int KulonProgres;
    public int BosFightProgres;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        LastSceneName = sceneName;
    }

    public void LoadLastPosPlayer(ProgresData data) => PlayerPos.position = new Vector3(data.PlayerPositions[0], data.PlayerPositions[1], data.PlayerPositions[2]);

    public void LoadLastProgresTutorial(ProgresData data) => TutorialProgres = data.tutorialProgres;
    public void LoadLastProgresWetan(ProgresData data) => WetanProgres = data.wetanProgres;
    public void LoadLastProgresKulon(ProgresData data) => KulonProgres = data.kulonProgres;
    public void LoadLastProgresBosFight(ProgresData data) => BosFightProgres = data.bosFightProgres;


    public void SaveProgres() => Save_Data.SaveProgres(this);
}
