using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyPhysicsScreen : MonoBehaviour {

	[SerializeField] private Text displayText;
	private bool firstScanSuccess = false;

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver (EventNames.ARPhysics_Events.ON_ANCHOR_TARGET_SCAN, this.OnFirstScan);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveObserver (EventNames.ARPhysics_Events.ON_ANCHOR_TARGET_SCAN);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnFirstScan(Parameters param) {
		if (!this.firstScanSuccess) {
			this.displayText.text = param.GetStringExtra("DISPLAY_TEXT", "/");
			this.firstScanSuccess = true;
		}
	}
}
