using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int minHealth = 0;
[SerializeField] private int maxHealth = 100;

private int health = 100;

private void OnEnable() // new
{
    ClickController.OnClickControllerEvent += TakeDamage;
}

private void OnDisable() // new
{
    ClickController.OnClickControllerEvent -= TakeDamage;
}

private void TakeDamage(ClickController clickController) // changed
{
    health -= 10;

    if (health <= 0)
        Debug.Log("I'm dead now! :(");
}
}