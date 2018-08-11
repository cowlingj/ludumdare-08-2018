using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool canJump;
  public float groundSpeed;
	public float airSpeed;
	public float jumpThreshold;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void moveX(float val) {
		float speed = Physics.Raycast(transform.position, -Vector3.up, jumpThreshold)? groundSpeed : airSpeed;
    rb.AddForce(new Vector3(val * speed, 0, 0));
	}

	void moveY(float val) {
		if (!canJump) {
			return;
		}
		float speed = Physics.Raycast(transform.position, -Vector3.up, jumpThreshold)? groundSpeed : airSpeed;
		rb.AddForce(new Vector3(0, val * speed, 0));
	}
}
