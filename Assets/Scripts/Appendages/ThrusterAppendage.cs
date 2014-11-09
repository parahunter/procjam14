using UnityEngine;
using System.Collections;

public class ThrusterAppendage : Appendage
{
	public float baseForce = 50;
	
	bool keyDown = false;
	public ParticleSystem particles;
	
	float scale;
	
	// Use this for initialization
	void Start () 
	{
		AssignButton(OnKeyDown, OnKeyUp, buttonOrAxis);
		
		particles.enableEmission = false;
		scale = transform.lossyScale.x;
		particles.startSize = particles.startSize * scale;
	}
	
	void FixedUpdate()
	{
		if(keyDown)
			rigidbody.AddForce(-transform.forward * baseForce * scale);
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
