using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSquadDisplay : MonoBehaviour {

	[HideInInspector] public GameUnit unit;

	public Image healthBar;
	public Image armorBar;
	public Image shieldBar;

	public Text healthText;

	public Image[] cooldownDisplay;

	public void InitializeDisplay (GameUnit squad)
	{
		unit = squad;

		if (unit.health.maxArmor <= 0f)
		{
			armorBar.gameObject.SetActive (false);
		}
		if (unit.health.maxShield <= 0f)
		{
			shieldBar.gameObject.SetActive (false);
		}

		UpdateHealth ();
		UpdateCooldown ();
	}

	void Update ()
	{
		UpdateCooldown ();
	}

	void UpdateCooldown ()
	{
		float cooldownFill = Mathf.InverseLerp (unit.stateC.nextAbility - unit.preset.ability[1].coolDownDuration, unit.stateC.nextAbility, Time.time);

		foreach (Image image in cooldownDisplay)
		{
			image.fillAmount = cooldownFill;
		}
	}

	public void UpdateHealth ()
	{
		healthBar.fillAmount = Mathf.InverseLerp (0f, unit.health.maxHealth, unit.health.health);
		armorBar.fillAmount = Mathf.InverseLerp (0f, unit.health.maxArmor, unit.health.armor);
		shieldBar.fillAmount = Mathf.InverseLerp (0f, unit.health.maxShield, unit.health.shield);
		healthText.text = ("" + Mathf.Clamp (Mathf.Round(unit.health.health), 0f, unit.health.maxHealth));
	}
}
