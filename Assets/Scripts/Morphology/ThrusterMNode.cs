using UnityEngine;
using System.Collections;

public class ThrusterMNode : MNode 
{
	public ThrusterMNode(Vector3 _scale, GNode myGnode) : base(_scale)
	{
	
	}
	
	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.ThrusterAppendage;
	}

	public override MNode CreateNode(Vector3 scale, GNode myGNode)
	{
		return new StaticMNode(scale, myGNode);
	}
}
