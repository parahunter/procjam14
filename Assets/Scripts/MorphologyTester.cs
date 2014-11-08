using UnityEngine;
using System.Collections;

public class MorphologyTester : MonoBehaviour 
{
	// Use this for initialization
	void Start()
	{
		//Defining a Morphology tree manually using Nodes and Connections
		StaticMNode body = new StaticMNode(Vector3.one, 6);
		ThrusterMNode limb = new ThrusterMNode(new Vector3(5, 0.5f, 0.5f), 1);
		body.AddConnection(new MConnection(limb, Vector3.one, Quaternion.Euler(Vector3.up * 45), Vector3.one, false));
		body.AddConnection(new MConnection(body, Vector3.forward, Quaternion.Euler(Vector3.up * 10), Vector3.one*0.8f, false));
		
		//Spawn the tree0
		MNode.SpawnMorphology(body, transform.position, Quaternion.identity, Vector3.one);
	
	
		Debug.Break();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
