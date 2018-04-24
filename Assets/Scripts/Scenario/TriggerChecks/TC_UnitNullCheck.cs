using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_UnitNullCheck : TriggerCheck {

	public GameUnit[] unitChecklist;

	public override bool DoCheck ()
	{
		foreach (GameUnit unit in unitChecklist)
		{
			if (unit != null)
			{
				return false;
			}
		}
		return true;
	}

}
