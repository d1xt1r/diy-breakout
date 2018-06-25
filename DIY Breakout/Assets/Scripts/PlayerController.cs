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

        // input + movement

        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float velocity = inputHorizontal * speed;
        paddle.transform.Translate(Vector2.right * velocity * Time.deltaTime);

        // movement restriction 

        if (transform.position.x <= -19.34f) {
            transform.position = new Vector3(-19.34f, 0f, 0f);
        }
        if (transform.position.x >= 19.34f) {
            transform.position = new Vector3(19.34f, 0f, 0f);
        }
	}
}
