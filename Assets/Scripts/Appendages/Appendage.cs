using UnityEngine;
using System.Collections;

public class Appendage : MonoBehaviour 
{

	public virtual void Attach(Transform child, Vector3 pos, Quaternion rot)
	{
		child.parent = transform;
		child.transform.localPosition = pos;
		child.transform.localRotation = rot;
		
		FixedJoint joint = gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = child.rigidbody;
	}
	
	protected void AssignButton(System.Action onButtonDown, System.Action onButtonUp, int button)
	{
		switch(button)
		{
			case 0:
				InputManager.instance.upKeyDown += onButtonDown;
				InputManager.instance.upKeyUp += onButtonUp;
				break;
			case 1:
				InputManager.instance.leftKeyDown += onButtonDown;
				InputManager.instance.leftKeyUp += onButtonUp;
				break;
			case 2:
				InputManager.instance.downKeyDown += onButtonDown;
				InputManager.instance.downKeyUp += onButtonUp;
				break;
			case 3:
				InputManager.instance.leftKeyDown += onButtonDown;
				InputManager.instance.leftKeyUp += onButtonUp;
				break;
			default:
				break;		
		}			
	}
	
	protected void AssignAxis(System.Action<float> callback, int axis)
	{
		switch(axis)
		{
			case 0:
				InputManager.instance.verticalAxis += callback;
				break;
			case 1:
				InputManager.instance.horizontalAxis += callback;
				break;
			default:
				break;
		}
	}
}
