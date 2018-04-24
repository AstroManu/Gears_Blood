using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MoveEventWorld_Template", menuName = "Abilities/Effects/MoveEvent world", order = 37)]
public class AbE_MoveEventWorld : AbilityEffect {

	public Vector3 worldTranslate;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		eventCaster.transform.Translate (worldTranslate, Space.Self);
	}

}
