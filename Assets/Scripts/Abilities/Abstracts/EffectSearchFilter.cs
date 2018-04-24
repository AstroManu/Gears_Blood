using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectSearchFilter : ScriptableObject {

	public abstract List<GameUnit> SearchFilter (List<GameUnit> targets, GameUnit caster, Vector3 target, EventCaster eventCaster);

	public float GetMinusSqrDist (Vector3 pointA, Vector3 pointB)
	{
		Vector3 distVector = pointA - pointB;
		return 0f - (distVector.x * distVector.x + distVector.z * distVector.z);
	}

}
