using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CastAttack", menuName = "AI State/Actions/Cast Attack", order = 41)]
public class AIA_CastAttack : AI_Action {

	public int castAvoidancePriority = 30;

	public override void DoAction (GameUnit unit, AI_State state)
	{
//		if (unit.stateC.currentTarget == null)
//		{
//			return;
//		}

		unit.agent.avoidancePriority = castAvoidancePriority;
		unit.stateC.nextAttack = Time.time + unit.preset.ability[unit.stateC.activeAbility].coolDownDuration;
		unit.stateC.castLockTime = Time.time + unit.preset.ability[unit.stateC.activeAbility].castLockDuration;

		unit.preset.ability[unit.stateC.activeAbility].ability.Cast (unit, unit.stateC.currentTarget.transform.position);

	}

}
