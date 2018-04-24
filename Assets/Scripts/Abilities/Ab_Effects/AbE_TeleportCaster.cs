using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TeleportCaster", menuName = "Abilities/Effects/Teleport caster", order = 37)]
public class AbE_TeleportCaster : AbilityEffect {

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		caster.agent.Warp (eventCaster.transform.position);
		caster.controller.worldTarget = eventCaster.transform.position;
	}

}
