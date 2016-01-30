using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float walkingSpeed;
    public float walkingAccel;
    public float jumpSpeed;
    public float glideFallSpeed;
    private float raycastDistance;
    private bool isGrounded;
    private float horizontalVelocity;
    private new Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        raycastDistance = 1.5f * this.GetComponent<Collider2D>().bounds.extents.y;
	}
	
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, -1 ^ (1 << 9));
        if (isGrounded) {
            if (Input.GetButtonDown("Vertical"))
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        } else {
            if (Input.GetButton("Vertical"))
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Clamp(rigidbody2D.velocity.y, glideFallSpeed, float.MaxValue));
        }
        horizontalVelocity = horiz * walkingSpeed;
	}

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(
            Mathf.MoveTowards(rigidbody2D.velocity.x, horizontalVelocity, 
                (rigidbody2D.velocity.x * horizontalVelocity > 0 ? 1 : 5) * walkingAccel * Time.fixedDeltaTime),
            rigidbody2D.velocity.y);
    }
}
