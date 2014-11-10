using UnityEngine;
using System.Collections;

public static class MTools
{
	public static RaycastHit SurfacePoint(GameObject target, Vector3 anchor)
	{
		Collider thisCollider = target.GetComponent<Collider>();
		if(thisCollider != null)
		{
			anchor = target.transform.TransformPoint(anchor);
			Vector3 dir = anchor - target.transform.position;
			float rayMagnitude = 2 * target.transform.lossyScale.magnitude * (dir.magnitude + 2);
			//Vector3 origin = (anchor - dir) * rayMagnitude;
			Vector3 origin = anchor + dir * rayMagnitude;
			
			//Debug.DrawRay(origin, -dir, Color.blue);
			
			RaycastHit hitInfo;
			if(thisCollider.Raycast(new Ray(origin, -dir), out hitInfo, 200))
			{
				return hitInfo;
			}
		}
		RaycastHit noInfo = new RaycastHit();
		noInfo.point = Vector3.zero;
		noInfo.normal = Vector3.zero;
		return noInfo;
	}
}