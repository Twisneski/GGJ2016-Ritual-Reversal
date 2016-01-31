using UnityEngine;
using System.Collections;

public class FistMovement : MonoBehaviour {
	public int maxSpeed;
	public GameObject prefab;
	private Vector3 startPosition;
	public float handOffset;
	public bool leftHand;
	public float normalX;
	public bool MoveHands;

	// Use this for initialization
	void Start() {
		maxSpeed = 1;
		MoveHands = true;
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update() {
		if (MoveHands) {
			MoveVertical();
		}
	}

	void MoveVertical() {
		transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed + handOffset) * 3f, transform.position.z);

		if (transform.localPosition.y < -2.75) {
			if (leftHand) {
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + new Vector3(0.5f, 0, 0), 0.1f);
			}
			else {
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition - new Vector3(0.5f, 0, 0), 0.1f);
			}
		}
		else {
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(normalX, transform.localPosition.y, transform.localPosition.z), 0.25f);
		}
	}

}
