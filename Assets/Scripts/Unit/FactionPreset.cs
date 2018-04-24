using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewFaction", menuName = "Misc/Faction", order = 45)]
public class FactionPreset : ScriptableObject {

	public string layerName = "Faction";
	public LayerMask friendly;
	public LayerMask aggro;
	public LayerMask canHit;
	public LayerMask friendlyFire;

}
