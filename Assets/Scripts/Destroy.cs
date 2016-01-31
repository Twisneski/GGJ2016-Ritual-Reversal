using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float destroyTime = 4.5f;

	// Use this for initialization
	void Start () {
	
		Destroy (gameObject, destroyTime);
	}

}
