using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogEvent
{
	public string nameTag;
	public RuntimeAnimatorController portrait;
	public Color nameColor = Color.white;
	[TextArea (3, 7)] public string dialogText;
	[TextArea (2, 4)] public string tutorialText;
}
