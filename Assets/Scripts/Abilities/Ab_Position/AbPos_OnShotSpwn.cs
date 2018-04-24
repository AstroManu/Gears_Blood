using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OnShotSpawn", menuName = "Abilities/Positions/On ShotSpawn", order = 37)]
public class AbPos_OnShotSpwn : AbilityPosition {

	public override Vector3 eventPos (GameUnit caster, Vector3 target)
	{
		return caster.transform.position + offset;
	}

}
