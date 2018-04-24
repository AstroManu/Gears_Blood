using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookFromCaster", menuName = "Abilities/Rotations/LookFrom Caster", order = 37)]
public class AbRota_LookFromCaster : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		Vector3 inversePosition = (ev.position - caster.transform.position) + ev.position;
		ev.LookAt (inversePosition, Vector3.up);
	}

}
