using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GetCaster", menuName = "Abilities/Effects/SearchPatterns/Get caster", order = 37)]
public class ESP_GetCaster : EffectSearch {

	public override List<GameUnit> SearchUnits (LayerMask canAcquire, EventCaster ev)
	{
		List<GameUnit> casterList = new List<GameUnit>();
		casterList.Add (ev.caster);
		return casterList;
	}

}
