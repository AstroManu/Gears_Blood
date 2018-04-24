using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "UpdateTargetDistance", menuName = "AI State/Actions/Update target distance", order = 41)]
public class AIA_UpdateTargetDist : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		if (unit.stateC.currentTarget == null)
		{
			return;
		}
		unit.stateC.distanceToTarget = unit.stateC.CalculateDistToUnit (unit.stateC.currentTarget);
	}

}
