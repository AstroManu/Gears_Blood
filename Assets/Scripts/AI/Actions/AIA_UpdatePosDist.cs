using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "UpdatePositionDistance", menuName = "AI State/Actions/Update position distance", order = 41)]
public class AIA_UpdatePosDist : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.distanceToTarget = unit.stateC.CalculateDistToGround (unit.controller.worldTarget);
	}

}
