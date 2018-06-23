using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour {

    private void OnTriggerEnter() {
        GameManager.instance.LoseLife(); // When ball enters the dead zone we will call the LoseLife function from the GameManager script
    }
}
