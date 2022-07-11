using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum enum_GrabOption
{
    E,
    LeftClick
}

[RequireComponent(typeof(Camera))]
public class CameraRaycast : MonoBehaviour
{
    [Header("ray Atribute")]
    [SerializeField] private Image _crosshair;
    [SerializeField] private float _rangeToRaycast;
    [SerializeField] private enum_GrabOption grabOption;

    private RaycastHit ray;
    private Camera _thisCamera;

    public float GetMinRange { get { return _rangeToRaycast; } }
    public bool inRange ()=> Physics.Raycast(_thisCamera.transform.position, _thisCamera.transform.forward, out ray, _rangeToRaycast);
    public bool onTrack ()=> Physics.Raycast(_thisCamera.transform.position, _thisCamera.transform.forward, out ray);

    [Header("Object Holder")]
    public bool crosairOn;
    public bool isGrabing;
    public bool isTalking;

    private int idWetan = 0;
    private int idKulon = 0;
    private int idBosFight = 0;

    private Vector3 sizeCorsairDefault = Vector3.one;
    private Color colorCorsairDefault = Color.white;

    private void Start()
    {
        _thisCamera = GetComponent<Camera>();
        onTrack();
        inRange();
        CheckScene(true);
    }

    private void OnDisable()
    {
        CheckScene(false);
    }

    private void CheckScene(bool Start)
    {
        string name = SceneManager.GetActiveScene().name;
        if (Start)
        {
            switch (name)
            {
                case "Wetan":
                    EventsManager.current.onWetanProgres += (v) => idWetan = v;
                    break;

                case "Kulon":
                    EventsManager.current.onKulonProgres += (v) => idKulon = v;
                    break;

                case "BosFight":
                    EventsManager.current.onBosFightProgres += (v) => idBosFight = v;
                    break;
            }
            return;
        }
        switch (name)
        {
            case "Wetan":
                EventsManager.current.onWetanProgres -= (v) => idWetan = v;
                break;

            case "Kulon":
                EventsManager.current.onKulonProgres -= (v) => idKulon = v;
                break;

            case "BosFight":
                EventsManager.current.onBosFightProgres -= (v) => idBosFight = v;
                break;
        }
    }

    private void FixedUpdate()
    {
        CrosshairRaycast();
        CheckBtn(grabOption);
        InspectKeris();
    }

    public void CrosshairRaycast()
    {
        EventsManager.current.SetRaycast(false);

        if (SceneManager.GetActiveScene().name == "Tutorial")
            return;
            
        EventsManager.current.CheckDisplayItem(false);
        EventsManager.current.NPCDialogTrigger(false);
        EventsManager.current.CheckDisplayNPC(false);

        CheckCroshair();
        CheckInRange();

    }

    private void CheckInRange()
    {
        if (!inRange()) return;

        if (ray.transform.gameObject.tag == "Item")
        {
            ChangeCrosshairColor(Color.blue);
            ChangeCrosshairSize(new Vector3(2, 2, 2));

            EventsManager.current.SetRaycast(true);
            EventsManager.current.CheckDisplayItem(true);
            EventsManager.current.CheckNameItem(ray.transform.gameObject.name);

            if (isGrabing)
            {
                EventsManager.current.CheckNameItem(ray.transform.gameObject.name);
                EventsManager.current.GrabItemTrigger(ray.transform.gameObject);
            }
        }

        if (ray.transform.gameObject.tag == "NPC")
        {
            ChangeCrosshairColor(Color.red);
            ChangeCrosshairSize(new Vector3(2, 2, 2));

            EventsManager.current.SetRaycast(true);
            EventsManager.current.CheckDisplayNPC(true);
            EventsManager.current.CheckNameNPC(ray.transform.gameObject.name);
            if(isTalking)
                EventsManager.current.NPCDialogTrigger(true);

        }

        if (ray.transform.gameObject.tag == "Sesajen")
        {
            EventsManager.current.SetRaycast(true);
            ChangeCrosshairColor(Color.yellow);
            ChangeCrosshairSize(new Vector3(2, 2, 2));
            if (isGrabing)
                EventsManager.current.AttackTrigger(ray.transform.gameObject);
        }
    }

    private void CheckBtn(enum_GrabOption option)
    {
        if(option == enum_GrabOption.E)
        {
            isTalking = CustomInputMap.current.GetPlayerNPC_ItemInterect();
            isGrabing = CustomInputMap.current.GetPlayerNPC_ItemInterect();
            return;
        }

        isGrabing = CustomInputMap.current.GetPlayerGrabObject();
        isTalking = CustomInputMap.current.GetPlayerNPC_ItemInterect();
    }

    private void InspectKeris()
    {
        if (isTalking && SceneManager.GetActiveScene().name == "BosFight")
            EventsManager.current.InspectKeris();
    }

    public void CheckCroshair()
    {
        crosairOn = CustomInputMap.current.GetPaused();
        _crosshair.enabled = crosairOn  ? false : true;

        if (!inRange())
        {
            ChangeCrosshairColor(colorCorsairDefault);
            ChangeCrosshairSize(sizeCorsairDefault);
        }
    }

    public void ChangeCrosshairColor(Color color) => _crosshair.color = color;

    public void ChangeCrosshairSize(Vector3 size) => _crosshair.gameObject.transform.localScale = size;

}
