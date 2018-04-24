using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_BoxSearch : TriggerCheck {

	public Vector3 boxRadius = new Vector3 (1f, 5f, 1f);
	public LayerMask lookFor;

	public override bool DoCheck ()
	{
		Collider[] col = Physics.OverlapBox (transform.position, boxRadius, transform.rotation, lookFor);
		return col.Length > 0;
	}

}
