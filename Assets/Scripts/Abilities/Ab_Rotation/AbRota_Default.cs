using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Default", menuName = "Abilities/Rotations/Default", order = 37)]
public class AbRota_Default : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		ev.rotation = Quaternion.identity;
	}

}
