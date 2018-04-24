using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LerpBetweenCastAndTarget", menuName = "Abilities/Positions/Lerp between Cast and Target", order = 37)]
public class AbPos_LerpBetweenCastAndTarget : AbilityPosition {

	public float lerpValue = 0.5f;

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		return Vector3.LerpUnclamped (caster.transform.position, target, lerpValue) + offset;
	}

}
