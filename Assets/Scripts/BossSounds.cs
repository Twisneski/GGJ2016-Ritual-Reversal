using UnityEngine;
using System.Collections;

public class BossSounds : MonoBehaviour {
	public float OrbTipDelay;
	public bool PlayedOrbTip;
	public AudioSource OrbTipAudio;
	public Transform CameraTransform;
	public float ShakeDuration;
	public float ShakeSpeed;
	public float ShakeRange;
	public float CameraReturnDelta;

	public float WatchOutForFireDelay;
	public bool PlayedWatchOutForFire;
	public AudioSource WatchOutForFireAudio;

	public float TauntDelay;
	public bool PlayedTaunt;
	public AudioSource TauntAudio;

	public bool PlayedDamage;
	public AudioSource DamageAudio;

	public bool PlayedVictory;
	public AudioSource VictoryAudio;

	private float StartTime;

	public int NumberOfOrbsCaught;

	public int NumberOfOrbsToCatch;
	public FistMovement Left;
	public FistMovement Right;

	// Use this for initialization
	void Start () {
		StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		PlayDelayedSounds();
	}

	private void PlayDelayedSounds() {
		if (!PlayedTaunt && Time.time - StartTime > TauntDelay) {
			TauntAudio.Play();
			PlayedTaunt = true;
		}

		if (!PlayedOrbTip && Time.time - StartTime > OrbTipDelay) {
			OrbTipAudio.Play();
			PlayedOrbTip = true;
		}

		if (!PlayedWatchOutForFire && Time.time - StartTime > WatchOutForFireDelay) {
			WatchOutForFireAudio.Play();
			PlayedWatchOutForFire = true;
		}
	}

	public void OrbCaught() {
		if (!PlayedDamage) {
			PlayDamageAudio();
		}

		++NumberOfOrbsCaught;
		if(!PlayedVictory && NumberOfOrbsCaught >= NumberOfOrbsToCatch) {
			PlayVictory();
			PlayedVictory = true;
		}
		if (NumberOfOrbsCaught <= NumberOfOrbsToCatch) {
			StartCoroutine(CameraShake());
		}
	}

	public void PlayDamageAudio() {
		PlayedDamage = true;
		DamageAudio.Play();
	}

	public void PlayVictory() {
		PlayedVictory = true;
		VictoryAudio.Play();
		Left.MoveHands = false;
		Right.MoveHands = false;
	}

	IEnumerator CameraShake() {
		float originalY = CameraTransform.position.y;
		float shakeStartTime = Time.time;
		while(Time.time - shakeStartTime < ShakeDuration) {
			CameraTransform.position = new Vector3(CameraTransform.position.x, CameraTransform.position.y + Mathf.Sin(Time.time * ShakeSpeed) * ShakeRange, CameraTransform.position.z);
			yield return null;
		}

		while(!Mathf.Approximately(CameraTransform.position.y, originalY)) {
			CameraTransform.position = Vector3.MoveTowards(CameraTransform.position, new Vector3(CameraTransform.position.x, originalY, CameraTransform.position.z), CameraReturnDelta);
			yield return null;
		}

	}
}
