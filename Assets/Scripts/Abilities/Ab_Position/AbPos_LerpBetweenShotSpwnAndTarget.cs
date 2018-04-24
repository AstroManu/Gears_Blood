using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LerpBetweenShotSpawnAndTarget", menuName = "Abilities/Positions/Lerp between ShotSpawn and Target", order = 37)]
public class AbPos_LerpBetweenShotSpwnAndTarget : AbilityPosition {

	public float lerpValue = 0.5f;

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		return Vector3.LerpUnclamped (caster.spriteC.shotSpawn.position, target, lerpValue) + offset;
	}

}
