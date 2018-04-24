using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "InstantiateUnbound_Template", menuName = "Abilities/Effects/Instantiate Unbound", order = 37)]
public class AbE_InstantiateUnbound : AbilityEffect {

	public GameObject prefab;
	public Vector3 offset;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		Instantiate (prefab, eventCaster.transform.position + offset, eventCaster.transform.rotation);
	}

}
