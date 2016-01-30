using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float Force;
	public float MaxGroundedVelocity;
	public float MaxFloatingVelocity;
	private Vector2 ForceVector;
	public float JumpForce;
	public bool IsMoving;
	public bool Grounded;
	public Rigidbody2D CharacterRigidbody;
	private bool Jump;
	public float GroundCheckDistance;
	
	// Update is called once per frame
	void Update () {
		CheckMoveInput();
	}

	void FixedUpdate() {
		Grounded = CheckGrounded();

		if (IsMoving) {
			MoveCharacter();
		}
	}

	private void CheckMoveInput() {
		if (Input.GetKey(KeyCode.A)) {
			IsMoving = true;
			ForceVector = new Vector2(-Force, 0);
		}
		else if (Input.GetKey(KeyCode.D)) {
			IsMoving = true;
			ForceVector = new Vector2(Force, 0);
		}
		else {
			IsMoving = false;
		}

		if (Grounded && Input.GetKeyDown(KeyCode.Space)) {
			Jump = true;
			if (IsMoving) {
				ForceVector.y = JumpForce;
			}
			else {
				ForceVector = new Vector2(0, JumpForce);
				IsMoving = true;
			}
		}
	}

	private void MoveCharacter() {
		if(!Jump && Grounded && CharacterRigidbody.velocity.magnitude < MaxGroundedVelocity) {
			CharacterRigidbody.AddForce(ForceVector);
		}
		else if(!Grounded && CharacterRigidbody.velocity.magnitude < MaxFloatingVelocity) {
			CharacterRigidbody.AddForce(ForceVector);
		}
		else if (Jump) {
			Jump = false;
			CharacterRigidbody.AddForce(ForceVector);
		}
	}

	private bool CheckGrounded() {
		return (Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, 1<<8) || Physics2D.Raycast(transform.position - new Vector3(0.25f, 0), Vector2.down, GroundCheckDistance, 1 << 8) || Physics2D.Raycast(transform.position + new Vector3(0.25f, 0), Vector2.down, GroundCheckDistance, 1 << 8));
	}
}
