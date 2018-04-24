using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIAbilityConditions
{
	[Tooltip ("Time in combat before AI can use the ability. Last ability is the default attack and should always have a timer of 0")] public float timer;
	[Tooltip ("Timer will advance only if a target is within the radius")] public float activeRadius = 10f;
	[Tooltip ("Timer will not advance if unit has less health %")] [Range (0,1)] public float minHealth = 0f;
	[Tooltip ("Timer will not advance if unit has more health %")] [Range (0,1)] public float maxHealth = 1f;
}
