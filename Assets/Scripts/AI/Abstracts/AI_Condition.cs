using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI_Condition : ScriptableObject {

	public abstract bool Condition (GameUnit unit);

}
