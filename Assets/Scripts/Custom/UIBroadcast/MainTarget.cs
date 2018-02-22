using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MainTarget : ImageTargetBehaviour {

	[SerializeField] private GameObject displayText;
	[SerializeField] private GameObject btnContainer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnTrackerUpdate(Status newStatus) {
		base.OnTrackerUpdate (newStatus);

		if (newStatus == Status.TRACKED) {
			this.displayText.SetActive (false);
			this.btnContainer.SetActive (true);
		}
	}
}
