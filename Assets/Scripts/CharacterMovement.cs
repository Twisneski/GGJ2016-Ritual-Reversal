using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float Force;
	public float MaxGroundedVelocity;
	public float MaxFloatingVelocity;
	private Vector2 ForceVector;
	public float JumpForce;
	public bool IsMoving;
	public bool IsClimbing;
	public bool IsWallAhead;
	public bool IsWallLeft;
	public bool IsWallRight;
	public bool IsGrounded;
	public bool IsDead;
	public Rigidbody2D CharacterRigidbody;
	private bool Jump;
	public float GroundCheckDistance;
	public float WallCheckDistance;
	public Transform GroundCheckLeft;
	public Transform GroundCheckRight;
	public Transform WallCheckRightBottom;
	public Transform WallCheckLeftBottom;
	public Transform WallCheckRightTop;
	public Transform WallCheckLeftTop;
	public SpriteRenderer CharacterSprite;
	public Animator CharacterAnimator;
	
	/*void Start() {
		CharacterAnimator.SetBool("Grounded" true);
	}*/

	// Update is called once per frame
	void Update () {
		IsGrounded = CheckGrounded();
		IsWallLeft = CheckWallLeft();
		IsWallRight = CheckWallRight();
		IsWallAhead = IsWallLeft || IsWallRight;
		CheckMoveInput();
		SetAnimationVariables();
	}

	void FixedUpdate() {

		if (IsMoving && !IsDead) {
			MoveCharacter();
		}
	}

	private void SetAnimationVariables() {
		if (IsMoving) {
			CharacterAnimator.SetBool("Moving", true);
		}
		else {
			CharacterAnimator.SetBool("Moving", false);
		}

		if (IsGrounded) {
			CharacterAnimator.SetBool("Grounded", true);
		}
		else if (IsClimbing) {
			CharacterAnimator.SetBool("Grounded", false);
		}
		else {
			CharacterAnimator.SetBool("Grounded", false);
		}
	}

	private void CheckMoveInput() {
		if (!IsDead && Input.GetKey(KeyCode.A)) {
			IsMoving = true;
			if (!IsWallLeft) {
				ForceVector = new Vector2(-Force, 0);
				if (IsClimbing) {
					IsClimbing = false;
					CharacterRigidbody.gravityScale = 2;
				}
			}
			else {
				IsClimbing = true;
			}
			CharacterSprite.flipX = false;
		}
		else if (!IsDead && Input.GetKey(KeyCode.D)) {
			IsMoving = true;
			if (!IsWallRight) {
				ForceVector = new Vector2(Force, 0);
				if (IsClimbing) {
					IsClimbing = false;
					CharacterRigidbody.gravityScale = 2;
				}

			}
			else {
				IsClimbing = true;
			}
			CharacterSprite.flipX = true;
		}
		else {
			IsMoving = false;
			IsClimbing = false;
			CharacterRigidbody.gravityScale = 2;
		}

		if (IsGrounded && Input.GetKeyDown(KeyCode.Space)) {
			Jump = true;
			if (IsMoving) {
				ForceVector.y = JumpForce;
			}
			else {
				ForceVector = new Vector2(0, JumpForce);
				IsMoving = true;
			}
		}
		if (IsWallAhead && IsClimbing) {
			if (Input.GetKey(KeyCode.W)) {
				CharacterRigidbody.gravityScale = 2;
				ForceVector = new Vector2(0, Force);
			}
			else if (Input.GetKey(KeyCode.S)) {
				CharacterRigidbody.gravityScale = 2;
				ForceVector = new Vector2(0, -Force/2);
			}
			else {
				CharacterRigidbody.gravityScale = 0;
				CharacterRigidbody.velocity = Vector2.zero;
				ForceVector = Vector2.zero;
			}
		}
	}

	private void MoveCharacter() {
		if(!Jump && IsGrounded && Mathf.Abs(CharacterRigidbody.velocity.x) < MaxGroundedVelocity) {
			CharacterRigidbody.AddForce(ForceVector);
		}
		else if(!IsGrounded && Mathf.Abs(CharacterRigidbody.velocity.x) < MaxFloatingVelocity) {
			CharacterRigidbody.AddForce(ForceVector);
		}
		else if (Jump) {
			Jump = false;
			CharacterRigidbody.AddForce(ForceVector);
		}
	}

	private bool CheckGrounded() {
		return (Physics2D.Raycast(GroundCheckRight.position, Vector2.down, GroundCheckDistance, 1<<8) || Physics2D.Raycast(GroundCheckLeft.position, Vector2.down, GroundCheckDistance, 1 << 8));
	}

	private bool CheckWall() {
		return CheckWallLeft() || CheckWallRight();
	}
	private bool CheckWallRight() {
		return Physics2D.Raycast(WallCheckRightBottom.position, Vector2.right, WallCheckDistance, 1 << 8) || Physics2D.Raycast(WallCheckRightTop.position, Vector2.right, WallCheckDistance, 1 << 8);
    }

	private bool CheckWallLeft() {
		return Physics2D.Raycast(WallCheckLeftBottom.position, Vector2.left, WallCheckDistance, 1 << 8) || Physics2D.Raycast(WallCheckLeftTop.position, Vector2.left, WallCheckDistance, 1 << 8);
	}

	public void KillPlayer() {
		IsDead = true;
		CharacterAnimator.SetTrigger("Dead");
	}
}
