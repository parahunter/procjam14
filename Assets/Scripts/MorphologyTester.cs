using UnityEngine;
using System.Collections;

public class MorphologyTester : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start()
	{
		//Defining a Morphology tree manually using Nodes and Connections
		MNode body = new MNode(Vector3.one, 2);
		MNode limb = new MNode(new Vector3(5, 1, 1), 1);
		body.AddConnection(new MConnection(limb, Vector3.one, Quaternion.Euler(Vector3.up * 45), Vector3.one, false));

		//Spawn the tree
		MNode.SpawnMorphology(body, Vector3.zero, Quaternion.identity, Vector3.one, prefab);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
