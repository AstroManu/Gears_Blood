using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDisplay : MonoBehaviour {

	public float width = 0.15f;

	public SpriteRenderer sR;
	public Transform circleSprite;
	public Transform circleMask;

	public void SetColor (Color displayColor)
	{
		sR.color = displayColor;
	}

	public void SetDisplay (float radius)
	{
		float maskScale = 1 - width / radius;
		circleSprite.localScale = new Vector3 (radius, radius, 1);
		circleMask.localScale = new Vector3 (maskScale, maskScale, 1);
	}
}
