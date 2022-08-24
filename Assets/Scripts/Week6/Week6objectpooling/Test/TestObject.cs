using System;
using UnityEngine;
using System.Collections;
public class TestObject : PoolObject
{
    //workaround fro trail renderer
    TrailRenderer trail;
    float trailTime;

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trailTime = trail.time;
    }


    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * 3;
        transform.Translate(Vector3.forward * Time.deltaTime * 25);
    }

    public override void OnObjectReuse()
    {
        trail.time = -1;
        Invoke("ResetTrail", .1f);
        transform.localScale = Vector3.one;
    }
// trail workaround incorportation
    void ResetTrail()
    {
        trail.time = trailTime;
    }
    
}
