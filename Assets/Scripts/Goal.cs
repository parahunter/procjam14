using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
	public event System.Action onPlayerReachedGoal;
	public GameObject text;
	
	void OnTriggerEnter(Collider other)
	{
		if(onPlayerReachedGoal != null)
			onPlayerReachedGoal();
				
		text.SetActive(true);
		
	}
	
}
