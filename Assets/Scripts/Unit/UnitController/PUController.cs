using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PUController : UnitController {

	[Tooltip ("Portrait for the SquadBar UI")] public RuntimeAnimatorController squadPortrait;
	[Tooltip ("Don't touch this. Rewired action associated with unit")] public string squadKey;
	[Tooltip ("Don't touch this. Position in the squad array of the PlayerController")] public int squadIndex;
	[Tooltip ("Don't touch this")] public PlayerController pC;
	[Tooltip ("Don't touch this. Color of the unit")] public Color squadColor;

	[Tooltip ("Don't touch this")] public AI_State followState;
	[Tooltip ("Don't touch this")] public AI_State attackMoveState;
	[Tooltip ("Don't touch this")] public AI_State attackTargetState;
	[Tooltip ("Don't touch this")] public AI_State forceMoveState;
	[Tooltip ("Don't touch this")] public AI_State castGroundState;
	[Tooltip ("Don't touch this")] public AI_State castTargetState;

	[Tooltip ("Don't touch this")] public OrderUIBehavior followUI;
	[Tooltip ("Don't touch this")] public OrderUIBehavior moveUI;
	[Tooltip ("Don't touch this")] public OrderUIBehavior attackMoveUI;
	[Tooltip ("Don't touch this")] public OrderUIBehavior attackUI;
	[Tooltip ("Don't touch this")] public OrderUIBehavior castGroundUI;
	[Tooltip ("Don't touch this")] public OrderUIBehavior castTargetUI;
	[Tooltip ("Don't touch this")] public Animator orderObject;
	[Tooltip ("Don't touch this")] public SpriteRenderer orderSprite;
	[Tooltip ("Don't touch this")] public Vector3 followPositionUIOffset;
	private OrderUIBehavior activeOrderUI;


	[HideInInspector] public float timePressed = 0f;
	[HideInInspector] public bool castHasBeenReported = false;


	public override void InitializeController ()
	{
		player = ReInput.players.GetPlayer (playerName);
		unit.spriteC.SetUnitColor (squadColor);
		orderSprite.color = squadColor;
		activeOrderUI = followUI;
		activeOrderUI.InitializeUI (this);
		unit.spriteC.rangeDisplay.SetDisplay (unit.preset.ability [1].maxRange);
		unit.spriteC.rangeDisplay.gameObject.SetActive (true);
	}

	void Update ()
	{
		if (player.GetButtonUp (squadKey))
		{
			pC.SquadInputSimple (squadIndex, timePressed);
		}

		if (player.GetButtonDoublePressUp (squadKey))
		{
			pC.SquadInputDouble (squadIndex);
		}

		timePressed = player.GetButtonTimePressed (squadKey);

		activeOrderUI.UIBehavior (this);
		castHasBeenReported = false;
	}

	public void SetStateFollow ()
	{
		unit.stateC.nextState = followState;
		activeOrderUI = followUI;
		activeOrderUI.InitializeUI (this);
	}

	public void SetStateAttackMove (Vector3 pos)
	{
		worldTarget = pos;
		unit.stateC.nextState = attackMoveState;
		activeOrderUI = attackMoveUI;
		activeOrderUI.InitializeUI (this);
	}

	public void SetStateAttackTarget (GameUnit lockedTarget)
	{
		unit.stateC.nextState = attackTargetState;
		unit.stateC.cmdTarget = lockedTarget;
		activeOrderUI = attackUI;
		activeOrderUI.InitializeUI (this);
	}

	public void SetStateForceMove (Vector3 pos)
	{
		worldTarget = pos;
		unit.stateC.nextState = forceMoveState;
		activeOrderUI = moveUI;
		activeOrderUI.InitializeUI (this);
	}

	public void SetStateCastGround (Vector3 pos)
	{
		worldTarget = pos;
		unit.stateC.nextState = castGroundState;
		activeOrderUI = castGroundUI;
		activeOrderUI.InitializeUI (this);
	}

	public void SetStateCastTarget (GameUnit lockedTarget)
	{
		unit.stateC.nextState = castTargetState;
		unit.stateC.cmdTarget = lockedTarget;
		activeOrderUI = castTargetUI;
		activeOrderUI.InitializeUI (this);
	}

	public override void ReportCast (int castedAbility)
	{
		castHasBeenReported = true;
	}
}
