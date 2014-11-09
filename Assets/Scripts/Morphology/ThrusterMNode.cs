using UnityEngine;
using System.Collections;

public class ThrusterMNode : MNode 
{
	public ThrusterMNode(Vector3 _scale) : base(_scale)
	{
	
	}
	
	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.ThrusterAppendage;
	}
}
