using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GNode 
{
	//Morphology Node
	
	public Vector3 scale = Vector3.one;
	public List<GConnection> connections = new List<GConnection>();
	public int recursiveLimit;
	
	public GNode(Vector3 _scale, int recursiveLimit)
	{
		scale = _scale;
		this.recursiveLimit = recursiveLimit;
	}
	
	public void AddConnection(GConnection c)
	{
		connections.Add(c);
	}
	
	public abstract GameObject GetPrefab();

	public abstract MNode CreateNode(Vector3 scale, GNode myGNode, int recursionCounter);

	public static MNode DefineMorphology(GNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier)
	{
		//GNode firstNode = rootNode;
		MNode firstNode = rootNode.CreateNode(scaleModifier, rootNode, 0);
		bool ready = false;

		List<MNode> nodesToIterateOn = new List<MNode>();
		//first node is put into list of nodes to itterate on
		nodesToIterateOn.Add( firstNode );
		
		//while theres nodes to iterate on
		while(nodesToIterateOn.Count > 0)
		{
			List<MNode> newNodes = new List<MNode>();

			//for each node to iterate on			
			foreach(MNode mNode in nodesToIterateOn)
			{
				//iterate over gconnections of the MNote's GNode templae
				foreach(GConnection gConnection in mNode.myGNode.connections)
				{
					Vector3 scale = new Vector3(mNode.scale.x * gConnection.scaleModifier.x,
					                            mNode.scale.y * gConnection.scaleModifier.y,
					                            mNode.scale.z * gConnection.scaleModifier.z);
					
					//if we have not hit recusion limit
					if(mNode.recursionCounter < mNode.myGNode.recursiveLimit)
					{
					                  
						//create new MNode from GConnection.target
						MNode node = gConnection.target.CreateNode(scale, gConnection.target, mNode.recursionCounter + 1);
						//create MConnection between current MNote and new MNote 
						mNode.AddConnection( new MConnection( gConnection, node ) );
						
						//put new MNote in list of nodes to iterate on
						newNodes.Add( node );
					}
					else if(gConnection.terminalNode != null)
					{
						//create new MNode from GConnection.target
						MNode node = gConnection.terminalNode.CreateNode(scale, gConnection.terminalNode, mNode.recursionCounter + 1);
						//create MConnection between current MNote and new MNote 
						mNode.AddConnection( new MConnection( gConnection, node ) );
						
					}
				}
			}
					
			//remove old nodes from list
			nodesToIterateOn.Clear();
			nodesToIterateOn.AddRange(newNodes);			
		}
		
		return firstNode;
	}


//	static MNode createMNodeFromGConnections(MConnection mc, MNode thisNode, GNode template, Vector3 scaleFactor)
//	{
//		//Create a new node using a root MNode. Add connections according to the GNode definition
//		MNode newNode = null;
//		if(mc.target == thisNode)			
//		{
//			if(mc.recursiveLimit > 0)
//			{
//				newNode = thisNode.CreateNode(scaleFactor, template);
//				foreach(MConnection rmc in thisNode.connections)
//				{
//					MConnection newConnection = rmc.MakeCopy();
//
//					if(newConnection.target == thisNode) newConnection.recursiveLimit--;
//					newConnection.target = newNode;
//					newNode.AddConnection(newConnection);
//
//				}
//			}
//			else if(mc.myGConnection.terminalNode != null)
//			{
//				newNode = mc.myGConnection.terminalNode.CreateNode(scaleFactor, template);
//				foreach(GConnection recursiveGConnection in template.connections)
//				{
//					MConnection newMc = new MConnection(recursiveGConnection);
//					newMc.target = newNode;
//					newMc.scaleModifier = scaleFactor;
//					newNode.AddConnection(newMc);
//				}
//				
//			}
//		}
//		else
//		{
//			newNode = mc.target.CreateNode(scaleFactor, template);
//			foreach(GConnection rmc in template.connections)
//			{
//				MConnection newMc = new MConnection(rmc);
//				newMc.target = newNode;
//				newMc.scaleModifier = scaleFactor;
//				newNode.AddConnection(newMc);
//			}
//		}
//		return newNode;
//	}
}
