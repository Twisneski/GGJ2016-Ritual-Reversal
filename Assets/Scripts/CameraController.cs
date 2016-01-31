using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {
	public GameObject Player;               // Player gameobject. Can be set in inspector or found at runtime.
	public Transform PlayerTransform;       // Player transform. Same as above.
	public bool VerticalLock;               // Should vertical movement of the camera be locked?
	public bool HorizontalLock;             // Should horizontal movement of the camera be locked?
	public bool UseFloor;                   // Should the camera have a lower limit on movement?
	public bool UseCeiling;                 // Should the camera have an upper limit on movement?
	public float BottomLimit;               // Lowest point the camera should sit.
	public float TopLimit;                  // Highest point the camera should sit.
	public float XMaxOffset;
	public float YMaxOffset;
	private Transform CameraTransform;      // Shortcut reference to camera's transform. 
											//private Rigidbody CameraRigidbody;		// Shortcut reference to camera's rigidbody.
	private Vector3 MoveTarget;             // Where the camera should move towards.
	public bool ShouldMove;


	void Start() {
		if (Player == null) {
			Player = GameObject.FindWithTag("Player");
		}

		if (PlayerTransform == null) {
			PlayerTransform = Player.GetComponent<Transform>();
		}

		CameraTransform = GetComponent<Transform>();
		//CameraRigidbody = GetComponent<Rigidbody>();
		MoveTarget = CameraTransform.position;

	}

	void LateUpdate() {
		if (!VerticalLock && !HorizontalLock) {
			ShouldMove = CheckPlayerHorizontalPosition();
			ShouldMove = CheckPlayerVerticalPosition() || ShouldMove;
		}
		else if (!VerticalLock) {
			ShouldMove = CheckPlayerVerticalPosition();
		}
		else if (!HorizontalLock) {
			ShouldMove = CheckPlayerHorizontalPosition();
		}

		if (ShouldMove) {
			MoveCamera();
		}

	}

	private bool CheckPlayerHorizontalPosition() {
		//Debug.Log(CameraTransform.position.x - PlayerTransform.position.x);
		if (CameraTransform.position.x - PlayerTransform.position.x > XMaxOffset) {
			MoveTarget.x = PlayerTransform.position.x + XMaxOffset;
			return true;
		}
		else if (CameraTransform.position.x - PlayerTransform.position.x < -XMaxOffset) {
			MoveTarget.x = PlayerTransform.position.x - XMaxOffset;
			return true;
		}
		else {
			return false;
		}
	}

	private bool CheckPlayerVerticalPosition() {
		if (CameraTransform.position.y - PlayerTransform.position.y > YMaxOffset) {
			if (PlayerTransform.position.y + YMaxOffset > BottomLimit) {
				MoveTarget.y = PlayerTransform.position.y + YMaxOffset;
				return true;
			}
			else {
				return false;
			}
		}
		else if (CameraTransform.position.y - PlayerTransform.position.y < -YMaxOffset) {
			if (PlayerTransform.position.y - YMaxOffset > BottomLimit) {
				MoveTarget.y = PlayerTransform.position.y - YMaxOffset;
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}

	private void MoveCamera() {
		CameraTransform.position = Vector3.MoveTowards(CameraTransform.position, MoveTarget, 1);
		//CameraRigidbody.MovePosition(MoveTarget);
		//CameraRigidbody.AddForce((MoveTarget - CameraTransform.position));
		//CameraRigidbody.velocity = new Vector3(PlayerRigidbody.velocity.x, 0, 0);
	}
}
