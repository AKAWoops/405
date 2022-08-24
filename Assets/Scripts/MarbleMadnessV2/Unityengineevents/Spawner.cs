using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Spawner : MonoBehaviour {

    public int spawnCount;
    [Range (1,100)]
    public int spawnSize = 1;
    public float pillManOffset = 1;
    public GameObject PillMan;

//    private UnityAction spawnListener;
//
//    void Awake () {
//        spawnListener = new UnityAction (Spawn);
//    }

    void OnEnable () {
//        EventManager.StartListening ("Spawn", spawnListener);
        EventManager.StartListening ("Spawn", Spawn);
    }

    void OnDisable () {
//        EventManager.StopListening ("Spawn", spawnListener);
        EventManager.StopListening ("Spawn", Spawn);
    }

    void Spawn () {
        for (int i = 0; i < spawnCount; i++) {
            Vector3 spawnPosition = GetSpawnPosition ();

            Quaternion spawnRotation = new Quaternion ();
            spawnRotation.eulerAngles = new Vector3 (0.0f, Random.Range (0.0f, 360.0f));
            if (spawnPosition != Vector3.zero) {
                Instantiate (PillMan, spawnPosition, spawnRotation);
            }
        }
    }

    Vector3 GetSpawnPosition () {
        Vector3 spawnPosition = new Vector3 ();
        float startTime = Time.realtimeSinceStartup;
        bool test = false;
        while (test == false) {
            Vector2 spawnPositionRaw = Random.insideUnitCircle * spawnSize;
            spawnPosition = new Vector3 (spawnPositionRaw.x, pillManOffset, spawnPositionRaw.y);
            test = !Physics.CheckSphere (spawnPosition, 0.75f);
            if (Time.realtimeSinceStartup - startTime > 0.5f) {
                Debug.Log ("Time out placing PillMan!");
                return Vector3.zero;
            }
        }
        return spawnPosition;
    }
}