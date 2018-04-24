using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InitializeNextState", menuName = "AI State/Actions/Initialize NextState", order = 41)]
public class AIA_InitializeNextState : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.nextState.InitializeState (unit);
		unit.stateC.nextState = null;
	}
}
