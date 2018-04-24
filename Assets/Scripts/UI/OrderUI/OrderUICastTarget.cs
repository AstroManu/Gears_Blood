using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OrderUICastTarget", menuName = "Misc/OrderUI/CastTarget", order = 45)]
public class OrderUICastTarget : OrderUIBehavior {

	public override void InitializeUI (PUController pUC)
	{
		pUC.orderObject.SetInteger ("AnimIndex", 4);
		pUC.orderSprite.gameObject.SetActive (true);
	}

	public override void UIBehavior (PUController pUC)
	{
		if (pUC.unit.stateC.cmdTarget != null)
		{
			pUC.orderObject.transform.position = pUC.unit.stateC.cmdTarget.transform.position;
		}
		if (pUC.unit.stateC.currentTarget != null)
		{
			pUC.orderObject.transform.position = pUC.unit.stateC.currentTarget.transform.position;
		}
		pUC.orderSprite.gameObject.SetActive (false);
		if (pUC.castHasBeenReported)
		{
			pUC.orderSprite.gameObject.SetActive (false);
		}
	}

}
