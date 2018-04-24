using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "BlazeCall", menuName = "Misc/ConditionCalls/Blaze", order = 45)]
public class BlazeCall : ConditionCall {

	public override ConditionReturn MethodCall (UnitConditionManager uCM)
	{
		return uCM.ReadBlaze ();
	}

}
