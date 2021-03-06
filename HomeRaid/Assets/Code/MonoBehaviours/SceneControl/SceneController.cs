﻿using System;
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
			"Level2",
			"GameOver"
		};

		yield return StartCoroutine(LoadSceneAndSetActive(null, _sceneList[_currentSceneIndex]));
	}

	private IEnumerator LoadSceneAndSetActive(string previousSceneName, string currentSceneName)
	{
		if (previousSceneName != null)
			yield return SceneManager.UnloadSceneAsync(previousSceneName);

		yield return SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Additive);
		Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
		yield return SceneManager.SetActiveScene(newlyLoadedScene);
	}

	public void ProgressScene()
	{
		StartCoroutine(LoadSceneAndSetActive(_sceneList[_currentSceneIndex], _sceneList[_currentSceneIndex + 1]));
		_currentSceneIndex += 1;
	}

	// Update is called once per frame
	private void Update()
	{
	}
}