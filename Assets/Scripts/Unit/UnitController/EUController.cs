using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class EUController : UnitController {

	public List<float> abilityTimers = new List<float>();

	private Player activePlayer;

	public override void InitializeController ()
	{
		player = ReInput.players.GetPlayer ("Player1");
		worldTarget = transform.position;

		foreach (UnitAbility uAb in unit.preset.ability)
		{
			abilityTimers.Add (uAb.abilityUseCondition.timer);
		}

		unit.spriteC.rangeDisplay.SetColor (new Color (1f, 0f, 0f, 0.5f));
		unit.spriteC.rangeDisplay.SetDisplay (unit.preset.aggroRange);
	}

	void Update ()
	{
		for (int i = 0; i < abilityTimers.Count; i++)
		{
			Collider[] targetsFound = Physics.OverlapSphere (transform.position, unit.preset.ability[i].abilityUseCondition.activeRadius, unit.preset.faction.aggro);
			if (targetsFound.Length > 0)
			{
				abilityTimers [i] = abilityTimers [i] - Time.deltaTime;
			}
		}
		unit.spriteC.rangeDisplay.gameObject.SetActive (player.GetButton("CmdTrigger"));
		unit.stateC.activeAbility = SelectAbility ();
	}

	public int SelectAbility ()
	{
		for (int i = 0; i < abilityTimers.Count; i++)
		{
			if (abilityTimers [i] <= 0f)
			{
				return i;
			}
		}
		return 0;
	}

	public override void ReportCast (int castedAbility)
	{
		abilityTimers [castedAbility] = unit.preset.ability [castedAbility].abilityUseCondition.timer;
	}
}
