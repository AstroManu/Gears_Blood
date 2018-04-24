using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ClearAgentPath", menuName = "AI State/Actions/Clear Agent Path", order = 41)]
public class AIA_ClearAgentPath : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.ResetPath ();;
	}
}
