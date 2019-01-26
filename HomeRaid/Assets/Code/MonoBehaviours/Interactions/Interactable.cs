using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Transform InteractionLocation;
	public ConditionCollection[] ConditionCollections = new ConditionCollection[0];
	public ReactionCollection DefaultReactionCollection;

	public void Interact()
	{
		foreach (var conditionCollection in ConditionCollections)
		{
			if (conditionCollection.CheckAndReact())
				return;
		}

		DefaultReactionCollection.React();
	}
}
