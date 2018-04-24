using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SlowCall", menuName = "Misc/ConditionCalls/Slow", order = 45)]
public class SlowCall : ConditionCall {

	public override ConditionReturn MethodCall (UnitConditionManager uCM)
	{
		return uCM.ReadSlow ();
	}

}
