using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public GameObject brickParticle; // variable for brick particle

    void OnCollisionEnter() {
        Instantiate(brickParticle, transform.position, Quaternion.identity); // instantiate brick particle effect on hit
        GameManager.instance.DestroyBrick(); // call the DestroyBrick method from the GameManager
        Destroy(gameObject); // destroy the brick
    }
}
