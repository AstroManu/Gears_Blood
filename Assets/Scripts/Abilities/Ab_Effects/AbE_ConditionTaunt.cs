using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ConditionTaunt_Template", menuName = "Abilities/Effects/C Taunt", order = 37)]
public class AbE_ConditionTaunt : AbilityEffect {

	[Tooltip("Duration of taunt in second. New taunt will completly override previous taunt effects.")] public float tauntDuration = 1f;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		foreach (GameUnit hit in eventCaster.acquiredUnits)
		{
			hit.condM.InputTaunt (tauntDuration, caster);
		}
	}

}
