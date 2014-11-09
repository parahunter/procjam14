using UnityEngine;
using System.Collections;

public class ThrusterAppendage : Appendage
{
	public int button = 0;
	
	public float baseForce = 50;
	
	bool keyDown = false;
	public ParticleSystem particles;
			
	// Use this for initialization
	void Start () 
	{
		AssignButton(OnKeyDown, OnKeyUp, button);
		
		particles.enableEmission = false;
	}
	
	void FixedUpdate()
	{
		if(keyDown)
			rigidbody.AddForce(-transform.forward * baseForce);
	}
	
	void OnKeyDown()
	{
		keyDown = true;
		particles.enableEmission = true;
	}
	
	void OnKeyUp()
	{
		keyDown = false;
		particles.enableEmission = false;
	}
	
	
}
