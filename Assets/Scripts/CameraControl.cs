using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public Transform FollowTarget;
	public float XFollowDistance;
	public float YFollowDistance;
	public float YFloor;
	public float YLookDistance;
	public float DistanceDelta;

	void FixedUpdate () {
		if (CheckTargetDistance()) {
			MoveTowardsTarget();
		}
	}

	private bool CheckTargetDistance() {
		Vector2 targetVector = FollowTarget.position - transform.position;
		float distanceToTarget = targetVector.magnitude;
		return distanceToTarget > XFollowDistance || distanceToTarget > YFollowDistance;
	}

	private void MoveTowardsTarget() {
		Vector3 targetPositionNoZ = FollowTarget.position;
		targetPositionNoZ.z = -10;
		if(targetPositionNoZ.y < YFloor) {
			targetPositionNoZ.y = YFloor;
		}
		transform.position = Vector3.MoveTowards(transform.position, targetPositionNoZ, DistanceDelta);
	}

	private void CheckLookInput() {

	}

	private void Look() {

	}



}
