using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class CameraRaycast : MonoBehaviour
{
    [Header("ray Atribute")]
    [SerializeField] private Image _crosshair;
    [SerializeField] private float _rangeToRaycast;
    private RaycastHit ray;

    private Camera _thisCamera;
    public bool inRange ()=> Physics.Raycast(_thisCamera.transform.position, _thisCamera.transform.forward, out ray, _rangeToRaycast);
    public bool onTrack ()=> Physics.Raycast(_thisCamera.transform.position, _thisCamera.transform.forward, out ray);

    public bool OnTrack => onTrack();
    public bool InRange => inRange();


    [Header("Object Holder")]
    [SerializeField] private Transform _objHolder;

    private void Start()
    {
        _thisCamera = GetComponent<Camera>();
        onTrack();
        inRange();
    }

    public void CrosshairRaycast()
    {
        if (inRange())
        {
            //DO Change Parent Obj
            Debug.DrawLine(_thisCamera.transform.position, ray.transform.position, Color.red);
            Debug.Log(ray.transform.name + " Range =" + Vector3.Distance(_thisCamera.transform.position, ray.transform.position));
        }
    }

    public void ChangeCrosshairColor(Color color) => _crosshair.color = color;

    public void ChangeCrosshairSize(float size) => _crosshair.rectTransform.localScale = new Vector3(size, size);

}
