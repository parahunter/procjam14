using UnityEngine;
using System.Collections;

public class MConnection
{
	//A Morphology connections defines a connection between nodes.
	//Used when new nodes are spawned

	public MNode target;
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 scaleModifier;
	public bool reflection = false;
	public MNode terminalNode;

	public MConnection(MNode t, Vector3 pos, Quaternion rot, Vector3 sm, bool r)
	{
		target = t;
		position = pos;
		rotation = rot;
		scaleModifier = sm;
		reflection = r;
		terminalNode = null;
	}

	public MConnection(MNode t, Vector3 pos, Quaternion rot, Vector3 sm, bool r, MNode tn)
	{
		target = t;
		position = pos;
		rotation = rot;
		scaleModifier = sm;
		reflection = r;
		terminalNode = tn;
	}
}
