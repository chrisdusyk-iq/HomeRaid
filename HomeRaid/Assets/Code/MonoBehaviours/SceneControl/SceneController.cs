using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	private IEnumerable<string> _sceneList = Enumerable.Empty<string>();

	// Start is called before the first frame update
	private void Start()
	{
		// Create static list of scenes
		_sceneList = new List<string>
		{
			"Scene1"
		};
	}

	// Update is called once per frame
	private void Update()
	{
	}
}