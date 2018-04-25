using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateController : MonoBehaviour {

	public InteractablePressurePad[] pressurePads;
	public Animator[] pylonAnimators;
	public GameObject[] activatedObjects;

	[HideInInspector] public bool deactivated = false;

	void Start ()
	{
		foreach (Animator anim in pylonAnimators)
		{
			anim.SetBool ("isOn", true);
		}
	}

	void Update ()
	{
		if (!deactivated)
		{
			int padPressed = 0;
			foreach (InteractablePressurePad pP in pressurePads)
			{
				padPressed += pP.UpdatePressurePad ();
			}
			if (padPressed >= pressurePads.Length)
			{
				DeactivateGate ();
			}
		}
	}

	private void DeactivateGate ()
	{
		deactivated = true;
		foreach (GameObject gO in activatedObjects)
		{
			gO.SetActive (false);
		}
		foreach (Animator anim in pylonAnimators)
		{
			anim.SetBool ("isOn", false);
		}
	}
}
