using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Projectile_Template", menuName = "Abilities/Effects/Projectile", order = 37)]
public class AbE_Projectile : AbilityEffect {

	[Tooltip ("Projectile object to instantiate. Root must have a ProjectileBehavior script attached")] public GameObject projectilePrefab;
	[Tooltip ("FX to instantiate on hit")] public GameObject hitFxPrefab;
	public float projectileSpeed = 20f;
	public float damageAmount;
	public float blazeDuration;
	public float slowDuration;
	public float slowModifier = 0.5f;
	public float tauntDuration;

	public override void DoEffect (GameUnit caster, Vector3 target, LayerMask canHit, EventCaster eventCaster)
	{
		foreach (GameUnit hit in eventCaster.acquiredUnits)
		{
			Vector3 destination = hit.HitFxPosition ();
			CreateProjectile (caster, hit, destination);
		}
	}

	private void CreateProjectile (GameUnit caster, GameUnit target, Vector3 destination)
	{
		GameObject projectile = Instantiate (projectilePrefab, caster.spriteC.shotSpawn.position, Quaternion.identity);
		projectile.transform.LookAt (destination);
		ProjectileBehavior pB = projectile.GetComponent <ProjectileBehavior> ();
		pB.hitFx = hitFxPrefab;
		pB.speed = projectileSpeed;
		pB.killTime = Time.time + (Vector3.Distance (projectile.transform.position, destination) / projectileSpeed);
		pB.damage = damageAmount;
		pB.blazeDuration = blazeDuration;
		pB.slowDuration = slowDuration;
		pB.slowMultiplier = slowModifier;
		pB.tauntDuration = tauntDuration;
		pB.target = target;
		pB.caster = caster;
	}

}
