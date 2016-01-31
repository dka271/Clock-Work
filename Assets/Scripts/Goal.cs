using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player") {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
