using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{

    public int health;
    public int speed;
    private Rigidbody body;



    private void Awake()
    {
        body =GetComponent<Rigidbody>();
    }
    public virtual void TakeDamage(int damage)
    {

    }





}
