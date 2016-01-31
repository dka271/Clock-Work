using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player") {
            if (Application.loadedLevel + 1 != Application.levelCount)
                Application.LoadLevel(Application.loadedLevel + 1);
            else
                Application.LoadLevel(0);
        }
    }
}
