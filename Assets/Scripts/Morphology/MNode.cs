using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MNode
{
	//Morphology Node

	public Vector3 scale = Vector3.one;
	public List<MConnection> connections = new List<MConnection>();

	public MNode(Vector3 _scale)
	{
		scale = _scale;
	}

	public void AddConnection(MConnection c)
	{
		connections.Add(c);
	}

	public abstract GameObject GetPrefab();

	public static void SpawnMorphology(MNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier, int count, GameObject parent = null)
	{
		MNode thisNode = rootNode;
		GameObject thisGo = (GameObject)GameObject.Instantiate(rootNode.GetPrefab(), pos, Quaternion.identity);
		thisGo.name = count.ToString();

		thisGo.transform.localScale = new Vector3(rootNode.scale.x * scaleModifier.x,
												  rootNode.scale.y * scaleModifier.y,
												  rootNode.scale.z * scaleModifier.z);
		 
		              
		                                        
		if(parent != null)
		{
			parent.GetComponent<Appendage>().Attach(thisGo.transform, pos, rot);
		}
		
		foreach(MConnection mc in thisNode.connections)
		{	
			Vector3 scaleFactor = new Vector3(scaleModifier.x * mc.scaleModifier.x,
											  scaleModifier.y * mc.scaleModifier.y,
											  scaleModifier.z * mc.scaleModifier.z);
				
			//If target is itself add one to iterations var. If more than recursivelimit spawn the terminalNode if != null
			if(mc.target == rootNode)			
			{
				if(mc.iterations < mc.recursiveLimit)
				{
					mc.iterations++;
					count++;
					MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, scaleFactor, count, thisGo);
					
				}
				else if(mc.terminalNode != null)
				{
					count++;
					MNode.SpawnMorphology(mc.terminalNode, mc.position, mc.rotation, scaleFactor, count, thisGo);
				}
			}
			else
			{
				count++;
				MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, scaleFactor, count, thisGo);
			}
		}
		
	}




}
