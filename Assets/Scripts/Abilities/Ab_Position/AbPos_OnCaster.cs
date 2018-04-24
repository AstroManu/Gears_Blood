using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OnCaster", menuName = "Abilities/Positions/On caster", order = 37)]
public class AbPos_OnCaster : AbilityPosition {

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		return caster.transform.position + offset;
	}

}
