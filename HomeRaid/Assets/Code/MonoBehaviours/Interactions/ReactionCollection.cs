using UnityEngine;

public class ReactionCollection : MonoBehaviour
{
	public Reaction[] Reactions = new Reaction[0];

	private void Start()
	{
		foreach (var reaction in Reactions)
		{
			reaction.Init();
		}
	}

	public void React()
	{
		foreach (var reaction in Reactions)
		{
			reaction.React(this);
		}
	}
}