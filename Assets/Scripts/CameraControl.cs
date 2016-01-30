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
		//Vector2 targetVector = FollowTarget.position - transform.position;
		float xDelta = Mathf.Abs(FollowTarget.position.x - transform.position.x);
		float yDelta = Mathf.Abs(FollowTarget.position.y - transform.position.y);
		//float distanceToTarget = targetVector.magnitude;
		return xDelta> XFollowDistance || yDelta > YFollowDistance;
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
