using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 10.0f;

    public bool damageOnTrigger = true;
    public bool damageOnCollision = false;
    public bool continuousDamage = false;
    public float continuousTimeBetweenHits = 0;

    public bool destroySelfOnImpact = false; // variables dealing with exploding on impact (area of effect)
    public float delayBeforeDestroy = 0.0f;
    public GameObject explosionPrefab;

    private float savedTime = 0;

    void OnTriggerEnter(Collider collision) // used for things like bullets, which are triggers.  
    {
        if (damageOnTrigger)
        {
            if (this.tag == "PlayerBullet" &&
                collision.gameObject.tag == "Player") // if the player got hit with it's own bullets, ignore it
                return;

            if (collision.gameObject.GetComponent<Health>() != null)
            {
                // if the hit object has the Health script on it, deal damage
                collision.gameObject.GetComponent<Health>().ApplyDamage(damageAmount);

                if (destroySelfOnImpact)
                {
                    Destroy(gameObject, delayBeforeDestroy); // destroy the object whenever it hits something
                }

                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }
            }
        }
    }
}
