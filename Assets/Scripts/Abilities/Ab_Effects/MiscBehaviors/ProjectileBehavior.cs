using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

	[HideInInspector] public float speed;
	[HideInInspector] public float killTime;
	[HideInInspector] public float damage;
	[HideInInspector] public float blazeDuration;
	[HideInInspector] public float slowDuration;
	[HideInInspector] public float slowMultiplier;
	[HideInInspector] public float tauntDuration;
	[HideInInspector] public GameUnit target;
	[HideInInspector] public GameObject hitFx;
	[HideInInspector] public GameUnit caster;

	void Update ()
	{
		if (Time.time >= killTime)
		{
			if (target != null)
			{
				target.health.Damage (damage, caster);

				if (blazeDuration > 0f)
				{
					target.condM.InputBlaze (blazeDuration);
				}
				if (slowDuration > 0f)
				{
					target.condM.InputSlow (slowDuration, slowMultiplier);
				}
				if (tauntDuration > 0f)
				{
					target.condM.InputTaunt (tauntDuration, caster);
				}
			}

			Instantiate (hitFx, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
		else
		{
			transform.Translate (new Vector3 (0f, 0f, speed * Time.deltaTime));
		}
	}
}
