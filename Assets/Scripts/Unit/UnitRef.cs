using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (fileName = "New Unit", menuName = "Unit Reference", order = 35)]
public class UnitRef : ScriptableObject {

	[Header("Identifier")]
	[Tooltip ("Ingame name of the unit")] public string unitName = "New Unit";
	[Tooltip ("Ingame description of the unit")][TextArea (2, 10)] public string unitDescription = "Description";
	[Tooltip ("Faction reference of the unit")] public FactionPreset faction;

	[Header("Health stats")]
	[Tooltip ("Max amount of health points")] public float maxHealth = 100f;
	[Tooltip ("Max amount of armor points")] public float maxArmor = 0f;
	[Tooltip ("Max amount of shield points")] public float maxShield = 0f;
	[Tooltip ("How much damage points is removed from each hit on armor")] public float dmgReducArmor = 1f;

	[HideInInspector] public int agentType = 0;
	[Header("Movement")]
	[Tooltip ("How fast the unit move. PU should have at least 0.5 speed more than the commander")] public float moveSpeed = 10f;
	[Tooltip ("Don't touch this. Override agent accelaration")] public float moveAccelaration = 50f;
	[Tooltip ("Don't touch this. Override agent stopping distance")] public float moveStoppingDistance = 0.5f;
	[Tooltip ("Higher value units cannot push lower value units. PU = 50, Commander = 49, EU = 40, Unmovable = 25")]public int agentPriority = 50;
	[Tooltip ("Don't touch this. Start AI_State. PU should use Follow_Follow")] public AI_State startState;

	//Size Stats
	[HideInInspector] public float colliderRadius = 0.5f;

	[Header("Abilities")]
	[Tooltip ("How far the unit will look for target")] public float aggroRange = 15f;
	[Tooltip ("Abilites of the Unit. PU should always have 2 abilites: 1 attack + 1 cast ability")] public UnitAbility[] ability;

	[Header("Hit FX area")]
	[Tooltip ("Offset from unit position where hit fx will appear")] public Vector3 hitAreaCenter = new Vector3 (0f, 0f, 1f);
	[Tooltip ("Radius in which hit fx can randomly be placed")] public float hitAreaRadius = 0.5f;

	[Header("Visuals")]
	[Tooltip ("Prefab of the unit visual aspect. Must have a SpriteController on root.")] public GameObject spritePrefab;
	[Tooltip ("An ability that is casted at the unit location upon destruction. Most units will spawn an animated death fx.")] public Ability deathFx;
	[Tooltip ("PU only. Sprite shown in portrait.")] public Sprite portraitBase;
	[Tooltip ("PU only. Sprite color overlay for portrait.")] public Sprite portraitColor;

	[Header("AudioEvents VO")]
	public string BarkAbility;
	public string BarkAbilityReady;
	public string BarkAttack;
	public string BarkFollow;
	public string BarkLowHealth;
	public string BarkMove;
	public string BarkShieldLost;
	public string BarkArmorLost;
	public string BarkUnderAttack;

	//Take ref values and create the unit
	public void LoadUnitFromRef (GameUnit gameUnit)
	{
		//Unit Identity
		gameUnit.gameObject.layer = LayerMask.NameToLayer (faction.layerName);

		//Unit Health Generation
		gameUnit.health.maxHealth = maxHealth;
		gameUnit.health.health = maxHealth;
		gameUnit.health.maxArmor = maxArmor;
		gameUnit.health.armor = maxArmor;
		gameUnit.health.maxShield = maxShield;
		gameUnit.health.shield = maxShield;

		//Navmesh Agent Generation
		if (gameUnit.agent != null)
		{
			gameUnit.agent.agentTypeID = agentType;
			gameUnit.agent.speed = moveSpeed;
			gameUnit.agent.acceleration = moveAccelaration;
			gameUnit.agent.stoppingDistance = moveStoppingDistance;
			gameUnit.agent.avoidancePriority = agentPriority;
			gameUnit.agent.radius = colliderRadius;
		}

		//Sprite Generation
		GameObject spriteRoot = Instantiate (spritePrefab, gameUnit.transform.position, Quaternion.identity);
		spriteRoot.transform.SetParent (gameUnit.gC.spritesParent.transform);
		gameUnit.spriteC = spriteRoot.GetComponent<SpriteController> ();
		gameUnit.spriteC.InitializeSpriteC (gameUnit);
		//gameUnit.spriteC.target = gameUnit.transform;

		//Starting AI State
		if (startState != null)
		{
			startState.InitializeState (gameUnit);
		}

		//Trigger Collider
		gameUnit.triggerCollider.radius = colliderRadius;
	}
}
