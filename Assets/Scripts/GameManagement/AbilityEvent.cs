using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityEvent
{
	[Tooltip ("Amount of time in seconds before the event cast all its effects")] public float startTime;
	[Tooltip ("Amount of time in seconds before the event is destroyed with its children")] public float endTime;
	[Tooltip ("Script that will place the event in the world. MUST NOT BE NULL")] public AbilityPosition eventPosition;
	[Tooltip ("Script that will rotate the event in the world. MUST NOT BE NULL")] public AbilityRotation eventRotation;
	[Tooltip ("All effects will be casted in order on the same frame. ARRAY MUST NOT HAVE ANY NULL ELEMENTS")] public AbilityEffect[] effect;
	[Tooltip ("Condition that are verified every frame. Destroy the event early if true")] public AbilityInterrupt[] eventInterrupt;

}
