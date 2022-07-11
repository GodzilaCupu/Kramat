using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgresData
{
    [Header("Player")]
    public float[] PlayerPositions;

    [Header("Progres")]
    public string lastSceneName;
    public int tutorialProgres;
    public int wetanProgres;
    public int kulonProgres;
    public int bosFightProgres;

    public ProgresData(GameManager data)
    {
        PlayerPositions = new float[3];
        PlayerPositions[0] = data.PlayerPos.position.x;
        PlayerPositions[0] = data.PlayerPos.position.y;
        PlayerPositions[0] = data.PlayerPos.position.z;

        tutorialProgres = data.TutorialProgres;
        wetanProgres = data.WetanProgres;
        kulonProgres = data.KulonProgres;
        bosFightProgres = data.BosFightProgres;
        lastSceneName = data.LastSceneName;
    }
}
