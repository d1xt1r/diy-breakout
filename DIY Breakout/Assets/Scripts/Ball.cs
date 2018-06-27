using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float initialBallVelocity = 150;
    Rigidbody ballRigidbody;
    private bool ballIsLanched; 

	// Use this for initialization
	void Awake () {
        ballRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Launch the ball

        if (Input.GetKeyDown(KeyCode.Space) && ballIsLanched == false) {
            transform.parent = null;  // To release the ball from the pad
            ballIsLanched = true; // Ball is  now in play. Pressing space again will not do anything.
            ballRigidbody.isKinematic = false; // is true by default. Now ball is affected by the physics. If true, the next line will not do anything.
            ballRigidbody.AddForce(new Vector3(initialBallVelocity, initialBallVelocity, 0));
        }
	}

    // small displacement of the ball so it cannot go into one-directional loop.

    void OnCollisionEnter() {
        Vector3 randomDisplacement = new Vector3(Random.Range(0.1f, 0.5f), Random.Range(0.1f, 0.5f));
        ballRigidbody.velocity = ballRigidbody.velocity + randomDisplacement;
    }
}
