using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.R))
			Application.LoadLevel(0);
	}
}
