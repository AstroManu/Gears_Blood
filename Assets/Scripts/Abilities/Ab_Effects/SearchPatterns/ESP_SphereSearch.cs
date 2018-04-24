using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SphereSearch_Template", menuName = "Abilities/Effects/SearchPatterns/Sphere", order = 37)]
public class ESP_SphereSearch : EffectSearch {

	public float sphereRadius = 1f;
	public bool canHitCaster;

	public override List<GameUnit> SearchUnits (LayerMask canAcquire, EventCaster ev)
	{
		Collider[] col = Physics.OverlapSphere (ev.transform.position, sphereRadius, canAcquire);
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
