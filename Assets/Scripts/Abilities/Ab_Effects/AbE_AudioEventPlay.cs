using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AudioEventPlay_Template", menuName = "Abilities/Effects/AudioEvent play", order = 37)]
public class AbE_AudioEventPlay : AbilityEffect {

	[Tooltip ("An AudioClip that is played when the event start")] public string eventName;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		AkSoundEngine.PostEvent (eventName, eventCaster.gameObject);
	}

}
