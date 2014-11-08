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
}
