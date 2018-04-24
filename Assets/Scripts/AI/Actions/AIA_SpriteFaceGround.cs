using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SpriteFaceGround", menuName = "AI State/Actions/Sprite face ground", order = 41)]
public class AIA_SpriteFaceGround : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.spriteC.faceDirection (unit.transform.position.x <= unit.controller.worldTarget.x);
	}
}
