using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	private bool touchingGround = true;
	private float origGravityScale;
	public float horizMove, vertMove;

	private GameObject centralRef;

	private bool cloneRelease;

	// Use this for initialization
	void Start () {
		//origGravityScale = GetComponent<Rigidbody2D>().gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//anything physics related
	void FixedUpdate() {

		if (centralRef == null)
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player"))
			{
				if (go.name.Contains("Central"))
				{
					centralRef = go;

					print (centralRef.gameObject.name);
				}
			}
		}

		//print("fixed");

		if (Input.GetKey (KeyCode.LeftArrow))
		{
			ForceChar(-horizMove, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow))
		{
			ForceChar(horizMove, 0);
		}

		if (Input.GetKey (KeyCode.UpArrow))
		{
			ForceChar(0, horizMove);
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			ForceChar(0, -horizMove);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			ForceChar (0, vertMove);
			//VelChar(0, vertMove);
			//touchingGround = false;
		}

		if (Input.GetKey (KeyCode.C))
		{
			Vector2 upVector = new Vector2(0, 1);

			RaycastHit2D upTouch = Physics2D.Raycast(centralRef.transform.position, Vector2.up);


			float dist = Mathf.Abs(upTouch.point.y - centralRef.transform.position.y);

			if (dist < 0.7f)
			{
				centralRef.GetComponent<Rigidbody2D>().gravityScale = -2;
			}
			else
			{
				centralRef.GetComponent<Rigidbody2D>().gravityScale = 2;
			}
		}

		if (Input.GetKeyUp (KeyCode.C))
		{
			centralRef.GetComponent<Rigidbody2D>().gravityScale = 2;
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			if (cloneRelease && GameObject.FindGameObjectsWithTag("Player").Length < 50)
			{
				GameObject clone = Instantiate(this.transform.gameObject) as GameObject;
				cloneRelease = false;
			}
		}
		if (Input.GetKeyUp (KeyCode.X))
		{
			cloneRelease = true;
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			int index = 0;

			foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
			{
				if (index > 0)
				{
					Destroy (player);
				}

				index++;
			}
		}
		
	}

	void VelChar(float x, float y)
	{
		centralRef.GetComponent<Rigidbody2D>().velocity = new Vector2(x, centralRef.GetComponent<Rigidbody2D>().velocity.y);
	}

	void ForceChar(float x, float y)
	{
		centralRef.GetComponent<Rigidbody2D>().AddForce ( new Vector2(x, y) );
	}
}
