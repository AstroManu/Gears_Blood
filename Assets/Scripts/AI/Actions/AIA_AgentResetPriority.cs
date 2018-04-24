using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AgentResetPriority", menuName = "AI State/Actions/Agent reset priority", order = 41)]
public class AIA_AgentResetPriority : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.agent.avoidancePriority = unit.preset.agentPriority;
	}

}
