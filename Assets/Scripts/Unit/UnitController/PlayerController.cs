using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Rewired;

public class PlayerController : UnitController {

	//Player movement
	[Tooltip ("Commander max speed. Must be 0.5 slower than slowest PU")] public float playerSpeed = 5f;
	[Tooltip ("Don't touch this. Lower values will accelarate/decelerate faster")] public float playerSmoothTime = 20f;

	[Tooltip ("Don't touch this. Length should be 4, with a reference to each PU")] public PUController[] squad;

	//Squads follow positions
	[Tooltip ("Don't touch this")] public Transform followPositions;
	[Tooltip ("Don't touch this")] public float followMoveOffset = 1f;

	//Smooth ref values
	private Vector3 playerVelocity;
	private Vector3 playerRefVelocity;
	private Vector3 playerTargetVelocity = Vector3.zero;

	//Cursor
	[Tooltip ("Don't touch this")] public Transform cursor;
	[Tooltip ("How far the cursor will go if joystick is pushed all the way")] public float cursorRange = 15f;
	[Tooltip ("Lower values will make the cursor react faster to input")] public float cursorSmoothTime = 15f;
	private Vector3 cursorTargetPosition = Vector3.zero;
	private bool staySnapped = true;
	private Vector3 cursorRefVelocity;

	[Tooltip ("How long the squad button must be pressed to cast ability")] public float inputLongPress = 1f;

	//Cursor UI
	[Tooltip ("Don't touch this")] public SpriteRenderer cursorSprite;
	[Tooltip ("Cursor color")] public Color cursorDefaultColor;
	[Tooltip ("Don't touch this")] public Image castUI;
	[Tooltip ("Don't touch this")] public CanvasGroup castCG;
	[Tooltip ("Don't touch this")] public GameObject cursorLockUI;

	//Cursor Target-lock
	[Tooltip ("Don't touch this")] public LayerMask canLockCursorOn;
	[HideInInspector] public GameUnit lockedTarget;

	[HideInInspector] public NavMeshAgent agent;

	public override void InitializeController ()
	{
		player = ReInput.players.GetPlayer (playerName);
		agent = unit.agent;
		agent.updateRotation = false;
		unit.spriteC.InitializeSpriteC (unit);
		unit.spriteC.AnimIdleMove ();
	}


	void Update ()
	{
		bool cmdTrigger = player.GetButton ("CmdTrigger");
		float vectorX = player.GetAxis ("AxisHorizontal");
		float vectorY = player.GetAxis ("AxisVertical");
		PlayerInput (cmdTrigger, vectorX, vectorY);
		MovePlayer ();
		MoveCursor ();
		CursorUI ();
		SquadAbilityRangeDisplay ();
		unit.spriteC.faceDirection (unit.spriteC.moveRight);
		TempMusicCheck ();
	}

	void PlayerInput (bool cmdMode, float vX, float vY)
	{
		if (cmdMode)
		{
			playerTargetVelocity = Vector3.zero;
			followPositions.localPosition = Vector3.zero;

			cursorTargetPosition = (new Vector3 (vX * cursorRange, 0f, vY * cursorRange));
			CheckCursorLock ();

			//Time.timeScale = Mathf.Lerp (Time.timeScale, 0.1F, 0.2F);
			staySnapped = false;
		}
		else
		{
			playerTargetVelocity = new Vector3 (vX * playerSpeed, 0f, vY * playerSpeed);
			followPositions.localPosition = new Vector3 (vX * followMoveOffset, 0f, vY * followMoveOffset);

			cursorTargetPosition = Vector3.zero;
			float distanceToPlayer = (cursor.localPosition.x * cursor.localPosition.x) + (cursor.localPosition.y * cursor.localPosition.y);
			lockedTarget = null;
			//Time.timeScale = Mathf.Lerp (Time.timeScale, 1F, 0.2F);
			if (distanceToPlayer <= 0.1f)
			{
				staySnapped = true;
			}
		}
	}

	void MovePlayer ()
	{
		agent.velocity = Vector3.SmoothDamp (agent.velocity, playerTargetVelocity, ref playerRefVelocity, Time.deltaTime * playerSmoothTime);
		unit.spriteC.UpdateOverridenIdle (agent.velocity.magnitude > 0.2f);
	}

