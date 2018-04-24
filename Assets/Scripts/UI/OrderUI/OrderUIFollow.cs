using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "OrderUIFollow", menuName = "Misc/OrderUI/Follow", order = 45)]
public class OrderUIFollow : OrderUIBehavior {

	public override void InitializeUI (PUController pUC)
	{
		pUC.orderObject.SetInteger ("AnimIndex", 2);
		pUC.orderSprite.gameObject.SetActive (true);
	}

	public override void UIBehavior (PUController pUC)
	{
		pUC.orderObject.transform.position = pUC.pC.transform.position + pUC.followPositionUIOffset;
		pUC.orderSprite.gameObject.SetActive ((Vector3.Distance ((pUC.pC.transform.position + pUC.followPositionUIOffset), pUC.transform.position) > 2f) && pUC.orderSprite.gameObject.activeInHierarchy);
	}

}
