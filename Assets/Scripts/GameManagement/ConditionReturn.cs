using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionReturn
{
	public string condKey;
	public bool toRemove;

	public ConditionReturn (string addKey, bool addRemove)
	{
		condKey = addKey;
		toRemove = addRemove;
	}
}
