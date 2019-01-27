using UnityEngine;

public class RotateInPlace : MonoBehaviour
{
	public float RotationSpeed = 10f;

	// Update is called once per frame
	public void Update()
		=> transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
}
