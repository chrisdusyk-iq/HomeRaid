using UnityEngine;

public class AllConditions : ScriptableObject
{
	public Condition[] Conditions;

	private static AllConditions _instance;

	private const string _loadPath = "AllConditions";

	public static AllConditions Instance
	{
		get
		{
			if (!_instance)
			{
				_instance = FindObjectOfType<AllConditions>();
			}

			if (!_instance)
			{
				_instance = Resources.Load<AllConditions>(_loadPath);
			}

			if (!_instance)
			{
				Debug.LogError("AllConditions has not been created yet.  Go to Assets > Create > AllConditions.");
			}

			return _instance;
		}
		set { _instance = value; }
	}

	public static bool CheckCondition(Condition requiredCondition)
	{
		Condition[] allConditions = Instance.Conditions;
		Condition globalCondition = null;

		if (allConditions != null && allConditions[0] != null)
		{
			for (int i = 0; i < allConditions.Length; i++)
			{
				if (allConditions[i].hash == requiredCondition.hash)
				{
					globalCondition = allConditions[i];
				}
			}
		}

		if (!globalCondition)
		{
			return false;
		}

		return globalCondition.satisfied == requiredCondition.satisfied;
	}
}