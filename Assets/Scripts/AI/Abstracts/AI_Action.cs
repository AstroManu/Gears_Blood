using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI_Action : ScriptableObject {

	public abstract void DoAction (GameUnit unit, AI_State state);

}
