using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Transform myTransform;
	public float rotationSpeed = 20f;
	public float movementSpeed = 10f;
	
	public GameObject projectile;
	public GameObject camera;
	public float fireRate;
	public float nextFire;
	
	public AudioClip gunSound;
	
	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
		fireRate = 1f;
		nextFire = -1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		
		if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) 
		{
			//Debug.DrawLine(string.Format("{0} + {1}", myTransform.position.x, yPos.position.x));
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Vector3.left), rotationSpeed * Time.deltaTime);
			//transform.Rotate(Vector3.left);
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
			camera.transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
			//myTransform.position.x = 1f;
			
		}
		
		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
		{
			//Debug.DrawLine(string.Format("{0} + {1}", myTransform.position.x, yPos.position.x));
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Vector3.right), rotationSpeed * Time.deltaTime);
			//transform.Rotate(Vector3.left);
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
			camera.transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);

			//myTransform.position.x = 1f;
		}
		
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			FireGun();
		}
		
		//camera.transform.position.Set(myTransform.position.x + 2, myTransform.position.y, myTransform.position.z+10);
		
	}
	
	
	public void FireGun()
	{
			if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Vector3 pos = myTransform.position;
				pos.y += 1.6f;
				var clone = Instantiate(projectile, pos, myTransform.rotation);
				audio.PlayOneShot(gunSound);
			}
	}
}
