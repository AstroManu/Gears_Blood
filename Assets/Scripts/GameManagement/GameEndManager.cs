using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour {

	private GameController gC;

	public WinLostDefinition[] victoryState;
	public WinLostDefinition[] defeatState;

	void Start ()
	{
		gC = StaticRef.gameControllerRef.GetComponent <GameController> ();
	}

	void Update ()
	{
		if (!gC.gameEnded)
		{
			CheckVictory ();
			CheckDefeat ();
		}
	}

	public void CheckVictory ()
	{
		//Check if victory is achieved
		foreach (WinLostDefinition victory in victoryState)
		{
			int winAchieved = 0;
			foreach (TriggerCheck winCheck in victory.endCondition)
			{
				if (winCheck.DoCheck ())
				{
					winAchieved++;
				}
			}
			if (winAchieved >= victory.endCondition.Length)
			{
				gC.Victory (victory);
				return;
			}
		}
	}

	public void CheckDefeat ()
	{
		//Check if defeat is achieved
		foreach (WinLostDefinition defeat in defeatState)
		{
			foreach (TriggerCheck defeatCheck in defeat.endCondition)
			{
				bool defeatAchieved = true;
				if (!defeatCheck.DoCheck ())
				{
					defeatAchieved = false;
				}
				if (defeatAchieved)
				{
					gC.Defeat (defeat);
					return;
				}
			}
		}
	}
}
