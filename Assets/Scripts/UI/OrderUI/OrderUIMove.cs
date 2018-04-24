using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OrderUIMove", menuName = "Misc/OrderUI/Move", order = 45)]
public class OrderUIMove : OrderUIBehavior {

	public override void InitializeUI (PUController pUC)
	{
		pUC.orderObject.SetInteger ("AnimIndex", 3);
	}

	public override void UIBehavior (PUController pUC)
	{
		pUC.orderObject.transform.position = pUC.worldTarget;
		pUC.orderSprite.gameObject.SetActive (Vector3.Distance (pUC.worldTarget, pUC.transform.position) > 2f);
	}

}
