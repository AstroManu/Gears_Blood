using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Ability", menuName = "Abilities/New Ability", order = 36)]
public class Ability : ScriptableObject {

	[Tooltip ("Ingame name of the ability")] public string abilityName = "New Ability";
	[Tooltip ("Ingame description of the ability")] [TextArea (2, 10)] public string abilityDescription = "Description";

	[Tooltip ("If true, event will also acquire friendly targets from GameUnit's faction")] public bool allowFriendlyFire = false;

	[Tooltip ("Ability will spawn an EventObject for each AbilityEvent")] public AbilityEvent[] abilityEvents; 

	public void Cast (GameUnit caster, Vector3 target)
	{
		foreach (AbilityEvent ev in abilityEvents)
		{
			GameObject evObj = new GameObject ("EventObject"); //Generate EventObject
			evObj.transform.position = ev.eventPosition.eventPos (caster, target); //Place EventObject
			ev.eventRotation.eventRotation (caster, target, evObj.transform); //Rotate EventObject
			EventCaster evCaster = evObj.AddComponent<EventCaster> (); //Add EventCaster monobehavior
			evCaster.aS = evObj.AddComponent<AudioSource>(); //Add AudioSource to event object
			evCaster.caster = caster; //Pass caster ref to event
			evCaster.target = target; //Pass target location to event
			evCaster.startTime = Time.time + ev.startTime; //When event start
			evCaster.endTime = ev.endTime; //Delay before event is destroyed
			evCaster.effects = ev.effect; //Array of effects to performs
			evCaster.interrupts = ev.eventInterrupt; //Condition(s) for destroying the event early
			if (allowFriendlyFire)
			{
				evCaster.canHit = caster.preset.faction.friendlyFire; //Effects can hit anything
			}
			else
			{
				evCaster.canHit = caster.preset.faction.canHit; //Effect can hit only neutrals/hostiles
			}
		}
	}

}
