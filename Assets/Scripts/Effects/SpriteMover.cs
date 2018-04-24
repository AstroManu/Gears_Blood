using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour {

	public Transform target;
	//private SpriteRenderer sR;

	void Start ()
	{
		//sR = GetComponentInChildren <SpriteRenderer> ();
	}

	void Update ()
	{
		if (target == null)
		{
			return;
		}
		transform.position = target.position;
		//int pos = Mathf.RoundToInt (transform.position.z * 2f);
		//sR.sortingOrder = (pos * -1);
	}
}
