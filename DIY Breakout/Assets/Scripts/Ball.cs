using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 10;
    Rigidbody ballRigidbody;

	// Use this for initialization
	void Start () {
        ballRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ballRigidbody.AddForce(Vector3.down * speed);
	}
}
