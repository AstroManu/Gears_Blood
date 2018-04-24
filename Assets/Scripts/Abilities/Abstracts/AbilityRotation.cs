using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityRotation : ScriptableObject {

	public abstract void eventRotation (GameUnit caster, Vector3 target, Transform ev);

}
