using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LockedInCast", menuName = "AI State/Conditions/Locked in cast", order = 41)]
public class AIC_LockedInCast : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return Time.time < unit.stateC.castLockTime;
	}

}
