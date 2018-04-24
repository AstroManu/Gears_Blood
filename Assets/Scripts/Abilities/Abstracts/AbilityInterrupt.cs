using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityInterrupt : ScriptableObject {

	public abstract bool Condition (GameUnit caster);

}
