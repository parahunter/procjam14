using UnityEngine;
using System.Collections;

public class HingeAppendage : Appendage 
{
	public HingeJoint joint;
	
	public int axis = 0;
	float input;
	public float motorForce = 500;
	public float motorTargetVelocity = 10;
	float scale;
	
	void Start()
	{
		AssignAxis(OnInput, axis);
		scale = transform.lossyScale.x;
	}
	
	public override void Attach (Transform child, Vector3 pos, Quaternion rot)
	{
		child.parent = joint.transform;
		child.localPosition = pos;
		child.localRotation = rot;
	
		FixedJoint fixedJoint = joint.gameObject.AddComponent<FixedJoint>();
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
	
}
