using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "JustDoIt", menuName = "AI State/Conditions/No Condition", order = 41)]
public class AIC_JustDoIt : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		return true;
	}

}
