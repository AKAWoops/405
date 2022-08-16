using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public static event Action<ClickController> OnClickControllerEvent; // new

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnLeftClick();
    }

    private void OnLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("The cube was clicked! Notifying subscribers!");

            if (OnClickControllerEvent != null) // new
                OnClickControllerEvent(this);
        }
    }
}