using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SlowUpdatePath", menuName = "AI State/Actions/Slow Update Path", order = 41)]
public class AIA_SlowUpdatePath : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		if (unit.stateC.SlowUpdate ())
		{
			unit.agent.SetDestination (unit.agent.destination);
		}
	}

}
