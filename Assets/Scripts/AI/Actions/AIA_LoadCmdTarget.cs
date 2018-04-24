using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LoadCmdTarget", menuName = "AI State/Actions/Load Cmd Target", order = 41)]
public class AIA_LoadCmdTarget : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		if (unit.stateC.cmdTarget != null)
		{
			unit.stateC.currentTarget = unit.stateC.cmdTarget;
			return;
		}
		unit.stateC.currentTarget = null;
	}

}
