using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public event System.Action upKeyDown;
	public event System.Action upKeyUp;
	
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
		if(Input.GetKeyDown(KeyCode.UpArrow) && upKeyDown != null)
			upKeyDown();
			
		if(Input.GetKeyUp(KeyCode.UpArrow) && upKeyUp != null)
			upKeyUp();
		
		 
	}
}
