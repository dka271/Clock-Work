using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DestroyOnEnter : MonoBehaviour {
	
	// Destroy on Enter
	void OnTriggerEnter2D (Collider2D collider) {
        Destroy(collider.gameObject);
	}
}
