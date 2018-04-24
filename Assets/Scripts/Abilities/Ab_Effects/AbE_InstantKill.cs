using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InstantKill", menuName = "Abilities/Effects/Instant kill", order = 37)]
public class AbE_InstantKill : AbilityEffect {

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		foreach (GameUnit hit in eventCaster.acquiredUnits)
		{
			if (hit != null)
			{
				hit.health.DestroyUnit();
			}
		}
	}

}
