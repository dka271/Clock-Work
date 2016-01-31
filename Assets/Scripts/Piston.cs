using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Piston : MonoBehaviour {
    public bool inverted;
    private float height;
    private Vector3 parentStart;
    private Vector3 start;

    void Start() {
        height = this.GetComponent<Collider2D>().bounds.size.y;
        start = transform.position;
        parentStart = transform.parent.position;
    }
	// Update is called once per frame
	void Update () {
        Vector3 diff = (transform.parent.position - parentStart);
        transform.position = start + (diff / 2);
        transform.localScale = new Vector3(1, (inverted ? -1 : 1) + (diff.y/height), 1);
        //transform.parent.transform.Translate(moveSpeed * Time.deltaTime);
        //transform.Translate(-moveSpeed * Time.deltaTime / 2);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Time.deltaTime * moveSpeed.y/2, transform.localScale.z);
	}
}
