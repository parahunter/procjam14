using UnityEngine;
using System.Collections;

public class GConnection
{
	//A Morphology connections defines a connection between nodes.
	//Used when new nodes are spawned

	public GNode target;
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 scaleModifier;
	public bool reflection = false;
	public GNode terminalNode;
	public int recursiveLimit = 0; //How many times the node can spawn itself
	
	public GConnection(GNode _target, Vector3 _position, Quaternion _rotation, Vector3 _scaleModifier, bool _reflection, int recursiveLimit)
	{
		target = _target;
		position = _position;
		rotation = _rotation;
		scaleModifier = _scaleModifier;
		reflection = _reflection;
		terminalNode = null;
		this.recursiveLimit = recursiveLimit;
	}

	public GConnection(GNode _target, Vector3 _position, Quaternion _rotation, Vector3 _scaleModifier, bool _reflection, int recursiveLimit, GNode _terminalNode)
	{
		target = _target;
		position = _position;
		rotation = _rotation;
		scaleModifier = _scaleModifier;
		reflection = _reflection;
		this.recursiveLimit = recursiveLimit;
		
		terminalNode = _terminalNode;
	}
	
	
	public GConnection MakeCopy()
	{
		return new GConnection(target, -position, rotation, -scaleModifier, false, recursiveLimit);
	}


}
