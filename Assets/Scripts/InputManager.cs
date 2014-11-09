using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public event System.Action upKeyDown;
	public event System.Action upKeyUp;
	
	public event System.Action rightKeyDown;
	public event System.Action rightKeyUp;
	
	public event System.Action downKeyDown;
	public event System.Action downKeyUp;
	
	public event System.Action leftKeyDown;
	public event System.Action leftKeyUp;
	
	public event System.Action<float> verticalAxis;
	public event System.Action<float> horizontalAxis;
    
	
	public static InputManager instance
	{
		get;
		private set;
	}
	
	
	void Awake()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Up") && upKeyDown != null)
			upKeyDown();
		if(Input.GetButtonUp("Up") && upKeyUp != null)
			upKeyUp();
		
		if(Input.GetButtonDown("Right") && rightKeyDown != null)
			rightKeyDown();
		if(Input.GetButtonUp("Right") && rightKeyUp != null)
			rightKeyUp();
			
		if(Input.GetButtonDown("Down") && downKeyDown != null)
			downKeyDown();
		if(Input.GetButtonUp("Down") && downKeyUp != null)
			downKeyUp();
		
		if(Input.GetButtonDown("Left") && leftKeyDown != null)
			leftKeyDown();
		if(Input.GetButtonUp("Left") && leftKeyUp != null)
			leftKeyUp();					 		 
		
		if(verticalAxis != null)
			verticalAxis( Input.GetAxis("Vertical") );
		
		if(horizontalAxis != null)
			horizontalAxis( Input.GetAxis("Horizontal") );		 		 					 		 					 		 			 		 					 		 					 		 
					 		 					 		 					 		 			 		 					 		 					 		 			 		 					 		 					 		 
	}
}
