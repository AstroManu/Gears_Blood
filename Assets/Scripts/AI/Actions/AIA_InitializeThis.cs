using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InitializeThis", menuName = "AI State/Actions/Initialize This", order = 41)]
public class AIA_InitializeThis : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.currentState = state;
	}

}
