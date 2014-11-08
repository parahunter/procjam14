using UnityEngine;
using System.Collections;

public class StaticMNode : MNode 
{
	
	public StaticMNode(Vector3 _scale, int _recursiveLimit) : base(_scale, _recursiveLimit)
	{
		
	}

	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.StaticAppendage;
	}
}
