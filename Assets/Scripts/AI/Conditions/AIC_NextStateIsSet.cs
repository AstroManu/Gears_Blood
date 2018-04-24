using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NextStateIsSet", menuName = "AI State/Conditions/NextState is set", order = 41)]
public class AIC_NextStateIsSet : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return unit.stateC.nextState != null;
	}

}
