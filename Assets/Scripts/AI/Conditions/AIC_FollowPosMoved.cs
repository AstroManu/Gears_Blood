using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "FollowPosMoved", menuName = "AI State/Conditions/FollowPos Moved", order = 41)]
public class AIC_FollowPosMoved : AI_Condition {

	public override bool Condition (GameUnit unit)
	{
		Vector3 moveVector = unit.stateC.followPosition.position - unit.stateC.followPosMemory;
		return (moveVector.x * moveVector.x) + (moveVector.z * moveVector.z) >= unit.gC.folReturnDist;
	}

}
