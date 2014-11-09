using UnityEngine;
using System.Collections;

public class StaticMNode : MNode 
{
	
	public StaticMNode(Vector3 _scale, GNode myGNode, int recursionCounter) : base(_scale, myGNode, recursionCounter)
	{
		
	}
	
	public override void ConfigureAppendage (Appendage appendage)
	{
		
	}

	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.StaticAppendage;
	}

	public override MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter)
	{
		return new StaticMNode(scale, myGNode, recursionCounter);
	}
}
