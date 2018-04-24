using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : MonoBehaviour {

	[HideInInspector] public GameUnit unit;

	[Tooltip ("Don't touch this")] public AI_State currentState;
	[Tooltip ("Don't touch this")] public AI_State nextState;

	[HideInInspector] public GameUnit cmdTarget;

	//Follow Position
	[Tooltip ("Don't touch this. Transform that will be followed during Follow AI_States. PU only.")] public Transform followPosition;
	[HideInInspector] public Vector3 followPosMemory;

	//Target
	[Tooltip ("Don't touch this")] public GameUnit currentTarget;
	[HideInInspector] public float distanceToTarget = 0f;

	//Abilities
	[HideInInspector] public float nextAttack = 0f; //Time.time when GameUnit can use main attack
	[HideInInspector] public float nextAbility = 0f; //Time.time when PU GameUnit can use ability
	[HideInInspector] public int activeAbility = 0; //Ability that will be casted (from UnitRef ability array index)
	[HideInInspector] public float castLockTime = 0f; //Time.time when GameUnit is out of active cast

	//SlowUpdate
	private float nextSlowUpdate = 0f;

	public void UpdateState ()
	{
		currentState.StateBehavior (unit);
	}

	//Find all available targets in Radius
	public void AcquireTarget (Vector3 center, float radius, LayerMask lookForLayer)
	{
		if (unit.condM.tauntAggroTarget != null)
		{
			currentTarget = unit.condM.tauntAggroTarget;
			return;
		}

		List<TargetUnit> targets = new List<TargetUnit>();
		Collider[] targetsFound = Physics.OverlapSphere (center, radius, lookForLayer);
		if (targetsFound.Length <= 0)
		{
			return;
		}

		foreach (Collider col in targetsFound)
		{
			GameUnit target = col.transform.GetComponent<GameUnit>();
			targets.Add (new TargetUnit (target, CalculateAggro (target)));
		}
		targets.Sort ();
		currentTarget = targets [0].unit;
	}

	//Generate a value to sort Targets by priority
	public float CalculateAggro (GameUnit aggroTarget)
	{
		Vector3 distVector = transform.position - aggroTarget.transform.position;
		return 0f - (distVector.x * distVector.x + distVector.z * distVector.z);
	}

	//SlowUpdate
	public bool SlowUpdate ()
	{
		if (Time.time >= nextSlowUpdate)
		{
			nextSlowUpdate = Time.time + unit.gC.slowUpdateDuration;
			return true;
		}
		return false;
	}

	//How far is the unit from this one, minus both units radius
	public float CalculateDistToUnit (GameUnit targetUnit)
	{
		return Vector3.Distance (transform.position, targetUnit.transform.position) - (unit.preset.colliderRadius + targetUnit.preset.colliderRadius);
	}

	//How far is the position from this unit, minus unit radius
	public float CalculateDistToGround (Vector3 pos)
	{
		return Vector3.Distance (transform.position, pos) - unit.preset.colliderRadius;
	}

	//Where to backoff if target is too close
	public Vector3 MoveBackPosition (Vector3 target, float minRange, float currentDistance)
	{
		Vector3 moveVector = transform.position - target;

		return transform.position + moveVector.normalized * (minRange - currentDistance + unit.agent.stoppingDistance);
	}

}
