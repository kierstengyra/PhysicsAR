using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AnchorTarget : ImageTargetBehaviour {

	[SerializeField] private GameObject stepUI;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnTrackerUpdate(Status newStatus) {
		base.OnTrackerUpdate (newStatus);

		if (newStatus == Status.TRACKED) {
			Parameters textParameter = new Parameters ();
			textParameter.PutExtra ("DISPLAY_TEXT", "Scanned! Now scan the second image target.");
			EventBroadcaster.Instance.PostEvent (EventNames.ARPhysics_Events.ON_ANCHOR_TARGET_SCAN, textParameter);
		}
	}
}
