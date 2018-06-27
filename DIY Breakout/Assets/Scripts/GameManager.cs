using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int lives;
    public int bricks;
    public float resetDelay = 1f;
    public Text livesText;
    public Text bricksText;
    public GameObject gameOver;// game over text from the inspectpr
    public GameObject youWon; // you won text from the from the inspector 
    public GameObject bricksPrefab; // bricks prefab from the inspector 
    public GameObject paddlePrefab; // paddle prefab from the inspector 
    public GameObject levelCompletedParticles; // level completed particles
    public GameObject deathParticles; // death particles from the inspector
    
    private GameObject createPaddle; // variable for instantiate the paddle
    private GameObject createBricks;

    public AudioClip hitSound;
    public AudioClip levelCompleteSound;
    AudioSource audioSource;

    // Use this for initialization
    void Awake () {

        audioSource = GetComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;
        livesText.text = "Lives: " + lives.ToString(); // display the text in the UI
        bricksText.text = "Bricsk left: " + bricks.ToString();

        // Singleton Pattern. 

        if (instance == null) { // if we don't have a game manager yet, this will be the game manager.
            instance = this;
        } else if (instance != this) { // if there is already a game manager, destory this game manager.
            Destroy(gameObject);
        }
        InstantiateObjectsForFirstTime();
    }

    public void InstantiateObjectsForFirstTime() {
        createPaddle = (GameObject)Instantiate(paddlePrefab, transform.position, Quaternion.identity); // Instantiate the paddle at 0,0,0 (becase GameManager is at 0,0,0) with no rotation and cast it as a game object. Casting is needed because Instantiate creates an item of type 'Object', not 'GameObject'. To access the extra features of the item, it needs to be upcasted to GameObject.
        createBricks = Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void IsGameOver() {
        if(lives < 1) {
            gameOver.SetActive(true);
            Time.timeScale = .10f;
            Invoke("ResetGame", resetDelay);
        }
    }

    void NoMoreBricks() {
        if(bricks < 1) {
            audioSource.PlayOneShot(levelCompleteSound);
            youWon.SetActive(true);
            createPaddle.SetActive(false);
            Time.timeScale = .10f;
            Invoke("LoadNextLevel", .5f);
            levelCompletedParticles.SetActive(true);
        }
    }

    void ResetGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void LoseLife() {
        lives = lives - 1; // if ball falls into dead zone substract 1 from lives
        livesText.text = "Lives: " + lives.ToString(); // display the text in the UI
        deathParticles = Instantiate(deathParticles, createPaddle.transform.position, Quaternion.identity); // instantiate death particles at the position of the pad
        deathParticles.SetActive(true);

        Destroy(createPaddle); // destory the pad
        Invoke("CreateNewPaddle", resetDelay); // create new pad
        IsGameOver();
    }

    void CreateNewPaddle() {
        createPaddle = (GameObject)Instantiate(paddlePrefab, transform.position, Quaternion.identity);
    }

    public void DestroyBrick() {
        audioSource.PlayOneShot(hitSound);
        bricks = bricks - 1; // First you need to substract the bircks
        bricksText.text = "Bricsk left: " + bricks.ToString(); // then to display them.
        NoMoreBricks();
    }

    void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
        Time.timeScale = 1f;
    }

    private void Update() {
            if (Input.GetKeyDown(KeyCode.P)) {
            bricks = 1;
        }
    }
}

  
