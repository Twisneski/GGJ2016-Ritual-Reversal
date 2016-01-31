using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class SoundTrigger : MonoBehaviour {
	public AudioSource ClipToTrigger;
	public bool PlayedBefore;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (!PlayedBefore && other.gameObject.layer == 9) {
			PlayedBefore = true;
			ClipToTrigger.Play();
		}
	}
}
