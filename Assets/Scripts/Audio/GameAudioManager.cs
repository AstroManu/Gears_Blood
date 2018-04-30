using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour {

	void Awake ()
	{
		if (StaticRef.audioManagerRef != null)
		{
			AkSoundEngine.SetState ("Game", "Menu");
			AkSoundEngine.SetState ("PlayerLife", "None");
			AkSoundEngine.SetSwitch ("Gameplay", "Exploration", gameObject);
			Destroy (gameObject);
			return;
		}

		StaticRef.audioManagerRef = gameObject;
	}

	void Start ()
	{
		AkSoundEngine.SetState ("Game", "Menu");
		AkSoundEngine.SetState ("PlayerLife", "None");
		AkSoundEngine.SetSwitch ("Gameplay", "Exploration", gameObject);
		AkSoundEngine.PostEvent ("MUS_START", gameObject);
	}
}
