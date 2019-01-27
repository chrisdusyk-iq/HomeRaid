﻿using UnityEngine;

public class AllConditions : ScriptableObject
{
	public Condition[] conditions;

	private static AllConditions instance;

	private const string loadPath = "AllConditions";

	public static AllConditions Instance
	{
		get
		{
			if (!instance)
			{
				instance = FindObjectOfType<AllConditions>();
			}

			if (!instance)
			{
				instance = Resources.Load<AllConditions>(loadPath);
			}

			if (!instance)
			{
				Debug.LogError("AllConditions has not been created yet.  Go to Assets > Create > AllConditions.");
			}

			return instance;
		}
		set { instance = value; }
	}

	public static bool CheckCondition(Condition requiredCondition)
	{
		Condition[] allConditions = Instance.conditions;
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