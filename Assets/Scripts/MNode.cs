using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MNode
{
	//Morphology Node

	public Vector3 scale = Vector3.one;
	public int recursiveLimit = 0; //How many times the node can spawn itself
	public List<MConnection> connections = new List<MConnection>();

	public int iterations = 0;

	public MNode(Vector3 s, int rl)
	{
		scale = s;
		recursiveLimit = rl;
	}

	public void AddConnection(MConnection c)
	{
		connections.Add(c);
	}

	public static void SpawnMorphology(MNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier, GameObject prefab, GameObject parent = null)
	{
		MNode thisNode = rootNode;
		GameObject thisGo = (GameObject)GameObject.Instantiate(prefab, pos, Quaternion.identity);
		thisGo.transform.localScale = rootNode.scale; //ToDo apply reflection and scaleModifier

		if(parent != null)
		{
			thisGo.transform.parent = parent.transform;
			thisGo.transform.localRotation = rot;
		}

		foreach(MConnection mc in thisNode.connections)
		{
			//If target is itself add one to iterations var. If more than recursivelimit spawn the terminalNode if != null
			MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, mc.scaleModifier, prefab, thisGo);
		}
	}




}
