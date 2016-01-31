using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {
    public float time;
    public string message;
    public GameObject listener;
    private bool active;
    private Text text;

    void Start() {
        text = this.GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        text.text = string.Format(message, time);
        if (time <= 0 && active) {
            listener.SendMessage("OnTimeElapsed", this);
            active = false;
        }
	}
}
