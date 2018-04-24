using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Dialog", menuName = "Scenario/New dialog", order = 37)]
public class DialogAsset : ScriptableObject {

	public List<DialogEvent> dialogEvents;
}
