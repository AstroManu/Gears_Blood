using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCaster : MonoBehaviour {

	public float startTime;
	public float endTime;
	public GameUnit caster;
	public Vector3 target;
	public LayerMask canHit;
	public AbilityEffect[] effects;
	public AbilityInterrupt[] interrupts;

	public List<GameUnit> acquiredUnits;

	private bool castIsTriggered = false;

	void Start ()
	{
		Destroy (gameObject, endTime);
	}

	void Update ()
	{
		foreach (AbilityInterrupt interruption in interrupts)
		{
			if (interruption.Condition (caster))
			{
				Destroy (gameObject);
			}
		}

		if (startTime <= Time.time && !castIsTriggered)
		{
			castIsTriggered = true;

			foreach (AbilityEffect fX in effects)
			{
				fX.DoEffect (caster, target, canHit, this);
			}
		}
	}
}
