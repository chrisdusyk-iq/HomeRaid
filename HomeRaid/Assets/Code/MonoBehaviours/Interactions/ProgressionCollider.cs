using UnityEngine;
using System.Collections;

public class ProgressionCollider : MonoBehaviour
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
