using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUHealth : UnitHealth {

	public override void InitializeHealth ()
	{
		if (unit.spriteC.HealthUI != null)
		{
			unit.spriteC.HealthUI.InitializeDisplay (maxArmor > 0f, maxShield > 0f);
		}
		damageFxOverlay = unit.spriteC.hitFxOverlay;
	}

	public override void DestroyUnit ()
	{
		unit.preset.deathFx.Cast (unit, transform.position);
		Destroy (unit.spriteC.gameObject);
		Destroy (gameObject);
	}

	public override void UpdateDisplay ()
	{
		float healthFill = Mathf.InverseLerp (0f, unit.health.maxHealth, unit.health.health);
		float armorFill = Mathf.InverseLerp (0f, unit.health.maxArmor, unit.health.armor);
		float shieldFill = Mathf.InverseLerp (0f, unit.health.maxShield, unit.health.shield);
		if (unit.spriteC.HealthUI != null)
		{
			unit.spriteC.HealthUI.UpdateDisplay (healthFill, armorFill, shieldFill);
		}
	}

	public override void DamageOverlayEffect ()
	{
		damageFxLerp = 1f;
	}

	public override void DamageOverlayFallout ()
	{
		Color overlayColor = Color.Lerp (Color.clear, Color.red, damageFxLerp);
		foreach (SpriteRenderer overlay in damageFxOverlay)
		{
			overlay.color = overlayColor;
		}

		damageFxLerp = Mathf.Clamp01 (damageFxLerp - Time.deltaTime * 1.5f);
	}

	public override void TempUnderAttackBark ()
	{
		
	}
}
