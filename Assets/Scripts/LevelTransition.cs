using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {
	public string LevelName;

	void OnTriggerEnter2D(Collider2D other) {
		SceneManager.LoadScene(LevelName);
	}


}
