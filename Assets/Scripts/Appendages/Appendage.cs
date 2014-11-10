using UnityEngine;
using System.Collections;

public class Appendage : MonoBehaviour 
{
	public int buttonOrAxis;	

	public virtual void DoInputAssign()
	{

	}

	public virtual void Attach(Transform child, Vector3 pos, Quaternion rot)
	{
		child.parent = transform;
		//position is passed to surfacePointFinder as a local position of this appendage. It returns a point and a normal (Raycasthit info)
		RaycastHit surfacePoint = MTools.SurfacePoint(this.gameObject, pos);

		//Child is located at the surfacePoint position
		child.transform.position = pos;
		//child.transform.localPosition = surfacePoint.point;

		//Rotation is the surfacePoint normal + the rotation defined in the node
		child.transform.localRotation = rot;
		//child.transform.up = -surfacePoint.normal;
		//child.transform.rotation *= rot;
		
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
				InputManager.instance.rightKeyDown += onButtonDown;
				InputManager.instance.rightKeyUp += onButtonUp;
				break;
			case 2:
				InputManager.instance.downKeyDown += onButtonDown;
				InputManager.instance.downKeyUp += onButtonUp;
				break;
			case 3:
				InputManager.instance.leftKeyDown += onButtonDown;
				InputManager.instance.leftKeyUp += onButtonUp;
				break;
			case 4:
				InputManager.instance.spaceKeyDown += onButtonDown;
				InputManager.instance.spaceKeyUp += onButtonUp;
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
