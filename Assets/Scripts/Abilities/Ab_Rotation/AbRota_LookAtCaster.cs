using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookAtCaster", menuName = "Abilities/Rotations/LookAt Caster", order = 37)]
public class AbRota_LookAtCaster : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		ev.LookAt (caster.transform);
	}

}
