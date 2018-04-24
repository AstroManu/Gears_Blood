using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TargetTooFar", menuName = "AI State/Conditions/Target too far", order = 41)]
public class AIC_TargetTooFar : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return unit.preset.ability[unit.stateC.activeAbility].maxRange < unit.stateC.distanceToTarget;
	}

}
