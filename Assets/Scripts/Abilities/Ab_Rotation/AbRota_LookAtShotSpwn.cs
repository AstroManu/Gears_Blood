using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LookAtShotSpawn", menuName = "Abilities/Rotations/LookAt ShotSpawn", order = 37)]
public class AbRota_LookAtShotSpwn : AbilityRotation {

	public override void eventRotation (GameUnit caster, Vector3 target, Transform ev)
	{
		ev.LookAt (caster.spriteC.shotSpawn.position);
	}

}
