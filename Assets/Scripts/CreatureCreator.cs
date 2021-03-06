﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreatureCreator : MonoBehaviour {

	public int seed;
	public bool autoSeed = true;
	public int minGNodes = 2;
	public int maxGNodes = 5;
	public float scaleRange = 1.5f;
	public float posRange = 3;
	public float rotRange = 90;
	public int[] recursionLimitRange = new int[] {0, 0, 0, 1, 1, 2, 3, 4};
	public int inputRange = 50; //'percentage'
	public int maxConnections = 3;
	public int terminalLimbRange = 50;
	public GameObject wintext;
	public InputField seedText;
	GameObject creature;

	// Use this for initialization
	void Start()
	{
		if(autoSeed) seed = Random.Range(0, int.MaxValue);
		SpawnCreature(seed);
		seedText.textComponent.text = seed.ToString();
		seedText.text = seed.ToString();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			Destroy(creature);
			InputManager.instance.cleanEvents();
			if(autoSeed) seed = Random.Range(0, int.MaxValue);
			SpawnCreature(seed);
			seedText.textComponent.text = seed.ToString();
			seedText.text = seed.ToString();
			wintext.SetActive(false);
		}
	}

	public void SpawnSeed(string s)
	{
		int thisSeed = int.Parse(s);

		Destroy(creature);
		InputManager.instance.cleanEvents();
		SpawnCreature(thisSeed);
		seedText.textComponent.text = thisSeed.ToString();
		seedText.text = thisSeed.ToString();
		wintext.SetActive(false);
	}

	void SpawnCreature(int seed)
	{
		List<GNode> dna = new List<GNode>();
		Random.seed = seed;

		int nodes = Random.Range(minGNodes, maxGNodes);
		int nodeType = 0; //the first is always staticGNode

		for(int i=0; i<nodes; i++)
		{
			//choose random scale and recursionLimit
			float ts = Random.Range(1.0f-scaleRange, 1.0f+scaleRange);
			Vector3 scale = new Vector3(ts, ts, ts);
			//Vector3 scale = new Vector3(1.0f-scaleRange, 1.0f-scaleRange, 1.0f-scaleRange);
			int recursionLimit = recursionLimitRange[Random.Range(0, recursionLimitRange.Length)];

			//choose if adding input listener
			int inputListener = 10; //to reach the default case in the input assigner

			//choose type (switch)
			switch(nodeType)
			{
				//create GNode
			case 0: //static
				dna.Add(new StaticGNode(scale, recursionLimit));
				break;

			case 1: //thruster
				if(Random.Range(0, 100) < inputRange)
					inputListener = Random.Range(0, 5); //choose int 0-4 to select an input button
				dna.Add(new ThrusterGNode(scale, recursionLimit, inputListener));
				break;

			case 2: //hinge
				if(Random.Range(0, 100) < inputRange)
					inputListener = Random.Range(0, 2); //choose int 0-1 to select an input axis
				dna.Add(new HingeGNode(scale, recursionLimit, inputListener));
				break;
			}

			nodeType = Random.Range(0, 3); //choosing the next nodeType
		}

		//choose how many connections for the first GNode
		int nConnections = Random.Range(1, maxConnections);

		//iterate list of nodes adding connections
		foreach(GNode gNode in dna)
		{
			//for loop
			for(int i=0; i<nConnections; i++)
			{
				//choose target among nodes list
				GNode target = dna[Random.Range(0, dna.Count)];
				//choose pos, rot, scale

				Vector3 pos = new Vector3(Random.Range(-posRange, posRange), Random.Range(-posRange, posRange), Random.Range(-posRange, posRange));
				Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(-rotRange, rotRange), Random.Range(-rotRange, rotRange), Random.Range(-rotRange, rotRange)));
				float ts = Random.Range(1.0f-scaleRange, 1.0f+scaleRange);
				Vector3 scale = new Vector3(ts, ts, ts);
				//Vector3 scale = new Vector3(1.0f-scaleRange, 1.0f-scaleRange, 1.0f-scaleRange);

				//choose if adding a terminal limb
				GNode terminalLimb = null;
				if(Random.Range(0, 100) < terminalLimbRange)
					terminalLimb = dna[Random.Range(0, dna.Count)];
					//choose terminar limb from nodes list

				//Add connection to this GNode
				gNode.AddConnection(new GConnection(target, pos, rot, scale, false, 0, terminalLimb));			                                  
			}

			//choose how many connections for the next GNode
			nConnections = Random.Range(0, maxConnections);
		}

		//Define morphology considering the first one is the root
		MNode.ResetKillSwitch();
		MNode root = GNode.DefineMorphology(dna[0], transform.position, Quaternion.identity, Vector3.one);
		//Spawn morphology				
		creature = MNode.SpawnMorphology(root, transform.position, Quaternion.identity, Vector3.one);
	}
}
