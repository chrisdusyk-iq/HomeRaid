using UnityEngine;

public class ReactionCollection : MonoBehaviour
{
	public Reaction[] reactions = new Reaction[0];

	private void Start()
	{
		foreach (var reaction in reactions)
		{
			reaction.Init();
		}
	}

	public void React()
	{
		foreach (var reaction in reactions)
		{
			reaction.React(this);
		}
	}
}