using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SlowLookForTargets", menuName = "AI State/Actions/Slow Look for Targets", order = 41)]
public class AIA_SlowLookForTargets : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		if (unit.stateC.SlowUpdate ())
		{
			unit.stateC.AcquireTarget (unit.transform.position, unit.preset.aggroRange, unit.preset.faction.aggro);
		}
	}

}
