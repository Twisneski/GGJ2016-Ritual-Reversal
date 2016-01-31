using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DamagePlayer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.layer == 9) {
			collision.gameObject.GetComponent<CharacterMovement>().KillPlayer();
		}
	}
}
