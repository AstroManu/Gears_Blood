using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AbilityReady", menuName = "AI State/Conditions/Ability Ready", order = 41)]
public class AIC_AbilityReady : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return Time.time > unit.stateC.nextAbility;
	}

}
