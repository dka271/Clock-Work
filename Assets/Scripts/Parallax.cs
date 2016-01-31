using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
    public GameObject fg;
    public float ratio;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(fg.transform.position.x * ratio, fg.transform.position.y * ratio, transform.position.z);
	}
}
