using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveToFollow", menuName = "AI State/Actions/MoveTo Follow", order = 41)]
public class AIA_MoveToFollow : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.SetDestination (unit.stateC.followPosition.position);
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
	}
}
