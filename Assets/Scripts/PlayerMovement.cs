using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public bool isJumping = false; 
	public float speed = 1;
	public float longJump = 10;
	public float shortJump = 8;
	public float gravity = 15;
	public int money = 50;
	public Text countText;
	public Text loseText;

	private Vector3 moveDirection = Vector3.zero;

	void Start(){
		SetCountText ();
		loseText.text = " ";
	}


	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal")*2.5f, Input.GetAxis("Vertical"), 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("longJump"))
				startLongJump ();
			if (Input.GetButton ("shortJump"))
				startShortJump ();

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void startShortJump()
	{
		moveDirection.y = shortJump;
	}

	void startLongJump()
	{
		moveDirection.y = longJump;
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.CompareTag ("Enemy"))
		{
			money -= 5;
			SetCountText ();
			Destroy(other.gameObject);
		}

	}


	void SetCountText ()
	{
		countText.text = "$: " + money.ToString ();
		if (money <= 0)
		{
			loseText.text = "BANKRUPT";
		}
	}

}
