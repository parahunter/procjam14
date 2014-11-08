using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MNode
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

	public abstract GameObject GetPrefab();

	public static void SpawnMorphology(MNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier, GameObject parent = null)
	{
		MNode thisNode = rootNode;
		GameObject thisGo = (GameObject)GameObject.Instantiate(rootNode.GetPrefab(), pos, Quaternion.identity);

		thisGo.transform.localScale = new Vector3(rootNode.scale.x * scaleModifier.x,
												  rootNode.scale.y * scaleModifier.y,
												  rootNode.scale.z * scaleModifier.z);
		              
		if(parent != null)
		{
			thisGo.GetComponent<Appendage>().Attach(parent.transform, pos, rot);
		}

		foreach(MConnection mc in thisNode.connections)
		{
			int inverse = mc.reflection ? -1 : 1;
			
			Vector3 scaleFactor = new Vector3(scaleModifier.x * mc.scaleModifier.x,
											  scaleModifier.y * mc.scaleModifier.y,
											  scaleModifier.z * mc.scaleModifier.z);
			
			//If target is itself add one to iterations var. If more than recursivelimit spawn the terminalNode if != null
			if(mc.target == rootNode)			
			{
				if(rootNode.iterations < rootNode.recursiveLimit)
				{
					rootNode.iterations++;
					MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, scaleFactor*inverse, thisGo);
				}
				else if(mc.terminalNode != null)
				{
					MNode.SpawnMorphology(mc.terminalNode, mc.position, mc.rotation, scaleFactor*inverse, thisGo);
				}
			}
			else
			{
				MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, scaleFactor*inverse, thisGo);
			}
		}
	}




}
