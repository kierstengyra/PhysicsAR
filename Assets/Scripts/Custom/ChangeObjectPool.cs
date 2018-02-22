using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeObjectPool : MonoBehaviour {
	
	[SerializeField] private GameObject spherePool;
	[SerializeField] private GameObject capsulePool;
	[SerializeField] private GameObject discPool;

	// Use this for initialization
	void Start () {
		this.spherePool.SetActive (true);
		this.capsulePool.SetActive (false);
		this.discPool.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchPool() {
		string btnName = EventSystem.current.currentSelectedGameObject.name;

		switch (btnName) {
		case "Sphere":
			spherePool.SetActive (true);
			capsulePool.SetActive (false);
			discPool.SetActive (false);
			break;
		case "Capsule":
			spherePool.SetActive (false);
			capsulePool.SetActive (true);
			discPool.SetActive (false);
			break;
		case "Disc":
			spherePool.SetActive (false);
			capsulePool.SetActive (false);
			discPool.SetActive (true);
			break;
		}
	}
}
