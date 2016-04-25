using UnityEngine;
using System.Collections;

public class Paddlegame : MonoBehaviour {
	public float paddleSpeed=1f;
	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);	//creating a vector 3 at the same transform as our paddle is..it is acturally initialzing this vector 3 to paddle gameobject,it has no connection to the paddle gameobject
	
	void Update () 
	{
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);	//raw input gives the position directly to -1,0,1 not like increasing,now here transform.position depicts the current position of the gameobject through which this scrpit has been attached,so that's the funda..so transform.position is the current position of the paddle game object we want to move it hence we add the force which we will provide horizontally(a & d),and to inc.the speed as per user multiply the paddleSpeed


		if ((pausebutton.touchactive == true) && (pausebutton.tiltactive == false)) {

				if (Input.touchCount == 1) {
				Touch touch = Input.GetTouch (0);
			
				if (touch.position.x > Screen.width / 2) {
					xPos = transform.position.x + paddleSpeed;
				} else {
					xPos = transform.position.x - paddleSpeed;
				}
				//xPos = -7.5f + 15 * touch.position.x/Screen.width;
			
			}
		}
			playerPos = new Vector3 (Mathf.Clamp (xPos, -75f, 72f), -9.8f, 0f);//Mathf.Clamp is actually restricting the playerPos (xPos) here,that in x direction it will have value b/w -8f and 8f only..so it will not move crossing the game scene,and at y and z we know where the paddle is so placing this vector 3 there only
			transform.position = playerPos;//now connecting the playerPos,vector 3(i.e. its transform ) too transform(i.e. game object Paddle as script is attached to it only).position(x,y,z)
		
	}











//		playerPos = new Vector3 (Mathf.Clamp(xPos, -10f, 10f), -9.8f, 0f);//Mathf.Clamp is actually restricting the playerPos (xPos) here,that in x direction it will have value b/w -8f and 8f only..so it will not move crossing the game scene,and at y and z we know where the paddle is so placing this vector 3 there only
//		transform.position = playerPos;//now connecting the playerPos,vector 3(i.e. its transform ) too transform(i.e. game object Paddle as script is attached to it only).position(x,y,z)
//	}
}
