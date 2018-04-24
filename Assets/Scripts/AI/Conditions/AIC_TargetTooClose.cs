using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TargetTooClose", menuName = "AI State/Conditions/Target too close", order = 41)]
public class AIC_TargetTooClose : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return unit.preset.ability[unit.stateC.activeAbility].minRange > unit.stateC.distanceToTarget;
	}

}
