using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UnitHealthBars : MonoBehaviour {

	public SpriteController target;

	public Image healthBar;
	public Image armorBar;
	public Image shieldBar;
	public GameObject armorBackground;
	public GameObject shieldBackGround;

	void Update ()
	{
		if (target == null)
		{
			Destroy (gameObject);
			return;
		}
		transform.position = target.transform.position + target.healthBarsOffset;
	}

	public abstract void InitializeDisplay (bool asArmor, bool asShield);
	public abstract void UpdateDisplay (float healthFill, float armorFill, float shieldFill);
}
