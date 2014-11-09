﻿using UnityEngine;
using System.Collections;

public class MorphologyTester : MonoBehaviour 
{
	// Use this for initialization
	void Start()
	{
		//Defining a Morphology tree manually using Nodes and Connections
		StaticMNode body = new StaticMNode(Vector3.one);
		ThrusterMNode limb = new ThrusterMNode(new Vector3(0.5f, 0.5f, 0.5f));
		body.AddConnection(new MConnection(limb, Vector3.left, Quaternion.Euler(Vector3.up * 45), Vector3.one, true, 1));
		body.AddConnection(new MConnection(limb, Vector3.right, Quaternion.Euler(Vector3.up * -45), Vector3.one, false, 1));
		
		body.AddConnection(new MConnection(body, Vector3.forward, Quaternion.Euler(Vector3.zero), Vector3.one*0.8f, true, 4));
		//body.AddConnection(new MConnection(body, Vector3.forward, Quaternion.Euler(Vector3.left * 40), Vector3.one*0.8f, true, 6));
		
		
		//Spawn the tree0
		MNode.SpawnMorphology(body, transform.position, Quaternion.identity, Vector3.one, 0);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
