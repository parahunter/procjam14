using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	public float horizontalSpeed = 5f;
	public float verticalSpeed = 5f;
	
	// Update is called once per frame
	void Update () 
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
			
		transform.Rotate(new Vector3(0, mouseX * horizontalSpeed * Time.deltaTime, 0), Space.World);
		transform.Rotate(new Vector3(mouseY * verticalSpeed * Time.deltaTime, 0, 0 ), Space.Self); 
	}
}
