using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OrderUICastGround", menuName = "Misc/OrderUI/CastGround", order = 45)]
public class OrderUICastGround : OrderUIBehavior {

	public override void InitializeUI (PUController pUC)
	{
		pUC.orderObject.SetInteger ("AnimIndex", 4);
		pUC.orderSprite.gameObject.SetActive (true);
		pUC.orderObject.transform.position = pUC.worldTarget;
	}

	public override void UIBehavior (PUController pUC)
	{
		if (pUC.castHasBeenReported)
		{
			pUC.orderSprite.gameObject.SetActive (false);
		}
	}

}
