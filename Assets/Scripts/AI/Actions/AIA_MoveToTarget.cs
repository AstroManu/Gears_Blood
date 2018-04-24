using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveToTarget", menuName = "AI State/Actions/MoveTo Target", order = 41)]
public class AIA_MoveToTarget : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		if (unit.stateC.currentTarget == null)
		{
			return;
		}
		unit.agent.SetDestination (unit.stateC.currentTarget.transform.position);
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
	}
}
