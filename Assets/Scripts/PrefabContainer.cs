using UnityEngine;
using System.Collections;

public class PrefabContainer : MonoBehaviour 
{
	public GameObject ThrusterPrefab;
	public GameObject BoxPrefab;
	
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
