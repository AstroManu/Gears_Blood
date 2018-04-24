using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewState", menuName = "AI State/New State", order = 41)]
public class AI_State : ScriptableObject {

	public AI_Action[] initialAction;
	public AI_Action[] stateAction;
	public AI_Decision[] decision;

	public void InitializeState (GameUnit unit)
	{
		foreach (AI_Action initialAct in initialAction)
		{
			initialAct.DoAction (unit, this);
		}
	}

	public void StateBehavior (GameUnit unit)
	{
		//Do state's actions
		foreach (AI_Action stateAct in stateAction)
		{
			stateAct.DoAction (unit, this);
		}

		//Check state's decisions
		foreach (AI_Decision decide in decision)
		{
			if (decide.condition.Condition (unit))
			{
				foreach (AI_Action decisionAction in decide.actions)
				{
					decisionAction.DoAction (unit, this);
				}

				decide.newState.InitializeState (unit);
				return;
			}
		}
	}

}
