using UnityEngine;
using System.Collections;

public class Appendage : MonoBehaviour 
{

	public virtual void Attach(Transform parent, Vector3 pos, Quaternion rot)
	{
		transform.parent = parent.transform;
		transform.localPosition = pos;
		transform.localRotation = rot;
		
		FixedJoint joint = gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = parent.rigidbody;
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
}
