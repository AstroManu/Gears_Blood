using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AttackReady", menuName = "AI State/Conditions/Attack Ready", order = 41)]
public class AIC_AttackReady : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return Time.time >= unit.stateC.nextAttack;
	}

}
