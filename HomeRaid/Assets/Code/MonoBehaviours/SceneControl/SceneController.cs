using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public event Action BeforeSceneLoad;

	public event Action AfterSceneLoad;

	private string[] _sceneList;

	private int _currentSceneIndex = 0;

	// Start is called before the first frame update
	private IEnumerator Start()
	{
		// Create static list of scenes
		_sceneList = new string[]
		{
			"Level1",
			"GameOver"
		};

		yield return StartCoroutine(LoadSceneAndSetActive(_sceneList[_currentSceneIndex]));
	}

	private IEnumerator LoadSceneAndSetActive(string sceneName)
	{
		yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
		SceneManager.SetActiveScene(newlyLoadedScene);
	}

	public IEnumerable ProgressScene()
	{
		yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

		_currentSceneIndex += 1;
		yield return StartCoroutine(LoadSceneAndSetActive(_sceneList[_currentSceneIndex]));
	}

	// Update is called once per frame
	private void Update()
	{
	}
}