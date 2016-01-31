using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour {
	public Animator CharacterAnimator;
	public AudioSource WalkingAudioSource;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckCharacterAction();
	}

	private void CheckCharacterAction() {

		if (CharacterAnimator.GetBool("Moving") && CharacterAnimator.GetBool("Grounded") && !WalkingAudioSource.isPlaying) {
			//Debug.Log("Play Sound");
			WalkingAudioSource.Play();
		}
		else if(!CharacterAnimator.GetBool("Moving") || !CharacterAnimator.GetBool("Grounded")){
			//Debug.Log("Do Not Play Sound");
			WalkingAudioSource.Stop();
		}

	}
}
