using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ReportCast", menuName = "AI State/Actions/Report cast", order = 41)]
public class AIA_ReportCast : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.controller.ReportCast (unit.stateC.activeAbility);
	}

}
