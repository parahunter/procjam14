using UnityEngine;
using System.Collections;

public class StaticAppendage : Appendage 
{
	public Transform mesh;

	public override void SetScale(Vector3 newScale)
	{
		mesh.transform.localScale = newScale;
	}
}
