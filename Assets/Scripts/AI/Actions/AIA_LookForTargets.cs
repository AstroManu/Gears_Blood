using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookForTargets", menuName = "AI State/Actions/Look for Targets", order = 41)]
public class AIA_LookForTargets : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.AcquireTarget (unit.transform.position, unit.preset.aggroRange, unit.preset.faction.aggro);
	}

}
