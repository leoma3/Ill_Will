using UnityEngine;
using System.Collections;

public class spriteMovement2 : MonoBehaviour {

	public float horizMove, vertMove;

	private Vector2 groundContactPoint;

	private bool touchingGround = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			VelChar(-horizMove, 0);
		}
		
		if (Input.GetKey (KeyCode.RightArrow))
		{
			VelChar(horizMove, 0);
		}
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
			VelChar(0, horizMove);
		}
		
		if (Input.GetKey (KeyCode.DownArrow))
		{
			VelChar(0, -horizMove);
		}
		
//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			ForceChar (0, vertMove);
//			VelChar(0, vertMove);
//			//touchingGround = false;
//		}

		if (Input.GetKey (KeyCode.C) && touchingGround)
		{
			this.GetComponent<Rigidbody2D>().gravityScale = 0;

			Vector2 gravityDir = groundContactPoint - new Vector2(this.transform.position.x, this.transform.position.y);

			gravityDir = gravityDir.normalized;

			print (gravityDir);

			//Physics2D.gravity = gravityDir * 20f;

			GetComponent<Rigidbody2D>().AddForce ( gravityDir * 100f );

		}

		if (Input.GetKeyUp (KeyCode.C) || !touchingGround)
		{
			//GetComponent<Rigidbody2D>().AddForce ( Physics2D.gravity );
			this.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
	}

	void VelChar(float x, float y)
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
	}
	
	void ForceChar(float x, float y)
	{
		GetComponent<Rigidbody2D>().AddForce ( new Vector2(x, y) );
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			touchingGround = true;

			foreach(ContactPoint2D contactPoint in col.contacts)
			{
				print (	contactPoint.point);

				groundContactPoint = contactPoint.point;
			}
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			touchingGround = false;
		}
	}


}
