using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUnit : IComparable<TargetUnit> {

	public GameUnit unit;
	public float aggroValue;

	public TargetUnit (GameUnit addUnit, float addAggro)
	{
		unit = addUnit;
		aggroValue = addAggro;
	}

	public int CompareTo(TargetUnit other)
	{
		if (other == null)
		{
			return 1;
		}

		return Mathf.RoundToInt(other.aggroValue - aggroValue);
	}

}
