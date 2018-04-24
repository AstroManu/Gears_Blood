using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveEventLocal_Template", menuName = "Abilities/Effects/MoveEvent local", order = 37)]
public class AbE_MoveEventLocal : AbilityEffect {

	public Vector3 localTranslate;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		eventCaster.transform.Translate (localTranslate, Space.Self);
	}

}
