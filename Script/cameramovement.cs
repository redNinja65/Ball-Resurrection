using UnityEngine;
using System.Collections;

public class cameramovement : MonoBehaviour {
	public float smooth = 0.5F;
	public float tiltAngle = 50.0F;

	void Update() {

			float tiltAroundZacce = Input.acceleration.x * tiltAngle;
		float tiltAroundZ = Input.GetAxis ("Horizontal") * tiltAngle;
		if ((Input.touchCount == 1)||(Input.acceleration.x >= 1f)) 
		{
			Touch touch = Input.GetTouch (0);	//first touch counted
			
			if (touch.position.x > Screen.width / 2) {
				tiltAroundZ = transform.position.x + 40;

			} else {
				tiltAroundZ = transform.position.x - 40;
			}
			if(Input.acceleration.z >=1f)
			{
				tiltAroundZ = transform.position.x - 40;
			}
		
		}
		Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);//camera rotation in starting
		Quaternion targetacce = Quaternion.Euler(0,0, tiltAroundZacce);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetacce, Time.deltaTime * smooth);

	
}
}
