using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
		
	
	public float bulletSpeed;
	
	// Use this for initialization
	void Start () 
	{
		bulletSpeed = 15f;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
	}
}
