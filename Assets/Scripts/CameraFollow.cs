using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour {
    public GameObject player;
    public float distance;
    public float minSpeed;
    public float pullSpeed;
	
	// Update is called once per frame
	void Update () {
        Vector3 dest = player.transform.position + Vector3.back * distance;
        transform.position = Vector3.MoveTowards(transform.position, dest, 
            (minSpeed + pullSpeed * (dest - transform.position).sqrMagnitude) * Time.deltaTime);
	}
}
