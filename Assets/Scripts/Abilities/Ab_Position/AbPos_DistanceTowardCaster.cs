using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DistanceTowardCaster_Template", menuName = "Abilities/Positions/Distance toward caster", order = 37)]
public class AbPos_DistanceTowardCaster : AbilityPosition {

	public float distance = 1f;

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		Vector3 v = caster.transform.position - target;
		return target + offset + v.normalized * distance;
	}

}
