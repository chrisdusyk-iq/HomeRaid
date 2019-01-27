using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SceneReaction : Reaction
{
	public string sceneName;

	private SceneController _sceneController;

	protected override void SpecificInit() => _sceneController = FindObjectOfType<SceneController>();

	protected override void ImmediateReaction() => _sceneController.ProgressScene();
}
