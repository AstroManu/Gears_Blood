using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiSquadDisplay : MonoBehaviour {

	[HideInInspector] public GameUnit unit;

	public Image unitPortrait;
	public Image unitPortraitColor;
	public TextMeshProUGUI unitName;

	public Image healthBar;
	public Image armorBar;
	public Image shieldBar;

	public Image damageFx;

	public Image[] cooldownDisplay;
	public Image cooldownReady;

	public void InitializeDisplay (GameUnit squad)
	{
		unit = squad;
		unitPortrait.sprite = unit.preset.portraitBase;
		unitPortraitColor.sprite = unit.preset.portraitColor;
		unitName.text = unit.preset.unitName;

		armorBar.gameObject.SetActive (unit.health.maxArmor > 0f);
		shieldBar.gameObject.SetActive (unit.health.maxShield > 0f);
		damageFx.color = new Color (0, 0, 0, 0);

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

		cooldownReady.gameObject.SetActive (cooldownFill >= 1f);
	}

	public void UpdateHealth ()
	{
		healthBar.fillAmount = Mathf.InverseLerp (0f, unit.health.maxHealth, unit.health.health);
		armorBar.fillAmount = Mathf.InverseLerp (0f, unit.health.maxArmor, unit.health.armor);
		shieldBar.fillAmount = Mathf.InverseLerp (0f, unit.health.maxShield, unit.health.shield);
	}
}
