using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NoTarget", menuName = "AI State/Conditions/No target", order = 41)]
public class AIC_NoTarget : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return unit.stateC.currentTarget == null;
	}
}
