using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveBackPosition", menuName = "AI State/Actions/MoveBack position", order = 41)]
public class AIA_MoveBackPosition : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.SetDestination (unit.stateC.MoveBackPosition(unit.controller.worldTarget, unit.preset.ability[unit.stateC.activeAbility].minRange, unit.stateC.distanceToTarget));
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
	}
}
