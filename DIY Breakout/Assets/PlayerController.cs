using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int speed = 50;
    public Transform paddle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float velocity = inputHorizontal * speed;
        paddle.transform.Translate(Vector2.right * velocity * Time.deltaTime);
	}
}
