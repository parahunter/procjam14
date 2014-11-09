using UnityEngine;
using System.Collections;

public class ThrusterGNode : GNode 
{

	public ThrusterGNode(Vector3 _scale, int recursiveLimit) : base(_scale, recursiveLimit)
	{
		
	}
	

	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.ThrusterAppendage;
	}
	
	public override MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter)
	{
		return new ThrusterMNode(scale, myGNode, recursionCounter);
	}
}
