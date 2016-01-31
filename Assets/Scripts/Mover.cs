using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float moveTime;
    public Vector2 moveSpeed;

	// Use this for initialization
	void Start () {
        StartCoroutine(timer());
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (Vector3)moveSpeed * Time.deltaTime;
        //transform.Translate(moveSpeed * Time.deltaTime);
    }

    IEnumerator timer()
    {
        while (true) { 
            yield return new WaitForSeconds(moveTime);
            moveSpeed *= -1;
        }
    }
}
