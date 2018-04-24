using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerformDialog : MonoBehaviour {

	public DialogAsset dialog;
	public TriggerCheck[] triggers;
	private GameController gC;

	void Start ()
	{
		gC = StaticRef.gameControllerRef.GetComponent<GameController>();
	}

	void Update ()
	{
		foreach (TriggerCheck check in triggers)
		{
			if (!check.DoCheck ())
			{
				return;
			}
		}
		Destroy (gameObject);
		gC.dialogManager.BeginDialogEvent (dialog);

	}
}
