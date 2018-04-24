using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CastTarget", menuName = "AI State/Actions/Cast Target", order = 41)]
public class AIA_CastTarget : AI_Action {

	public int castAvoidancePriority = 30;

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.avoidancePriority = castAvoidancePriority;
		unit.stateC.nextAbility = Time.time + unit.preset.ability[unit.stateC.activeAbility].coolDownDuration;
		unit.stateC.castLockTime = Time.time + unit.preset.ability[unit.stateC.activeAbility].castLockDuration;

		unit.preset.ability[unit.stateC.activeAbility].ability.Cast (unit, unit.stateC.currentTarget.transform.position);

	}

}
