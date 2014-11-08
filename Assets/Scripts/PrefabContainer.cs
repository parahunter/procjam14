using UnityEngine;
using System.Collections;

public class PrefabContainer : MonoBehaviour 
{
	public GameObject ThrusterAppendage;
	public GameObject StaticAppendage;
	
	public static PrefabContainer instance
	{
		get;
		private set;
	}
	
	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}
}
