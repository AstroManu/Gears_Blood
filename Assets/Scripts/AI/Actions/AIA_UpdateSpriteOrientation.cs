using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "UpdateSpriteOrientation", menuName = "AI State/Actions/Update sprite orientation", order = 41)]
public class AIA_UpdateSpriteOrientation : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
	}
}
