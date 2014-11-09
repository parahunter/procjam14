﻿using UnityEngine;
using System.Collections;

public class StaticMNode : MNode 
{
	
	public StaticMNode(Vector3 _scale, GNode myGNode) : base(_scale)
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
}
