using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookFromTarget", menuName = "Abilities/Rotations/LookFrom Target", order = 37)]
public class AbRota_LookFromTarget : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		Vector3 inversePosition = (ev.position - target) + ev.position;
		ev.LookAt (inversePosition, Vector3.up);
	}

}
