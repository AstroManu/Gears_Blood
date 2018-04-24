using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AI_Decision
{
	public AI_Condition condition;
	public AI_State newState;
	public AI_Action[] actions;
}
