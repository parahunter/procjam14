using UnityEngine;
using System.Collections;

public class MorphologyTester : MonoBehaviour 
{
	// Use this for initialization
	void Start()
	{
		//Defining a Morphology tree manually using Nodes and Connections
		StaticGNode body = new StaticGNode(Vector3.one, 6);
		HingeGNode Limb = new HingeGNode(Vector3.one, 10, 0);
		HingeGNode Limb2 = new HingeGNode(Vector3.one, 10, 0);
		ThrusterGNode thruster = new ThrusterGNode(Vector3.one * 2, 10, 3);
		ThrusterGNode thruster2 = new ThrusterGNode(Vector3.one * 2, 10, 1);
		
		body.AddConnection(new GConnection(body, Vector3.forward, Quaternion.Euler(Vector3.up * 0), Vector3.one*0.9f, true, 6));
		
		Limb.AddConnection(new GConnection(thruster, Vector3.forward, Quaternion.identity, Vector3.one, false, 3));
		
		Limb2.AddConnection(new GConnection(thruster2, Vector3.forward, Quaternion.identity, Vector3.one, false, 3));
	
		body.AddConnection(new GConnection(Limb, Vector3.left, Quaternion.Euler(Vector3.up * -90), Vector3.one*0.9f, true, 6));
		body.AddConnection(new GConnection(Limb2, Vector3.right, Quaternion.Euler(new Vector3(0, 90, 180)), Vector3.one*0.9f, true, 6));
		
		MNode root = GNode.DefineMorphology(body, transform.position, Quaternion.identity, Vector3.one);
		
		MNode.SpawnMorphology(root, transform.position, Quaternion.identity, Vector3.one);
		
	}
}
