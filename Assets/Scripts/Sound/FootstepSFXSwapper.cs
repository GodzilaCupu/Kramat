using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSFXSwapper : MonoBehaviour
{
    private TerrainChacker _chacker;
    private ControllerPlayer _player;

    private string _currentLayer;

    WalkingScrptibleObject[] walkingSoundCollections;

    private void Start()
    {
        _chacker = new TerrainChacker();
        _player = GetComponent<ControllerPlayer>();
    }

    public void CheckLayer()
    {
        //Raycast hit to store Data Raycast
        //RayCasting Downward to Checking Terain;
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit, 3))
        {
            //Checking if There have Terain on bottom
            if(hit.transform.GetComponent<Terrain>() != null)
            {
                Terrain t = hit.transform.GetComponent<Terrain>();

                //get Layer of Current Layer form Raycast
                if(_currentLayer != _chacker.GetLayerName(transform.position, t))
                {
                    _currentLayer = _chacker.GetLayerName(transform.position, t);
                    //Swap the Data Collections
                    foreach(WalkingScrptibleObject data in walkingSoundCollections)
                    {
                        if(_currentLayer == data.name)
                        {
                            _player.SwapAudioCollections(data);
                        }
                    }
                }
            }
        }

    }
}
