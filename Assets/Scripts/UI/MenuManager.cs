using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MenuManager : MonoBehaviour {

	public string playerName = "Player1";
	private Player player;

	public string hoverAudioEvent = "UI_Menu_Hover";
	public string selectAudioEvent = "UI_Menu_Select";

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
			AkSoundEngine.PostEvent (hoverAudioEvent, gameObject);
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
			AkSoundEngine.PostEvent (hoverAudioEvent, gameObject);
		}

		if (player.GetButtonDown ("Squad1"))
		{
			buttons [currentSelect].ActivateButton ();
			AkSoundEngine.PostEvent (selectAudioEvent, gameObject);
		}
		if (player.GetButtonDown ("Squad2"))
		{
			currentSelect = buttons.Length - 1;
			buttons [currentSelect].SelectButton ();
		}
	}

}
