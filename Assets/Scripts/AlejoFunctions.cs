using UnityEngine;
using System.Collections;

public class AlejoFunctions : MonoBehaviour {

	public Transform handler;
	public Transform testSubject;
	public Transform child;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		child.position = SurfacePoint(testSubject.gameObject, handler.localPosition);
	
	}

	void PositionChildInSurface(GameObject child, GameObject parent, Vector3 anchor)
	{
		//parent.transform.GetChild[0];
	}


	Vector3 SurfacePoint(GameObject root, Vector3 anchor)
	{
		Collider thisCollider = root.GetComponent<Collider>();
		if(thisCollider != null)
		{
			anchor = root.transform.TransformPoint(anchor);
			Vector3 dir = anchor - root.transform.position;
			float rayMagnitude = 2 * root.transform.lossyScale.magnitude * (dir.magnitude + 2);
			//Vector3 origin = (anchor - dir) * rayMagnitude;
			Vector3 origin = anchor + dir * rayMagnitude;

			RaycastHit hitInfo;

			Debug.DrawRay(origin, -dir, Color.blue);
			if(thisCollider.Raycast(new Ray(origin, -dir), out hitInfo, 200))
			{
				return hitInfo.point;
			}
		}
		return Vector3.zero;
	}

}
