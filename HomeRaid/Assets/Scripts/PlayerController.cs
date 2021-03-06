﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidBody;
	public float ForwardMovement = 600f;
	public float RotationSpeed = 10f;
	public float PushStrength = 10.0f;

	// Start is called before the first frame update
	public void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	public void Update()
	{
		ProcessForwardMotionInput();
		ProcessRotationInput();
	}

	private void ProcessForwardMotionInput()
	{
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			MoveAlongForwardAxis(ForwardMovement * Time.deltaTime);
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			MoveAlongForwardAxis(-ForwardMovement * Time.deltaTime);
	}

	private void MoveAlongForwardAxis(float forwardForceToAdd)
		=> _rigidBody.AddRelativeForce(0, 0, forwardForceToAdd);

	private void ProcessRotationInput()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			RotateForwardAxis(-RotationSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			RotateForwardAxis(RotationSpeed * Time.deltaTime);
	}

	private void RotateForwardAxis(float torqueToAdd)
		=> _rigidBody.AddRelativeTorque(0, torqueToAdd, 0);

	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
		var otherBody = hit.collider.attachedRigidbody;

		if (otherBody == null || otherBody.isKinematic)
		{
			return;
		}

		if (hit.moveDirection.y < -0.3f)
		{
			return;
		}

		var pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		otherBody.velocity = pushDir * PushStrength;
	}
}
