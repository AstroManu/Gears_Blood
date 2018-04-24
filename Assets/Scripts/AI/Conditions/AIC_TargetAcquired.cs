using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TargetAcquired", menuName = "AI State/Conditions/Target Acquired", order = 41)]
public class AIC_TargetAcquired : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return unit.stateC.currentTarget != null;
	}
}
