using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public Transform TargetCamera;
	public float MoveRatio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FollowCamera();
	}

	private void FollowCamera() {
		Vector3 parallaxPosition = TargetCamera.position;
		parallaxPosition.z = 0;
		transform.position = parallaxPosition * MoveRatio;
	}
}
