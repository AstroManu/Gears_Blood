using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookAtTarget", menuName = "Abilities/Rotations/LookAt Target", order = 37)]
public class AbRota_LookAtTarget : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		ev.LookAt (target);
	}

}
