using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    public float smoother = 1f;
    private Quaternion menuRotation;

    public AudioClip sfx;
    AudioSource audioManager;

    // Use this for initialization
    void Start () {
        menuRotation = transform.rotation;
        audioManager = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            menuRotation = menuRotation * Quaternion.AngleAxis(90, Vector3.up);
            audioManager.PlayOneShot(sfx);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            menuRotation = menuRotation * Quaternion.AngleAxis(-90, Vector3.up);
            audioManager.PlayOneShot(sfx);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, menuRotation, smoother * 10 * Time.deltaTime);
    }
}
