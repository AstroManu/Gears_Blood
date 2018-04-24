using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DistanceTowardTarget_Template", menuName = "Abilities/Positions/Distance toward target", order = 37)]
public class AbPos_DistanceTowardTarget : AbilityPosition {

	public float distance = 1f;

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		Vector3 v = target - caster.transform.position;
		return caster.transform.position + offset + v.normalized * distance;
	}

}
