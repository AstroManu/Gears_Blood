using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NoFilter", menuName = "Abilities/Effects/SearchFilters/No filter", order = 37)]
public class ESF_NoFilter : EffectSearchFilter {

	public override List<GameUnit> SearchFilter (List<GameUnit> targets, GameUnit caster, Vector3 target, EventCaster eventCaster)
	{
		return targets;
	}

}
