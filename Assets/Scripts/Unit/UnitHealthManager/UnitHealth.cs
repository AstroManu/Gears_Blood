using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitHealth : MonoBehaviour {

	[HideInInspector] public GameUnit unit;

	[Tooltip ("Don't touch this unless the unit doesn't load UnitRef")] public float maxHealth;
	[Tooltip ("Don't touch this unless the unit doesn't load UnitRef")] public float health;
	[Tooltip ("Don't touch this unless the unit doesn't load UnitRef")] public float maxArmor;
	[Tooltip ("Don't touch this unless the unit doesn't load UnitRef")] public float armor;
	[Tooltip ("Don't touch this unless the unit doesn't load UnitRef")] public float maxShield;
	[Tooltip ("Don't touch this unless the unit doesn't load UnitRef")] public float shield;

	[HideInInspector] public SpriteRenderer[] damageFxOverlay;
	[HideInInspector] public float damageFxLerp = 0f;

	public abstract void InitializeHealth ();

	void Update ()
	{
		ShieldRestoration ();
		DamageOverlayFallout ();
	}

	public void Damage (float amount, GameUnit source)
	{
		DoDamage (amount);
		UpdateDisplay ();
		if (health <= 0f)
		{
			DestroyUnit ();
			return;
		}
		DamageOverlayEffect ();
	}

	public void EnvDamage (float amount)
	{
		DoDamage (amount);
		UpdateDisplay ();
		if (health <= 0f)
		{
			DestroyUnit ();
		}
	}

	public void DoDamage (float amount)
	{
		float damage = amount;

		//Damage on Shield
		float dmgOnShield = damage;
		damage -= shield;
		shield = Mathf.Max (shield - dmgOnShield, 0f);
		if (damage <= 0f)
		{
			UpdateDisplay ();
			return;
		}

		//Damage on Armor
		float dmgOnArmor = Mathf.Max (damage - unit.preset.dmgReducArmor, 0f);
		damage -= armor + Mathf.Min (unit.preset.dmgReducArmor, armor);
		armor = Mathf.Max (armor - dmgOnArmor, 0f);
		if (damage <= 0f)
		{
			UpdateDisplay ();
			return;
		}

		//Damage on Health
		health -= damage;
	}

	private void ShieldRestoration ()
	{
		if (shield < maxShield)
		{
			shield = Mathf.Clamp (shield + (5f * Time.deltaTime), 0f, maxShield);
			UpdateDisplay ();
		}
	}

	public abstract void DestroyUnit ();
	public abstract void UpdateDisplay ();
	public abstract void DamageOverlayEffect ();
	public abstract void DamageOverlayFallout ();
}
