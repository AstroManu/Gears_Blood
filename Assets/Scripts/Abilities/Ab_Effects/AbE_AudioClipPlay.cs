using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AudioClipPlay", menuName = "Abilities/Effects/AudioClip Play", order = 37)]
public class AbE_AudioClipPlay : AbilityEffect {

	[Tooltip ("An AudioClip that is played when the event start")] public AudioClip soundFx;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		eventCaster.aS.PlayOneShot (soundFx);
	}

}
