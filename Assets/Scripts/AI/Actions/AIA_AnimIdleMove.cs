using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AnimIdleMove", menuName = "AI State/Actions/Anim IdleMove", order = 41)]
public class AIA_AnimIdleMove : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.spriteC.AnimIdleMove ();
	}

}
