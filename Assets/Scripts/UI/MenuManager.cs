using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MenuManager : MonoBehaviour {

	public string playerName = "Player1";
	private Player player;

	public MenuButton[] buttons;
	[HideInInspector] public int currentSelect = 0;

	void Start ()
	{
		buttons [0].SelectButton ();
		player = ReInput.players.GetPlayer (playerName);
	}

	void Update ()
	{
		if (player.GetButtonDown ("Next"))
		{
			buttons [currentSelect].DeselectButton ();
			currentSelect++;
			if (currentSelect >= buttons.Length)
			{
				currentSelect = 0;
			}
			buttons [currentSelect].SelectButton ();
		}

		if (player.GetButtonDown ("Previous"))
		{
			buttons [currentSelect].DeselectButton ();
			currentSelect--;
			if (currentSelect < 0)
			{
				currentSelect = buttons.Length - 1;
			}
			buttons [currentSelect].SelectButton ();
		}

		if (player.GetButtonDown ("Squad1"))
		{
			buttons [currentSelect].ActivateButton ();
		}
		if (player.GetButtonDown ("Squad2"))
		{
			currentSelect = buttons.Length - 1;
			buttons [currentSelect].SelectButton ();
		}
	}

}
