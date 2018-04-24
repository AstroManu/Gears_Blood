using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect : ScriptableObject {

	public abstract void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster);

}
