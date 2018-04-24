using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AnimAttack", menuName = "AI State/Actions/Anim Attack", order = 41)]
public class AIA_AnimAttack : AI_Action {

	public override void DoAction (GameUnit unit, AI_State state)
	{
		unit.spriteC.AnimCast (unit.preset.ability[unit.stateC.activeAbility].castAnimIndex);
	}

}
