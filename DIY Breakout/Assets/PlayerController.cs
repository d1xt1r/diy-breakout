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

        if (transform.position.x <= -16.990f) {
            transform.position = new Vector3(-16.990f, 1.014f, -19.506f);
        }
        if (transform.position.x >= 16.990f) {
            transform.position = new Vector3(16.990f, 1.014f, -19.506f);
        }
	}
}
