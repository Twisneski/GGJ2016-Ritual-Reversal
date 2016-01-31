using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {

	public Transform[] SpawnPoint;
	public float spawnTime = 1.5f;

	public GameObject Orb;
	//public GameObject[] Orb;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnOrb", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnOrb()
	{
		int spawnIndex = Random.Range (0, SpawnPoint.Length);
		Instantiate (Orb, SpawnPoint [spawnIndex].position, SpawnPoint [spawnIndex].rotation);
	}
}