	#region Cursor
	void MoveCursor ()
	{
		if (!staySnapped)
		{
			cursor.localPosition = Vector3.SmoothDamp (cursor.localPosition, cursorTargetPosition, ref cursorRefVelocity, Time.deltaTime * cursorSmoothTime);
		}
		else
		{
			cursor.localPosition = Vector3.zero;
		}
	}

	void CheckCursorLock ()
	{
		List<TargetUnit> targets = new List<TargetUnit>();
		Collider[] targetsFound = Physics.OverlapSphere (cursor.position, 1f, canLockCursorOn);
		if (targetsFound.Length <= 0)
		{
			lockedTarget = null;
			return;
		}

		foreach (Collider col in targetsFound)
		{
			GameUnit target = col.transform.GetComponent<GameUnit>();
			targets.Add (new TargetUnit (target, LockValue (target)));
		}
		targets.Sort ();
		lockedTarget = targets [0].unit;
	}

	private float LockValue (GameUnit aggroTarget)
	{
		Vector3 distVector = cursor.position - aggroTarget.transform.position;
		return 0f - (distVector.x * distVector.x + distVector.z * distVector.z);
	}

	void CursorUI ()
	{
		float pressedTime = 0f;
		cursorSprite.color = cursorDefaultColor;

		cursorLockUI.SetActive (lockedTarget != null);

		foreach (PUController pUC in squad)
		{
			if (pUC.timePressed > pressedTime)
			{
				cursorSprite.color = pUC.squadColor;
				castUI.color = pUC.squadColor;
				pressedTime = pUC.timePressed;
			}
		}
		float castLerpValue = Mathf.InverseLerp (0f, inputLongPress, pressedTime);
		castUI.fillAmount = castLerpValue;
		castCG.alpha = castLerpValue - 0.3f;
	}
	#endregion

	#region SquadInput
	public void SquadInputSimple (int squadIndex, float timePressed)
	{
		NavMeshHit sampleHit;

		if (timePressed >= inputLongPress)
		{
			if (lockedTarget != null)
			{
				squad [squadIndex].SetStateCastTarget (lockedTarget);
				return;
			}

			if (NavMesh.SamplePosition (cursor.transform.position, out sampleHit, 1f, squad[squadIndex].unit.agent.areaMask))
			{
				if (player.GetButton ("CmdTrigger"))
				{
					squad [squadIndex].SetStateCastGround (cursor.transform.position);
				}
				else
				{
					squad [squadIndex].SetStateCastGround (squad[squadIndex].transform.position - new Vector3 (0f, 0f, 0.001f));
				}

			}
			return;
		}

		if (player.GetButton ("CmdTrigger"))
		{
			if (lockedTarget != null)
			{
				squad [squadIndex].SetStateAttackTarget (lockedTarget);
				return;
			}

			if (NavMesh.SamplePosition (cursor.transform.position, out sampleHit, 1f, squad[squadIndex].unit.agent.areaMask))
			{
				squad [squadIndex].SetStateAttackMove (cursor.transform.position);
			}
			return;
		}

		squad [squadIndex].SetStateFollow ();
	}

	public void SquadInputDouble (int squadIndex)
	{
		squad [squadIndex].SetStateForceMove (cursor.transform.position);
	}

	public void SquadAbilityRangeDisplay ()
	{
		foreach (PUController pUC in squad)
		{
			if (pUC != null)
			{
				float castLerpValue = Mathf.InverseLerp (0f, inputLongPress, pUC.timePressed);
				pUC.unit.spriteC.rangeDisplay.SetColor (new Color (pUC.squadColor.r, pUC.squadColor.g, pUC.squadColor.b, castLerpValue - 0.3f));
			}
		}
	}
	#endregion

	public void TempMusicCheck ()
	{
		bool inCombat = false;

//		foreach (PUController pU in squad)
//		{
//			if (pU.unit.stateC.currentTarget != null)
//			{
//				inCombat = true;
//			}
//		}

		if (!inCombat)
		{
			Collider[] col = Physics.OverlapSphere (transform.position, 15, unit.preset.faction.aggro);
			inCombat = col.Length > 0;
		}

		//Debug.Log ("" + inCombat);
		unit.gC.TempSwitchMusic (inCombat);

	}

	public override void ReportCast (int castedAbility)
	{
		
	}
}
