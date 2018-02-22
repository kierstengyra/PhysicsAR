using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHandler : MonoBehaviour {

	private const float Y_COORD_THRESHOLD = -2.998f;
	[SerializeField] private List<Transform> fallableObjects;
	private Vector3[] originalPositions;

	[SerializeField] private GameObjectPool capsulePool;
	[SerializeField] private Transform spawnPlace;
	[SerializeField] private int spawnObjects = 5;
	private const float SPAWN_DELAY = 0.25f;
	private float ticks = 0.0f;

	// Use this for initialization
	void Start () {
		this.StoreOriginPositions();
		this.capsulePool.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < this.fallableObjects.Count; i++) {
			if (this.fallableObjects [i].localPosition.y <= Y_COORD_THRESHOLD) {
				this.ResetObject (i);
			}
		}

		this.ticks += Time.deltaTime;
		if (this.ticks >= SPAWN_DELAY) {
			this.ticks = 0.0f;

			APoolable[] objectList = this.capsulePool.RequestPoolableBatch (this.spawnObjects);

			for (int i = 0; i < objectList.Length; i++) {
				objectList [i].transform.position = this.spawnPlace.position;
			}
		}
	}

	private void StoreOriginPositions() {
		this.originalPositions = new Vector3[this.fallableObjects.Count];
		for (int i = 0; i < this.fallableObjects.Count; i++) {
			this.originalPositions [i] = this.fallableObjects [i].position;
		}
	}

	private void GetOriginPositions() {
		for (int i = 0; i < this.fallableObjects.Count; i++) {
			this.originalPositions [i] = this.fallableObjects [i].position;
		}
	}

	private void ResetObjects() {
		for (int i = 0; i < this.fallableObjects.Count; i++) {
			this.originalPositions [i] = this.fallableObjects [i].localPosition;
		}
	}

	private void ResetObject(int i) {
		this.fallableObjects [i].position = this.originalPositions [i];
		this.fallableObjects [i].GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
