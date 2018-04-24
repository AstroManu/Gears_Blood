using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookFromShotSpawn", menuName = "Abilities/Rotations/LookFrom ShotSpawn", order = 37)]
public class AbRota_LookFromShotSpwn : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		Vector3 inversePosition = (ev.position - caster.spriteC.shotSpawn.position) + ev.position;
		ev.LookAt (inversePosition, Vector3.up);
	}

}
