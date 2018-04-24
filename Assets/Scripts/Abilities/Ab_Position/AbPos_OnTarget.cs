using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OnTarget", menuName = "Abilities/Positions/On Target", order = 37)]
public class AbPos_OnTarget : AbilityPosition {

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		return target + offset;
	}

}
