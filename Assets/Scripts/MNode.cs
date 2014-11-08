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

	public MNode(Vector3 _scale, int _recursiveLimit)
	{
		scale = _scale;
		recursiveLimit = _recursiveLimit;
	}

	public void AddConnection(MConnection c)
	{
		connections.Add(c);
	}

	public static void SpawnMorphology(MNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier, GameObject prefab, GameObject parent = null)
	{
		MNode thisNode = rootNode;
		GameObject thisGo = (GameObject)GameObject.Instantiate(prefab, pos, Quaternion.identity);

		thisGo.transform.localScale = new Vector3(rootNode.scale.x * scaleModifier.x,
		                                          rootNode.scale.y * scaleModifier.y,
		                                          rootNode.scale.z * scaleModifier.z);

		if(parent != null)
		{
			thisGo.transform.parent = parent.transform;
			thisGo.transform.localPosition = pos;
			thisGo.transform.localRotation = rot;
		}

		foreach(MConnection mc in thisNode.connections)
		{
			int inverse = mc.reflection?-1:1;
			//If target is itself add one to iterations var. If more than recursivelimit spawn the terminalNode if != null
			if(mc.target == rootNode)			{

				if(rootNode.iterations < rootNode.recursiveLimit)
				{
					rootNode.iterations++;
					MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, mc.scaleModifier*inverse, prefab, thisGo);
				}
				else if(mc.terminalNode != null)
				{
					MNode.SpawnMorphology(mc.terminalNode, mc.position, mc.rotation, mc.scaleModifier*inverse, prefab, thisGo);
				}
			}
			else
			{
				MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, mc.scaleModifier*inverse, prefab, thisGo);
			}
		}
	}




}
