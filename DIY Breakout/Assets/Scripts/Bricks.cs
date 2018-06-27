using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public int timesHits = 0;
    public int maxHits;

    public GameObject brickParticle; // variable for brick particle

    void OnCollisionEnter() {
        timesHits = timesHits + 1; // every hit will increase timeshits by one
        if (timesHits >= maxHits) {
            GameManager.instance.DestroyBrick(); // call the DestroyBrick method from the GameManager
            Destroy(gameObject); // destroy the brick}
            }
        Instantiate(brickParticle, transform.position, Quaternion.identity); // instantiate brick particle effect on hit
    }
}
