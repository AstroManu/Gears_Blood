using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePressurePad : MonoBehaviour {

	public Animator anim;
	public LayerMask canPress;
	public Vector3 padRadius = new Vector3 (0.35f, 1f, 0.35f);

	void Start ()
	{
		anim.SetBool ("isOn", false);
	}

	//Return +1 if the pad is pressed
	public int UpdatePressurePad ()
	{
		Collider[] col = Physics.OverlapBox (transform.position, padRadius, Quaternion.identity, canPress);
		if (col.Length > 0)
		{
			anim.SetBool ("isOn", true);
			return 1;
		}
		anim.SetBool ("isOn", false);
		return 0;
	}
}
