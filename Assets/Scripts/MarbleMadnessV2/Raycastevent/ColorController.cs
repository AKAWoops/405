using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    private void OnEnable()
    {
        ClickController.OnClickControllerEvent += ChangeColor;
    }

    private void OnDisable()
    {
        ClickController.OnClickControllerEvent -= ChangeColor;
    }

    private void ChangeColor(ClickController clickController)
    {
        clickController.GetComponent<Renderer>().material.color = RandomColor();
    }

    private Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}