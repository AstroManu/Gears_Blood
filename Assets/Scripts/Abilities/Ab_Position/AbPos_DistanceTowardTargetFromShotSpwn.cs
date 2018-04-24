using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DistanceTowardTargetFromShotSpawn_Template", menuName = "Abilities/Positions/Distance toward target from ShotSpawn", order = 37)]
public class AbPos_DistanceTowardTargetFromShotSpwn : AbilityPosition {

	public float distance = 1f;

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		Vector3 v = target - caster.spriteC.shotSpawn.position;
		return caster.spriteC.shotSpawn.position + offset + v.normalized * distance;
	}

}
