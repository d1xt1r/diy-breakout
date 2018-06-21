using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour {

    public GameObject menuObject;

    public float smoother = 1f;
    private Quaternion menuRotation;

    public AudioClip sfx;
    AudioSource audioManager;

    PlayableDirector playableDirector;

    // Use this for initialization
    void Start () {
        menuRotation = transform.rotation;
        audioManager = GetComponent<AudioSource>();
        playableDirector = GetComponent<PlayableDirector>();
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
        SwitchSceneBasedOnMenuRotation();
    }

    void SwitchSceneBasedOnMenuRotation() {
        if (Input.GetKeyDown(KeyCode.Space) && ((menuObject.transform.rotation.eulerAngles.y > 24)&&(menuObject.transform.rotation.eulerAngles.y < 26))) {
            playableDirector.Play();
        }   
    }
}

//A

// (0.0, 0.0, 0.0, 1.0) PLAY
// (0.0, 0.7, 0.0, 0.7) SETTINGS
// (0.0, 1.0, 0.0, 0.0) HOW TO PLAY
// (0.0, 0.7, 0.0, -0.7) QUIT

//B

// (0.0, 0.0, 0.0, -1.0) PLAY
// (0.0, -0.7, 0.0, -0.7) SETTINGS
// (0.0, -1.0, 0.0, 0.0) HOW TO PLAY
// (0.0, -0.7, 0.0, 0.7) QUIT