using UnityEngine;
using System.Collections;

public class StaticGNode : GNode {
		
	public StaticGNode(Vector3 _scale) : base(_scale)
	{
		
	}
	
	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.StaticAppendage;
	}

	public override MNode CreateNode(Vector3 scale, GNode myGNode)
	{
		return new StaticMNode(scale, myGNode);
	}
	/*
	public override MNode CopyNode(MNode source)
	{
		return new StaticMNode(Vector3.one); // TEMP!!!
	}*/

}
