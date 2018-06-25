using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxAnimator : MonoBehaviour {

    public float speed = 1f;
    
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
