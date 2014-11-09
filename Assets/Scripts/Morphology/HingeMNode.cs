using UnityEngine;
using System.Collections;

public class HingeMNode : MNode 
{
	int axis;	
	public HingeMNode(Vector3 _scale, GNode myGNode, int recursionCounter, int axis) : base(_scale, myGNode, recursionCounter)
	{
		this.axis = axis;
	}
	
	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.HingeAppendage;
	}
	
	public override void ConfigureAppendage (Appendage appendage)
	{
		appendage.buttonOrAxis = axis;
	}
	
	public override MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter)
	{
		return new HingeMNode(scale, myGNode, recursionCounter, axis);
	}
}
