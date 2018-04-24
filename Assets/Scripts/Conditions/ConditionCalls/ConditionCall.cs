using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionCall : ScriptableObject {

	public abstract ConditionReturn MethodCall (UnitConditionManager uCM);

}
