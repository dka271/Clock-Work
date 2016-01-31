using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class KillOnContact : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.SendMessage("Kill");
    }
}
