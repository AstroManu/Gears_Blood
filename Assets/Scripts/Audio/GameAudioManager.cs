using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour {

	void Awake ()
	{
		if (StaticRef.audioManagerRef != null)
		{
			Destroy (gameObject);
			return;
		}

		StaticRef.audioManagerRef = gameObject;
	}
}
