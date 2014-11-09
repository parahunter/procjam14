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
	public int recursiveLimit = 0; //How many times the node can spawn itself
	public bool defined = false;
	
	public MConnection(MNode _target, Vector3 _position, Quaternion _rotation, Vector3 _scaleModifier, bool _reflection, int recursiveLimit)
	{
		target = _target;
		position = _position;
		rotation = _rotation;
		scaleModifier = _scaleModifier;
		reflection = _reflection;
		terminalNode = null;
		this.recursiveLimit = recursiveLimit;
	}
	
	public MConnection MakeCopy()
	{
		return new MConnection(target, -position, rotation, -scaleModifier, false, recursiveLimit);
	}

	public MConnection(MNode _target, Vector3 _position, Quaternion _rotation, Vector3 _scaleModifier, bool _reflection, MNode _terminalNode)
	{
		target = _target;
		position = _position;
		rotation = _rotation;
		scaleModifier = _scaleModifier;
		reflection = _reflection;
		terminalNode = _terminalNode;
	}

	public MConnection(GConnection gc)
	{
		target = gc.target;
		position = gc.position;
		rotation = gc.rotation;
		scaleModifier = gc.scaleModifier;
		reflection = gc.reflection;
		terminalNode = gc.terminalNode;
		this.recursiveLimit = gc.recursiveLimit;
	}

}
