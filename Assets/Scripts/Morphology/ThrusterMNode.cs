using UnityEngine;
using System.Collections;

public class ThrusterMNode : MNode 
{
	int button;
	
	public ThrusterMNode(Vector3 _scale, GNode myGnode, int recursionLimit, int button) : base(_scale, myGnode, recursionLimit)
	{
		this.button = button;
	}
	
	public override void ConfigureAppendage (Appendage appendage)
	{
		appendage.buttonOrAxis = button;
	}
	
	public override GameObject GetPrefab ()
	{
		return PrefabContainer.instance.ThrusterAppendage;
	}

	public override MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter)
	{
		return new ThrusterMNode(scale, myGNode, recursionCounter, button);
	}
}
