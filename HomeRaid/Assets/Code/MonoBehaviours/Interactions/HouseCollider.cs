using UnityEngine;
using System.Collections;

public class HouseCollider : MonoBehaviour
{
	private SceneController sceneController;

	void Start()
	{
		sceneController = FindObjectOfType<SceneController>();

	}

	private void OnCollisionEnter(Collision collision)
	{
		sceneController.ProgressScene();
	}
}
