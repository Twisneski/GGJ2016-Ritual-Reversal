using UnityEngine;
using System.Collections;
using System;

public class RectTransformAdjuster : MonoBehaviour {

	public Vector3[] TargetPositions;
	public Vector2[] TargetWidths;
	public float[] Durations;
	public RectTransform myRectTransform;

	void Start() {
		if (myRectTransform == null) {
			myRectTransform = GetComponent<RectTransform>();
		}
	}

	public void StartMoveToIndex(int targetIndex, Action callWhenFinished) {
		//Debug.Log("StartMove");
		StartCoroutine(MoveToIndex(targetIndex, callWhenFinished));
	}

	public IEnumerator MoveToIndex(int targetIndex, Action callWhenFinished = null) {
		//Debug.Log("Coroutine");
		float startTime = Time.time;
		float t;
		Vector3 startPosition = myRectTransform.anchoredPosition;
		while(CompareVector3NoZ(myRectTransform.anchoredPosition, TargetPositions[targetIndex])){
			t = (Time.time - startTime)/Durations[targetIndex];
			myRectTransform.anchoredPosition = Vector3SmoothStep(startPosition, TargetPositions[targetIndex], t);
			yield return null;
		}

		if(callWhenFinished!=null){
			callWhenFinished();
		}
	}

	public static Vector3 Vector3SmoothStep(Vector3 initial, Vector3 target, float t){
		return new Vector3(Mathf.SmoothStep(initial.x, target.x, t), Mathf.SmoothStep(initial.y, target.y, t), Mathf.SmoothStep(initial.z, target.z, t));
	}

	public static bool CompareVector3NoZ(Vector3 lhs, Vector3 rhs) {
		return !Mathf.Approximately(lhs.x, rhs.x) || !Mathf.Approximately(lhs.y, rhs.y);
	}
}
