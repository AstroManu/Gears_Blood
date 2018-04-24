using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ConditionBlaze_Template", menuName = "Abilities/Effects/C Blaze", order = 37)]
public class AbE_ConditionBlaze : AbilityEffect {

	[Tooltip("Duration of blaze in second. Won't stack with current blaze on target, but will reset duration")] public float blazeDuration = 1f;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		foreach (GameUnit hit in eventCaster.acquiredUnits)
		{
			hit.condM.InputBlaze (blazeDuration);
		}
	}

}
