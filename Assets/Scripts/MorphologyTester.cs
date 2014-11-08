using UnityEngine;
using System.Collections;

public class MorphologyTester : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start()
	{
		//Defining a Morphology tree manually using Nodes and Connections
		MNode body = new MNode(Vector3.one, 2);
		MNode limb = new MNode(new Vector3(5, 0.5f, 0.5f), 1);
		body.AddConnection(new MConnection(limb, Vector3.one, Quaternion.Euler(Vector3.up * 45), Vector3.one, false));
		body.AddConnection(new MConnection(body, Vector3.forward, Quaternion.Euler(Vector3.up * 10), Vector3.one*0.5f, false, limb));
		
		//Spawn the tree0
		MNode.SpawnMorphology(body, Vector3.zero, Quaternion.identity, Vector3.one, prefab);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
