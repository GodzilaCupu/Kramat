using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomInputManager))]
public class GameManager : MonoBehaviour
{
    private CustomInputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<CustomInputManager>();
    }

    private void GetPause()
    {
        if(inputManager.GetESCPressed() != 1)
        {

        }
    }
}
