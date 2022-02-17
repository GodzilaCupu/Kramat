using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [Header("ray Atribute")]
    [SerializeField] private float _rangeToRaycast;
    private RaycastHit ray;



    private Camera _thisCamera;


    public RaycastHit Ray { get => ray; set => ray = value; }

    public void CrosshairRaycast()
    {
        _thisCamera = GetComponent<Camera>();
        if(Physics.Raycast(_thisCamera.transform.position,_thisCamera.transform.forward,out ray,_rangeToRaycast))
        {
            Debug.DrawLine(_thisCamera.transform.position,ray.transform.position ,Color.red);
            Debug.Log(ray.transform.name + " Range =" + Vector3.Distance(_thisCamera.transform.position, ray.transform.position));
            
        }

    }
}
