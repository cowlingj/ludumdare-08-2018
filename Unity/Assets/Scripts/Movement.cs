using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool canFly = false;
	public float onGroundThreshold = 0.05f;

  public float groundSpeed = 1f;
	public float airSpeed = 1f;

	public float groundJumpForce = 1f;
	public float airJumpForce = 1f;
	public float maxJumpThrustTime = 0.01f;

  private Rigidbody rb;

  void Start() {
		rb = GetComponent<Rigidbody>();
	}

	protected void move(float x, float y) {
		float speed = Physics.Raycast(transform.position, -Vector3.up, onGroundThreshold)? groundSpeed : airSpeed;
    
		float correctedX = x * speed * Time.deltaTime;
		float correctedY = canFly? y * speed * Time.deltaTime : 0;

		//rb.AddForce(new Vector3(correctedX, correctedY, 0));
		transform.Translate(new Vector3(correctedX, correctedY, 0), relativeTo:Space.World);
	}

	protected void jump(Func<bool> cont, Action done) {
		StartCoroutine(_jump(cont, done));
	}

	private IEnumerator _jump(Func<bool> cont, Action done) {

		float timer = 0f;

		while (cont() && timer < maxJumpThrustTime) {
			float jumpForce = Physics.Raycast(transform.position, -Vector3.up, onGroundThreshold)? groundJumpForce : airJumpForce;
			float jumpProgress = timer / maxJumpThrustTime;
			rb.AddForce(new Vector3(0, (1 - Mathf.Pow(jumpProgress, 1)) * jumpForce, 0));
			timer += Time.deltaTime;
		  yield return null;
		}
		done();
	}

	protected void land(Action done) {
		StartCoroutine(_land(done));
	}

	private IEnumerator _land(Action done) {
		while (!Physics.Raycast(transform.position, -Vector3.up, onGroundThreshold)) {
			yield return null;
		}
		done();
	}


}
