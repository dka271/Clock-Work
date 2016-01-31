using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {
    public float time;
    public string message;
    //public GameObject listener;
    private bool active;
    private Text text;
    private bool countUp = false;

    void Start() {
        text = this.GetComponent<Text>();
        active = true;
        if (time == 0)
            countUp = true; ;
    }

	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (countUp)
            text.text = string.Format(message, -time);
        else
            text.text = string.Format(message, time);
        if (!countUp && time <= 0 && active) {
            //listener.SendMessage("OnTimeElapsed");
            GameObject.Find("Player").SendMessage("Kill");
            active = false;
        }
	}
}
