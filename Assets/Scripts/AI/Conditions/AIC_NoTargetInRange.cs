using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NoTargetInRange", menuName = "AI State/Conditions/No target in range", order = 41)]
public class AIC_NoTargetInRange: AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return (unit.preset.ability[unit.stateC.activeAbility].minRange > unit.stateC.distanceToTarget || unit.preset.ability[unit.stateC.activeAbility].maxRange < unit.stateC.distanceToTarget) || unit.stateC.currentTarget == null;
	}

}
