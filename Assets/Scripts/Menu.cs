using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void QuitConfirm() {
        Application.Quit();
    }

    public void Play() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
