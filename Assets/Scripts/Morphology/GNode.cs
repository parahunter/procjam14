using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GNode {

	//Morphology Node
	
	public Vector3 scale = Vector3.one;
	public List<GConnection> connections = new List<GConnection>();
	
	public GNode(Vector3 _scale)
	{
		scale = _scale;
	}
	
	public void AddConnection(GConnection c)
	{
		connections.Add(c);
	}
	
	public abstract GameObject GetPrefab();

	public abstract MNode CreateNode(Vector3 scale, GNode myGNode);

	public static MNode DefineMorphology(GNode rootNode, Vector3 pos, Quaternion rot, Vector3 scaleModifier)
	{
		//GNode firstNode = rootNode;
		MNode firstNode = rootNode.CreateNode(scaleModifier, rootNode);
		bool ready = false;

		List<MNode> createdNodes = new List<MNode>();
		List<MNode> newNodes = new List<MNode>();

		foreach(GConnection mc in rootNode.connections)
		{	
			Vector3 scaleFactor = new Vector3(scaleModifier.x * mc.scaleModifier.x,
			                                  scaleModifier.y * mc.scaleModifier.y,
			                                  scaleModifier.z * mc.scaleModifier.z);				
			
			//newNodes.Add(createMNodeWithConnections(mc, firstNode, scaleFactor));
			MConnection newMc = new MConnection(mc);
			newMc.scaleModifier = scaleFactor;
			firstNode.AddConnection(newMc);
		}

		while(!ready)
		{
			foreach(MNode thisNode in createdNodes)
			{
				foreach(MConnection mc in thisNode.connections)
				{	
					Vector3 scaleFactor = new Vector3(scaleModifier.x * mc.scaleModifier.x,
					                                  scaleModifier.y * mc.scaleModifier.y,
					                                  scaleModifier.z * mc.scaleModifier.z);

					newNodes.Add(createMNodeFromGConnections(mc, thisNode, thisNode.myGNode ,scaleFactor));
				}
			}

			if(newNodes.Count > 0)
			{
				createdNodes.Clear();
				createdNodes.AddRange(newNodes);
				ready = false;
			}
			else
			{
				ready = true;
			}
		}
		return firstNode;
	}


	static MNode createMNodeFromGConnections(MConnection mc, MNode thisNode, GNode template, Vector3 scaleFactor)
	{
		//Create a new node using a root MNode. Add connections according to the GNode definition
		MNode newNode = null;
		if(mc.target == thisNode)			
		{
			if(mc.recursiveLimit > 0)
			{
				newNode = thisNode.CreateNode(scaleFactor, template);
				foreach(MConnection rmc in thisNode.connections)
				{
					MConnection newConnection = rmc.MakeCopy();

					if(newConnection.target == thisNode) newConnection.recursiveLimit--;
					newConnection.target = newNode;
					newNode.AddConnection(newConnection);

				}
			}
			else if(mc.terminalNode != null)
			{
				newNode = mc.terminalNode.CreateNode(scaleFactor, template);
				foreach(GConnection rmc in template.connections)
				{
					MConnection newMc = new MConnection(rmc);
					newMc.target = newNode;
					newMc.scaleModifier = scaleFactor;
					newNode.AddConnection(newMc);
				}
				
			}
		}
		else
		{
			newNode = mc.target.CreateNode(scaleFactor, template);
			foreach(GConnection rmc in template.connections)
			{
				MConnection newMc = new MConnection(rmc);
				newMc.target = newNode;
				newMc.scaleModifier = scaleFactor;
				newNode.AddConnection(newMc);
			}
		}
		return newNode;
	}
}
