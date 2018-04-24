using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SpriteFaceTarget", menuName = "AI State/Actions/Sprite face target", order = 41)]
public class AIA_SpriteFaceTarget : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		if (unit.stateC.currentTarget == null)
		{
			return;
		}
		unit.spriteC.faceDirection (unit.transform.position.x <= unit.stateC.currentTarget.transform.position.x);
	}
}
