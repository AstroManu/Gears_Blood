using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : UnitController {

	public override void InitializeController ()
	{
		worldTarget = transform.position;
	}

	public override void ReportCast (int castedAbility)
	{

	}
}
