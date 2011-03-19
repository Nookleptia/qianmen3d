using UnityEngine;
using System.Collections;
 
public class MouseClick : MonoBehaviour {

	public float rayLenght = 100;
    private Camera cam;
	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.Find("Camera");
        cam = obj.camera;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0))
		{	
			RaycastHit hit;
			
			// only forward the camera z-axis 
			// chanage this parameter
			// Construct a ray from the current mouse coordinates
            //Debug.Log(cam.name);
			Ray  ray = cam.ScreenPointToRay(Input.mousePosition);
			//Vector3  fwd = transform.TransformDirection (Vector3.forward);
			//Debug.Log(fwd);
			if (Physics.Raycast (ray.origin,ray.direction,out hit, rayLenght)) 
			{
				// decide whick object is clicked 
				if(hit.transform.name.Contains("Remote"))
				{		
					PlayerInfo  pi = hit.transform.GetComponent<PlayerInfo>();
					//Debug.Log("Name : "+pi.NameinServer);
                    GUIControl.objectUser = pi.NameinServer;
				}
				//else
                   // GUIControl.objectUser = "";
			}
		}	
	}
}
