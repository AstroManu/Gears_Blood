using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBarsStandard : UnitHealthBars {

	public override void InitializeDisplay (bool asArmor, bool asShield)
	{
		armorBackground.SetActive (asArmor);
		shieldBackGround.SetActive (asShield);
		if (!asArmor)
		{
			shieldBackGround.transform.localPosition = Vector3.zero;
		}
	}

	public override void UpdateDisplay (float healthFill, float armorFill, float shieldFill)
	{
		healthBar.fillAmount = healthFill;
		armorBar.fillAmount = armorFill;
		shieldBar.fillAmount = shieldFill;
	}
}
