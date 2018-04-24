using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUHealth : UnitHealth {

	[Tooltip ("HUD display of the PU")] public UiSquadDisplay squadDisplay;

	public override void InitializeHealth()
	{
		squadDisplay.InitializeDisplay (unit);
		unit.spriteC.HealthUI.InitializeDisplay (maxArmor > 0f, maxShield > 0f);
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
		unit.spriteC.HealthUI.UpdateDisplay (healthFill, armorFill, shieldFill);
	}
}
