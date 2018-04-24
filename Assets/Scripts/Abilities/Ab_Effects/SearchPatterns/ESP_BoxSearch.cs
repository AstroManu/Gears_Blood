using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "BoxSearch_Template", menuName = "Abilities/Effects/SearchPatterns/Box", order = 37)]
public class ESP_BoxSearch : EffectSearch {

	[Header("Modify only x and z")]
	public Vector3 boxRadius = new Vector3 (1f, 5f, 1f);
	public bool canHitCaster;

	public override List<GameUnit> SearchUnits (LayerMask canAcquire, EventCaster ev)
	{
		Collider[] col = Physics.OverlapBox (ev.transform.position, boxRadius, ev.transform.rotation, canAcquire);
		List<GameUnit> unitList = new List<GameUnit>();
		foreach (Collider hit in col)
		{
			GameUnit hitUnit = hit.GetComponent<GameUnit> ();

			if (hitUnit != ev.caster || canHitCaster)
			{
				unitList.Add (hitUnit);
			}
		}
		return unitList;
	}

}
