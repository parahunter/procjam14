using UnityEngine;
using System.Collections;

public class ThrusterGNode : GNode 
{
	int button;
	
	public ThrusterGNode(Vector3 _scale, int recursiveLimit, int button) : base(_scale, recursiveLimit)
	{
		this.button = button;
	}
	
	public override MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter)
	{
		return new ThrusterMNode(scale, myGNode, recursionCounter, button);
	}
}
