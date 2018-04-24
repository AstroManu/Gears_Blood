using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

	public bool quitGame;
	public string sceneToLoad;

	public Sprite selectedSprite;
	public Sprite unselectedSprite;
	public Sprite activatedSprite;

	private Image img;

	void Awake ()
	{
		img = GetComponent<Image> ();
		DeselectButton ();
	}

	public void SelectButton ()
	{
		img.sprite = selectedSprite;
	}

	public void DeselectButton ()
	{
		img.sprite = unselectedSprite;
	}

	public void ActivateButton ()
	{
		img.sprite = activatedSprite;
		if (quitGame)
		{
			Application.Quit ();
		}
		else
		{
			SceneManager.LoadScene (sceneToLoad);
		}
	}
}
