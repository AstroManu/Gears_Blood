using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectSearch : ScriptableObject {

	public abstract List<GameUnit> SearchUnits (LayerMask canAcquire, EventCaster ev);

}
