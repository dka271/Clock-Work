using UnityEngine;
using System.Collections;

public class Piston : Mover {
	// Update is called once per frame
	void Update () {
        transform.parent.transform.Translate(moveSpeed * Time.deltaTime);
        transform.Translate(-moveSpeed * Time.deltaTime / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Time.deltaTime * moveSpeed.y/2, transform.localScale.z);
	}
}
