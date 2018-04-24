using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitAbility
{
	[Tooltip ("Ability")] public Ability ability;
	[Tooltip ("Minimum distance for the AI to cast the ability")] public float minRange = 0f;
	[Tooltip ("Maximum distance for the AI to cast the ability")] public float maxRange = 10f;
	[Tooltip ("Duration in seconds before ability can be casted again. Should be at least 0.1 longer than the Cast Lock Duration")] public float coolDownDuration = 5f;
	[Tooltip ("Duration in seconds that the unit is locked in its casting AI_State. Must be equal to the duration of the animation")] public float castLockDuration = 1f;
	[Tooltip ("AI with EUControler only. Timer and condition for ability usage. Unit will always choose the first available ability")] public AIAbilityConditions abilityUseCondition;
	[Tooltip ("Animation that will be used by the animator. At least 1 value must be set. If multiple values are set, one will be selected at random with each cast")]
	[Range (1,6)] public int[] castAnimIndex;
}
