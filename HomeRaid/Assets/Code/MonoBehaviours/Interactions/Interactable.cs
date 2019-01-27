using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Transform interactionLocation;
	public ConditionCollection[] conditionCollections = new ConditionCollection[0];
	public ReactionCollection defaultReactionCollection;

	public void Interact()
	{
		foreach (var conditionCollection in conditionCollections)
		{
			if (conditionCollection.CheckAndReact())
				return;
		}

		defaultReactionCollection.React();
	}
}
