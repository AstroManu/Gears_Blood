using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraMover : MonoBehaviour {

	public Transform playerTransform;
	public Transform cursorTransform;

	public float smoothTime = 2f;
	private Vector3 velocity;

	void LateUpdate ()
	{
		if (playerTransform == null)
		{
			return;
		}

		Vector3 targetPosition = (playerTransform.position + cursorTransform.position) * 0.5f;

		transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, Time.deltaTime * smoothTime);
	}
}
