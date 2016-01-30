using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float angularSpeed;

	// Update is called once per frame
	void Update () {
	    transform.Rotate(Vector3.forward, angularSpeed * Time.deltaTime);
	}
}
