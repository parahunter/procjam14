using UnityEngine;
using System.Collections;

public class StaticMNode : MNode 
{
	
	public StaticMNode(Vector3 _scale) : base(_scale)
	{
		
	}

	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.StaticAppendage;
	}
}
