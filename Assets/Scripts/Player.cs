using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float walkingSpeed;
    public float walkingAccel;
    public float jumpSpeed;
    public float maxFallSpeed;
    public float glideFallSpeed;
    public float raycastDistance;
    public float slowFactor;
    private Vector2 boxSide;
    private bool isGrounded;
    private bool isDead;
    private uint slowed;
    private float horizontalVelocity;
    private new Rigidbody2D rigidbody2D;
    private Animator anim;

    private const int raycastMask = -1 ^ ((1 << 9) | (1 << 11));

    private static int animIdJump, animIdWalking, animIdGrounded, animIdKilled, animIdGliding;

	// Use this for initialization
	void Start () {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        boxSide = new Vector2(this.GetComponent<Collider2D>().bounds.extents.x, 0);
        anim = this.GetComponent<Animator>();
        animIdJump = Animator.StringToHash("Jump");
        animIdWalking = Animator.StringToHash("Walking");
        animIdGrounded = Animator.StringToHash("Grounded");
        animIdKilled = Animator.StringToHash("Killed");
        animIdGliding = Animator.StringToHash("Gliding");
	}
	
    //Called Every Frame
	void Update () {
        if (Input.GetButtonDown("Respawn")) { //Kills player
            isDead = !isDead;
            if (isDead) {
                Kill();
            } else {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (isDead) //Don't handle actions if dead
            return;
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = 
            Physics2D.Raycast((Vector2)transform.position + boxSide, Vector2.down, raycastDistance, raycastMask) || 
            Physics2D.Raycast((Vector2)transform.position - boxSide, Vector2.down, raycastDistance, raycastMask);
        anim.SetBool(animIdGrounded, isGrounded);
        if (isGrounded) {
            anim.SetBool(animIdGliding, false);
            if (Input.GetButtonDown("Vertical") && slowed == 0) {
                rigidbody2D.velocity += new Vector2(0, jumpSpeed);
                anim.SetTrigger(animIdJump);
            }
        } else {
            if (Input.GetButton("Vertical")) {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Clamp(rigidbody2D.velocity.y, glideFallSpeed, float.MaxValue));
                anim.SetBool(animIdGliding, rigidbody2D.velocity.y < 0);
            } else {
                anim.SetBool(animIdGliding, false);
            }
        }
        if (transform.localScale.x * horiz < 0) { //Invert Direction if Needed
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        horizontalVelocity = horiz * walkingSpeed * (slowed != 0 ? slowFactor : 1);
        anim.SetBool(animIdWalking, horizontalVelocity != 0 && isGrounded);
	}

    //Called Every Physics Step
    void FixedUpdate() {
        //Accelerate/Decelerate toward intended velocity
        rigidbody2D.velocity = new Vector2(
            Mathf.MoveTowards(rigidbody2D.velocity.x, horizontalVelocity, 
                (rigidbody2D.velocity.x * horizontalVelocity > 0 ? 1 : 5) * walkingAccel * (slowed != 0 ? slowFactor : 1) * Time.fixedDeltaTime),
            Mathf.Clamp(rigidbody2D.velocity.y, maxFallSpeed * (slowed != 0 ? slowFactor : 1), (slowed != 0 ? slowFactor * -maxFallSpeed: float.MaxValue)));
    }

    void Kill() {
        isDead = true;
        horizontalVelocity = 0;
        anim.SetTrigger(animIdKilled);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 11) {
            ++slowed;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.layer == 11) {
            --slowed;
        }
    }
}
