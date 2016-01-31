using UnityEngine;
using System.Collections;

public class OrbPickup : MonoBehaviour {

	private BossSounds MainBossSounds;

	// Use this for initialization
	void Start () {
		MainBossSounds = GameObject.Find("SoundClips").GetComponent<BossSounds>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.layer == 9) {
			MainBossSounds.OrbCaught();
			Destroy(gameObject);
		}
	}
}
