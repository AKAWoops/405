using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        UnitBase target = other.GetComponent<UnitBase>();
        if(target != null)
        {
            target.TakeDamage(1);
        }
    }
}
