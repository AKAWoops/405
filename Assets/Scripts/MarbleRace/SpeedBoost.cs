using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private Transform _boostDirection;

    [SerializeField] private float _force;

    [SerializeField] private ForceMode _forceMode;

    private void OnTriggerStay(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(_boostDirection.forward * _force, _forceMode);
        }
    }
}
