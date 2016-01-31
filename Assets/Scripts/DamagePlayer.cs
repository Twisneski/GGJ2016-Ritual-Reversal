using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.layer == 9) {
			collision.gameObject.GetComponent<CharacterMovement>().KillPlayer();
		}
	}
}
