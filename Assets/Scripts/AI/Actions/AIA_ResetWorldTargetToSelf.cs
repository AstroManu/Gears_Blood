using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ResetWorldTargetToSelf", menuName = "AI State/Actions/Reset WorldTarget to self", order = 41)]
public class AIA_ResetWorldTargetToSelf : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.controller.worldTarget = unit.transform.position;
	}

}
