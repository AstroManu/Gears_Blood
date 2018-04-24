using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OrderUIBehavior : ScriptableObject {

	public abstract void InitializeUI (PUController pUC);
	public abstract void UIBehavior (PUController pUC);

}
