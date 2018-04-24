using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameUnit : MonoBehaviour {

	[Tooltip("Unit template")]
	public UnitRef preset;
	[Tooltip("Should the values of the UnitRef override the unit on start? True for most units, false for commander.")]
	public bool loadRefValues = true;

	[HideInInspector] public GameController gC;

	[HideInInspector] public UnitHealth health;
	[HideInInspector] public UnitController controller;
	[HideInInspector] public UnitStateController stateC;
	[HideInInspector] public UnitConditionManager condM;
	[HideInInspector] public NavMeshAgent agent;
	[HideInInspector] public SphereCollider triggerCollider;

	[Tooltip("The visual aspect of the unit. Must be pre-referenced only if Load Ref Values is disabled")]
	public SpriteController spriteC;

	void Start ()
	{
		//Get GameController from StaticRef
		gC = StaticRef.gameControllerRef.GetComponent<GameController> ();

		//Get Components
		agent = GetComponent<NavMeshAgent> ();
		triggerCollider = GetComponent<SphereCollider> ();
		health = GetComponent<UnitHealth> ();
		health.unit = this;
		controller = GetComponent<UnitController> ();
		controller.unit = this;
		stateC = GetComponent<UnitStateController> ();
		if (stateC != null)
		{
			stateC.unit = this;
		}
		condM = GetComponent<UnitConditionManager> ();
		condM.unit = this;

		//Load unit from UnitRef
		if (preset != null && loadRefValues)
		{
			preset.LoadUnitFromRef (this);
		}
		controller.InitializeController ();
		health.InitializeHealth ();
	}

	void Update ()
	{
		condM.UpdateConditions ();
		if (stateC != null)
		{
			stateC.UpdateState ();
		}
	}

	//Where an hit fx appear when the unit is attacked
	public Vector3 HitFxPosition ()
	{
		Vector3 fXRandomiser = new Vector3 (Random.Range (-preset.hitAreaRadius, preset.hitAreaRadius), 0f, Random.Range (-preset.hitAreaRadius, preset.hitAreaRadius));
		return transform.position + preset.hitAreaCenter + fXRandomiser;
	}
}
