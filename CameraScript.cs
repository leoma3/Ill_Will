using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	private Vector3 playerPos;

	public float camRangeX, camRangeY, camOffset;

	private float camX, camY;

	bool movingRight, movingUp;

	// Use this for initialization
	void Start () {

//		camRangeX = 0.5f;
//		camRangeY = 0.5f;

		camX = player.transform.position.x;
		camY = player.transform.position.y;

	
	}
	
	// Update is called once per frame
	void Update () {

		playerPos = player.transform.position;

		if ( Mathf.Abs (camX - playerPos.x) > camRangeX)
		{
			if (camX - playerPos.x > 0)
			{
				movingRight = false;
//				print ("is moving left");
			}
			else
			{
				movingRight = true;
//				print ("is moving right");
			}

			if (movingRight)
			{
				camX += (playerPos.x - camX) / 50;
			}

			else
			{
				camX += (playerPos.x - camX) / 50;
			}


			camX += (playerPos.x - camX) / 50;
		}

		if ( Mathf.Abs (camY - playerPos.y) > camRangeY)
		{
			camY += (playerPos.y - camY) / 50;
		}


		this.transform.position = new Vector3(camX, camY, this.transform.position.z);


		                                   
	
	}
}
