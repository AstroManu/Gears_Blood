using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePressurePad : MonoBehaviour {

	public Animator anim;
	public LayerMask canPress;
	public Vector3 padRadius = new Vector3 (0.35f, 1f, 0.35f);
	public bool isPressed = false;

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
			if (!isPressed)
			{
				AkSoundEngine.PostEvent ("SFX_Platform_Interrupter", gameObject);
			}
			anim.SetBool ("isOn", true);
			isPressed = true;
			return 1;
		}
		if (isPressed)
		{
			AkSoundEngine.PostEvent ("SFX_Platform_Interrupter", gameObject);
		}
		anim.SetBool ("isOn", false);
		isPressed = false;
		return 0;
	}
}
