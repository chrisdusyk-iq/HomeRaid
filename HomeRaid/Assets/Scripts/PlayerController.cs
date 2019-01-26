using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	public float ForwardMovement = 25f;
	public float RotationSpeed = 4f;

	// Start is called before the first frame update
	public void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	public void Update()
	{
		ProcessForwardMotionInput();
		ProcessRotationInput();
	}

	private void ProcessForwardMotionInput()
	{
		var isMovingAlongForwardAxis = false;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			isMovingAlongForwardAxis = true;
			MoveAlongForwardAxis(ForwardMovement * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			isMovingAlongForwardAxis = true;
			MoveAlongForwardAxis(-ForwardMovement * Time.deltaTime);
		}

		if (!isMovingAlongForwardAxis)
			StopMoving();
	}

	private void MoveAlongForwardAxis(float forwardForceToAdd)
		=> _rigidbody.AddRelativeForce(0, forwardForceToAdd, 0);

	private void StopMoving()
		=> _rigidbody.velocity = Vector3.zero;

	private void ProcessRotationInput()
	{
		var isRotating = false;

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			isRotating = true;
			RotateForwardAxis(RotationSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			isRotating = true;
			RotateForwardAxis(-RotationSpeed * Time.deltaTime);
		}

		if (!isRotating)
			StopRotating();
	}

	private void RotateForwardAxis(float torqueToAdd)
	{
		_rigidbody.freezeRotation = false;
		_rigidbody.AddRelativeTorque(0, 0, torqueToAdd);
	}

	private void StopRotating()
		=> _rigidbody.freezeRotation = true;
}
