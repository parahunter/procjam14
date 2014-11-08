using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
	public event System.Action onPlayerReachedGoal;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(onPlayerReachedGoal != null)
				onPlayerReachedGoal();
		}
	}
	
}
