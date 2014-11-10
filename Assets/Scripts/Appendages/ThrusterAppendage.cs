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
		particles.enableEmission = false;
		particles.startSize = particles.startSize * scale;
	}

	public override void SetScale(Vector3 newScale)
	{
		float scaleAverage = (newScale.x + newScale.y + newScale.z)/3;
		transform.localScale = new Vector3(scaleAverage, scaleAverage, scaleAverage);
		scale = transform.lossyScale.x;
	}

	void FixedUpdate()
	{
		if(keyDown)
			rigidbody.AddForce(-transform.up * baseForce * scale);
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

	public override void DoInputAssign()
	{
		AssignButton(OnKeyDown, OnKeyUp, buttonOrAxis);
	}
	
}
