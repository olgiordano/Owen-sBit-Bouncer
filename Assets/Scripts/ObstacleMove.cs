using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {
	
	public float speed = 5.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public Transform explosionPrefab;


	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, -3);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
//			if (Input.GetButton("Jump"))
//				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		SelfDestruct ();

	}
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void SelfDestruct()
	{
		Destroy (gameObject, 7.5f);
	}
		
}
