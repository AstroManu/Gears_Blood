using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

	[Tooltip ("Transform of the unit")] public Transform target;
	private Animator anim;
	//private SpriteRenderer sR;
	private float nextFaceUpdate = 0f;
	[Tooltip ("Reference to all sprite children that must be colored with the unit color on start")] public SpriteRenderer[] coloredSprite;

	[Tooltip ("Don't touch this. Set to true for the commander")] public bool idleOverriden = false;
	[HideInInspector] public bool moveRight = true;

	[Tooltip ("Transform position where projectiles are instantiated")] public Transform shotSpawn;

	[Tooltip ("Child particle system for blaze condition")] public ParticleSystem blazeFx;

	[Tooltip ("Health UI prefab for the unit")] public GameObject healthBarsPrefab;
	[HideInInspector] public UnitHealthBars HealthUI;
	[Tooltip ("Offset of the health display")] public Vector3 healthBarsOffset;

	[Tooltip ("Don't touch this. Reference to range display object.")]public RangeDisplay rangeDisplay;

	public void InitializeSpriteC (GameUnit unit)
	{
		anim = GetComponent<Animator> ();
		target = unit.transform;
		AnimIdleMove ();
		if (healthBarsPrefab != null)
		{
			GameObject healthBarsObject = Instantiate (healthBarsPrefab, transform.parent);
			HealthUI = healthBarsObject.GetComponent <UnitHealthBars> ();
			HealthUI.target = this;
		}

	}

	public void SetUnitColor (Color unitColor)
	{
		foreach (SpriteRenderer spriteToColor in coloredSprite)
		{
			spriteToColor.color = unitColor;
		}
	}

	void Update ()
	{
		if (target == null)
		{
			return;
		}

		if (target.position == transform.position)
		{
			if (!idleOverriden)
			{
				anim.SetBool ("IsMoving", false);
			}
		}
		else
		{
			if (!idleOverriden)
			{
				anim.SetBool ("IsMoving", true);
			}
			//moveRight = transform.position.x <= target.transform.position.x;
			moveRight = UpdateFaceRight();
			transform.position = target.position;
			//int pos = Mathf.RoundToInt (transform.position.z * 2f);
			//sR.sortingOrder = (pos * -1);
		}
	}

	public void AnimIdleMove ()
	{
		anim.SetInteger ("StateIndex", 1);
	}

	public void AnimCast (int[] castIndex)
	{
		anim.SetInteger ("StateIndex", 2);
		anim.SetInteger ("CastIndex", castIndex[Random.Range (0, castIndex.Length)]);
	}

	public void InitializeDeath (float destroyDelay)
	{
		Destroy (gameObject, destroyDelay);
	}

	public void faceDirection (bool faceRight)
	{
		if (faceRight)
		{
			transform.localScale = new Vector3 (1f, 1f, 1f);
			return;
		}
		transform.localScale = new Vector3 (-1f, 1f, 1f);
	}

	public bool UpdateFaceRight ()
	{
		if (Time.time >= nextFaceUpdate)
		{
			nextFaceUpdate = Time.time + 0.3f;
			return transform.position.x <= target.transform.position.x;
		}
		return moveRight;
	}

	public void UpdateOverridenIdle (bool moving)
	{
		anim.SetBool ("IsMoving", moving);
	}
}
