using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BlockFall : MonoBehaviour {
	public Rigidbody2D BlockRigidbody;
	public float MaxGravityScale;
	public float ScaleChangeDuration;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.layer == 9) {
			BlockRigidbody.isKinematic = false;
			StartCoroutine(ChangeGravityScale());
		}
	}

	IEnumerator ChangeGravityScale() {
		float startTime = Time.time;
		float t = 0;

		while (Time.time - startTime < ScaleChangeDuration) {
			t = (Time.time - startTime) / ScaleChangeDuration;
			BlockRigidbody.gravityScale = Mathf.SmoothStep(0, MaxGravityScale, t);
			yield return null;
		}
	}
}
