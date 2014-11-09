using UnityEngine;
using System.Collections;

public class HingeGNode : GNode 
{
	public int axis;
	
	public HingeGNode(Vector3 _scale, int recursiveLimit, int axis) : base(_scale, recursiveLimit)
	{
		this.axis = axis;
	}
	
	public override MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter)
	{
		return new HingeMNode(scale, myGNode, recursionCounter, axis);
	}
}
