using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InstantiateHitFx_Template", menuName = "Abilities/Effects/Hit Fx Instantiate", order = 37)]
public class AbE_InstantiateHitFx : AbilityEffect {

	public GameObject prefab;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		foreach (GameUnit hit in eventCaster.acquiredUnits)
		{
			Instantiate (prefab, hit.HitFxPosition (), Quaternion.identity);
		}
	}

}
