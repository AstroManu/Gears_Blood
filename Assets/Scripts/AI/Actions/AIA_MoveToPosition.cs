using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveToPosition", menuName = "AI State/Actions/MoveTo Position", order = 41)]
public class AIA_MoveToPosition : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.SetDestination (unit.controller.worldTarget);
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
	}
}
