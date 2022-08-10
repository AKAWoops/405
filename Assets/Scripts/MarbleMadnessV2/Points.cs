using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int value = 10;
    public GameObject explosionPrefab;

    void OnTriggerEnter (Collider other)
    { // makes sure object with player tag is what picking up points
        if (other.gameObject.tag == "Player") {
            if (GameManager.gm!=null)
            {
                // tell the game manager to Collect points
                GameManager.gm.Collect (value);
            }
			
            // explode if specified
            if (explosionPrefab != null) {
                Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            }
			
            // destroy after collection
            Destroy (gameObject);
        }
    }
}
