using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveBackTarget_Attack", menuName = "AI State/Actions/MoveBack Target Attack", order = 41)]
public class AIA_MoveBackTarget : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.SetDestination (unit.stateC.MoveBackPosition(unit.stateC.currentTarget.transform.position, unit.preset.ability[unit.stateC.activeAbility].minRange, unit.stateC.distanceToTarget));
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
	}
}
