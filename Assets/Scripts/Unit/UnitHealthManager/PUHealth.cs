using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUHealth : UnitHealth {

	[Tooltip ("HUD display of the PU")] public UiSquadDisplay squadDisplay;
	[HideInInspector] public Image damageFxGlowUI;

	private bool shieldDownBark = false;
	private bool armorDownBark = false;
	private bool lowHealthBark = false;

	public override void InitializeHealth()
	{
		//Temp bark
		shieldDownBark = maxShield <= 0f;
		armorDownBark = maxArmor <= 0f;

		squadDisplay.InitializeDisplay (unit);
		if (unit.spriteC.HealthUI != null)
		{
			unit.spriteC.HealthUI.InitializeDisplay (maxArmor > 0f, maxShield > 0f);
		}

		damageFxOverlay = unit.spriteC.hitFxOverlay;
		damageFxGlowUI = squadDisplay.damageFx;
	}

	public override void DestroyUnit ()
	{
		unit.preset.deathFx.Cast (unit, transform.position);
		squadDisplay.gameObject.SetActive (false);
		Destroy (unit.spriteC.gameObject);
		Destroy (gameObject);
	}

	public override void UpdateDisplay ()
	{
		squadDisplay.UpdateHealth ();
		float healthFill = Mathf.InverseLerp (0f, unit.health.maxHealth, unit.health.health);
		float armorFill = Mathf.InverseLerp (0f, unit.health.maxArmor, unit.health.armor);
		float shieldFill = Mathf.InverseLerp (0f, unit.health.maxShield, unit.health.shield);
		if (unit.spriteC.HealthUI != null)
		{
			unit.spriteC.HealthUI.UpdateDisplay (healthFill, armorFill, shieldFill);
		}

		//Temp bark
		if (shieldFill <= 0f && !shieldDownBark)
		{
			AkSoundEngine.PostEvent (unit.preset.BarkShieldLost, gameObject);
			shieldDownBark = true;
		}
		if (armorFill <= 0f && !armorDownBark)
		{
			AkSoundEngine.PostEvent (unit.preset.BarkArmorLost, gameObject);
			armorDownBark = true;
		}
		if (healthFill < 0.5f && !lowHealthBark)
		{
			AkSoundEngine.PostEvent (unit.preset.BarkLowHealth, gameObject);
			lowHealthBark = true;
		}
	}

	public override void TempUnderAttackBark ()
	{
		unit.gC.TempPlayUnderAttackVO (unit.preset.BarkUnderAttack, gameObject);
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
		damageFxGlowUI.color = overlayColor;

		damageFxLerp = Mathf.Clamp01 (damageFxLerp - Time.deltaTime * 1.25f);
	}
}
