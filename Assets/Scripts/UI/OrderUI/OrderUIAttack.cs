using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OrderUIAttack", menuName = "Misc/OrderUI/Attack", order = 45)]
public class OrderUIAttack : OrderUIBehavior {

	public override void InitializeUI (PUController pUC)
	{
		pUC.orderObject.SetInteger ("AnimIndex", 1);
		pUC.orderSprite.gameObject.SetActive (true);
	}

	public override void UIBehavior (PUController pUC)
	{
		if (pUC.unit.stateC.cmdTarget != null)
		{
			pUC.orderObject.transform.position = pUC.unit.stateC.cmdTarget.transform.position;
			return;
		}
		if (pUC.unit.stateC.currentTarget != null)
		{
			pUC.orderObject.transform.position = pUC.unit.stateC.currentTarget.transform.position;
			return;
		}
		pUC.orderSprite.gameObject.SetActive (false);
	}

}
