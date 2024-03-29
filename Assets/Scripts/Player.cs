using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed = 5.0f;
	public float rotSpeed = 90.0f;
	
	private float cameraRotationX = 0.0f;
	private Transform camera;
	private CharacterController controller;

	void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
		camera = gameObject.GetComponentInChildren<Camera>().transform;

	}

	void Update()
	{
		//Cursor Lock
		if (Input.GetMouseButtonDown(0))
			Cursor.lockState = CursorLockMode.Locked;
		else if (Input.GetKey(KeyCode.Escape))
			Cursor.lockState = CursorLockMode.None;

		//Keyboard Input
		controller.Move((Input.GetAxis("Horizontal") * 
				(moveSpeed * Time.deltaTime)) *
				transform.right);

		controller.Move((Input.GetAxis("Vertical") * 
				(moveSpeed * Time.deltaTime)) *
				transform.forward);

		//Mouse Input/Camera Rotation
		transform.Rotate(0, Input.GetAxis("Mouse X") * 
				(rotSpeed * Time.deltaTime), 0, Space.Self);

		cameraRotationX = Mathf.Clamp(cameraRotationX - 
				(Input.GetAxis("Mouse Y") * 
				(rotSpeed * Time.deltaTime)), -20, 20);
		
		camera.localRotation = Quaternion.AngleAxis(cameraRotationX,
				Vector3.right);

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, 
				camera.transform.forward, out hit, 5) &&
				hit.collider.gameObject.CompareTag("Enemy"))
			{
				Debug.Log("Target Eliminated");
				Destroy(hit.transform.gameObject);
			}
		}
	}
}
