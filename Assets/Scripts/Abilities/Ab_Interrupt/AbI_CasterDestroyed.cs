using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CasterIsDestroyed", menuName = "Abilities/Interrupts/Caster Destroyed", order = 37)]
public class AbI_CasterDestroyed : AbilityInterrupt {

	public override bool Condition (GameUnit caster)
	{
		return caster == null;
	}

}
