using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TauntCall", menuName = "Misc/ConditionCalls/Taunt", order = 45)]
public class TauntCall : ConditionCall {

	public override ConditionReturn MethodCall (UnitConditionManager uCM)
	{
		return uCM.ReadTaunt ();
	}

}
