using UnityEngine;
using System.Collections;

public class MorphologyTester : MonoBehaviour 
{
	// Use this for initialization
	void Start()
	{
		//Defining a Morphology tree manually using Nodes and Connections
		StaticGNode body = new StaticGNode(Vector3.one, 6);
		ThrusterGNode limb = new ThrusterGNode(new Vector3(0.5f, 0.5f, 0.5f), 1);
		
		body.AddConnection(new GConnection(body, Vector3.forward, Quaternion.Euler(Vector3.up * 30), Vector3.one*0.9f, true, 6, limb));
		body.AddConnection(new GConnection(body, Vector3.forward, Quaternion.Euler(Vector3.up * -30), Vector3.one*0.9f, true, 3));
		
		//Spawn the tree0
		MNode root = GNode.DefineMorphology(body, transform.position, Quaternion.identity, Vector3.one);
		
		print ("Success!");
		
		MNode.SpawnMorphology(root, transform.position, Quaternion.identity, Vector3.one);
		
	}
}
