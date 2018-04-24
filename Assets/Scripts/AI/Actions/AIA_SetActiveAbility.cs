using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SetActiveAbility1", menuName = "AI State/Actions/Set active ability", order = 41)]
public class AIA_SetActiveAbility : AI_Action {

	public int abilityIndex = 1;

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.stateC.activeAbility = abilityIndex;
	}

}
