using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public abstract class UnitController : MonoBehaviour {

	[Tooltip ("Don't touch this. Rewired player")] public string playerName;
	[HideInInspector] public Player player;

	[HideInInspector] public GameUnit unit;
	[HideInInspector] public Vector3 worldTarget = Vector3.zero;

	public abstract void InitializeController ();
	public abstract void ReportCast (int castedAbility);

}
