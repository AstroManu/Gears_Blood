using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ResetSlowUpdate", menuName = "AI State/Actions/Reset SlowUpdate", order = 41)]
public class AIA_ResetSlowUpdate : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.SlowUpdate ();
	}

}
