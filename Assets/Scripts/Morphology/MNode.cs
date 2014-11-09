using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MNode
{
	//Morphology Node

	public Vector3 scale = Vector3.one;
	public List<MConnection> connections = new List<MConnection>();
	public GNode myGNode;

	public MNode(Vector3 _scale, GNode myGNode)
	{
		this.scale = _scale;
		this.myGNode = myGNode;
	}

	public void AddConnection(MConnection c)
	{
		connections.Add(c);
	}

	public abstract GameObject GetPrefab();

	public abstract MNode CreateNode(Vector3 scale, GNode myGnode);

	public static void SpawnMorphology(MNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier, GameObject parent = null)
	{
		GameObject thisGo = (GameObject)GameObject.Instantiate(rootNode.GetPrefab(), pos, Quaternion.identity);

		thisGo.transform.localScale = new Vector3(rootNode.scale.x * scaleModifier.x,
												  rootNode.scale.y * scaleModifier.y,
												  rootNode.scale.z * scaleModifier.z);	              
		                                        
		if(parent != null)
		{
			parent.GetComponent<Appendage>().Attach(thisGo.transform, pos, rot);
		}
		
		foreach(MConnection mc in rootNode.connections)
		{	
			Vector3 scaleFactor = new Vector3(scaleModifier.x * mc.scaleModifier.x,
											  scaleModifier.y * mc.scaleModifier.y,
											  scaleModifier.z * mc.scaleModifier.z);
				
			//If target is itself add one to iterations var. If more than recursivelimit spawn the terminalNode if != null
			if(mc.target != rootNode) //No recursion (self connections) allowed in Phenotype definition
			{
				MNode.SpawnMorphology(mc.target, mc.position, mc.rotation, scaleFactor, thisGo);
			}
		}
		
	}
}
