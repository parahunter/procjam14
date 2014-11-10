using UnityEngine;
using System.Collections;

public class HingeAppendage : Appendage 
{
	public HingeJoint joint;
	
	float input;
	public float motorForce = 500;
	public float motorTargetVelocity = 10;
	float scale;

	public Transform arm;
	public Transform armMesh;
	
	void Start()
	{

	}

	public override void SetScale(Vector3 newScale)
	{
		float scaleAverage = (newScale.x + newScale.y + newScale.z)/3;
		transform.localScale = new Vector3(scaleAverage, scaleAverage, scaleAverage);
		//armMesh.localScale = new Vector3(armMesh.localScale.x, armMesh.localScale.x, newScale.y);
		scale = transform.lossyScale.x;
	}

	public override void Attach (Transform child, Vector3 pos, Quaternion rot)
	{
		child.parent = joint.transform;
		//position is passed to surfacePointFinder as a local position of this appendage. It returns a point and a normal (Raycasthit info)
		RaycastHit surfacePoint = MTools.SurfacePoint(attachTarget.gameObject, pos);
		
		//Child is located at the surfacePoint position
		//child.transform.position = pos;
		child.transform.position = surfacePoint.point;
		
		//Rotation is the surfacePoint normal + the rotation defined in the node
		//child.transform.localRotation = rot;
		child.transform.up = surfacePoint.normal;
		child.transform.rotation *= rot;
	
		FixedJoint fixedJoint = joint.gameObject.AddComponent<FixedJoint>();
		//joint.enableCollision = true;
		fixedJoint.connectedBody = child.rigidbody;
		
	}
	
	void OnInput(float input)
	{
		this.input = input;
	}
	
	void FixedUpdate()
	{
		JointMotor motor = joint.motor;
		motor.force = Mathf.Abs( input ) * motorForce * scale;
		motor.targetVelocity = motorTargetVelocity * input;
		joint.motor = motor;
	}

	public override void DoInputAssign()
	{
		AssignAxis(OnInput, buttonOrAxis);
	}
	
}
