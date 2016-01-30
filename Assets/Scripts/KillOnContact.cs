using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class KillOnContact : MonoBehaviour {
    private Collider2D collider;
	// Use this for initialization
	void Start () {
        collider = this.GetComponent<Collider2D>();
	}

    void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.SendMessage("Kill");
    }
}
