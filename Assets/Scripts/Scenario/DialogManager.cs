using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rewired;

public class DialogManager : MonoBehaviour {

	public string playerName = "Player1";
	public GameObject dialogOverlay;
	public Animator portraitRef;
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogText;
	public TextMeshProUGUI tutorialText;
	public GameObject tutorialBox;

	public GameController gC;

	private Player player;
	private int activeDialog = 0;
	private DialogAsset currentDialog;

	void Awake ()
	{
		player = ReInput.players.GetPlayer (playerName);
	}

	void Update ()
	{
		if (player.GetButtonDown ("Next") && dialogOverlay.activeInHierarchy)
		{
			if (activeDialog >= currentDialog.dialogEvents.Count - 1)
			{
				EndDialogEvent ();
			}
			else
			{
				activeDialog++;
				LoadDialog (activeDialog);
			}
		}
		if (player.GetButtonDown ("Previous") && dialogOverlay.activeInHierarchy)
		{
			if (activeDialog <= 0)
			{
				
			}
			else
			{
				activeDialog--;
				LoadDialog (activeDialog);
			}
		}
	}

	public void BeginDialogEvent (DialogAsset dA)
	{
		currentDialog = dA;
		LoadDialog (activeDialog);
		dialogOverlay.SetActive (true);
		gC.Pause ();
	}

	public void EndDialogEvent ()
	{
		dialogOverlay.SetActive (false);
		activeDialog = 0;
		gC.Resume ();
	}

	public void LoadDialog (int dIndex)
	{
		nameText.text = currentDialog.dialogEvents [dIndex].nameTag;
		nameText.color = currentDialog.dialogEvents [dIndex].nameColor;
		portraitRef.runtimeAnimatorController = currentDialog.dialogEvents [dIndex].portrait;
		dialogText.text = currentDialog.dialogEvents [dIndex].dialogText;
		tutorialText.text = currentDialog.dialogEvents [dIndex].tutorialText;
		tutorialBox.SetActive (currentDialog.dialogEvents [dIndex].tutorialText.Length > 0);
	}
}
