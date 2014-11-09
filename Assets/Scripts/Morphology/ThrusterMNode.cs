﻿using UnityEngine;
using System.Collections;

public class ThrusterMNode : MNode 
{
	public ThrusterMNode(Vector3 _scale, GNode myGnode, int recursionLimit) : base(_scale, myGnode, recursionLimit)
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
