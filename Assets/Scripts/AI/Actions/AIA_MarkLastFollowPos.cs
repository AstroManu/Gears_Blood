using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MarkLastFollowPos", menuName = "AI State/Actions/Mark LastFollowPos", order = 41)]
public class AIA_MarkLastFollowPos : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.followPosMemory = unit.stateC.followPosition.position;
	}
}
