using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DestinationReached", menuName = "AI State/Conditions/Destination Reached", order = 41)]
public class AIC_DestinationReached : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return unit.agent.remainingDistance <= unit.agent.stoppingDistance && !unit.agent.pathPending;
	}

}
