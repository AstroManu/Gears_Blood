using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ClearTarget", menuName = "AI State/Actions/Clear Target", order = 41)]
public class AIA_ClearTarget : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.currentTarget = null;
	}

}
