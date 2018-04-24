using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(UnitRef))]
public class UnitRefEditor : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		UnitRef unitPreset = (UnitRef)target;

		EditorGUILayout.Space ();
		GUILayout.Label ("Size", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal ();

		if (unitPreset.agentType == 0)
		{
			GUILayout.Label ("Tiny", EditorStyles.boldLabel);
		}
		else
		{
			if (GUILayout.Button ("Tiny"))
			{
				unitPreset.agentType = 0;
				unitPreset.colliderRadius = 0.1f;
			}
		}
		if (unitPreset.agentType == -334000983)
		{
			GUILayout.Label ("Small", EditorStyles.boldLabel);
		}
		else
		{
			if (GUILayout.Button ("Small"))
			{
				unitPreset.agentType = -334000983;
				unitPreset.colliderRadius = 0.35f;
			}
		}
		if (unitPreset.agentType == 1479372276)
		{
			GUILayout.Label ("Medium", EditorStyles.boldLabel);
		}
		else
		{
			if (GUILayout.Button ("Medium"))
			{
				unitPreset.agentType = 1479372276;
				unitPreset.colliderRadius = 0.6f;
			}
		}
		if (unitPreset.agentType == -1923039037)
		{
			GUILayout.Label ("Large", EditorStyles.boldLabel);
		}
		else
		{
			if (GUILayout.Button ("Large"))
			{
				unitPreset.agentType = -1923039037;
				unitPreset.colliderRadius = 0.8f;
			}
		}
		if (unitPreset.agentType == -902729914)
		{
			GUILayout.Label ("Huge", EditorStyles.boldLabel);
		}
		else
		{
			if (GUILayout.Button ("Huge"))
			{
				unitPreset.agentType = -902729914;
				unitPreset.colliderRadius = 1.2f;
			}
		}

		GUILayout.EndHorizontal ();
	}

}
