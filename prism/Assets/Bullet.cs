using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
		
	
	public float bulletSpeed;
	public string bulletOwner;
	private Transform target;
	public bool hasHitTarget;
	
	// Use this for initialization
	void Start () 
	{
		bulletSpeed = 15f;
		GameObject go;
		
		if (bulletOwner == "Player") {
			
			go = GameObject.FindGameObjectWithTag("AI");
		}
		else
		{
			go = GameObject.FindGameObjectWithTag("Player");
		}

 
    	target = go.transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		float distance = Vector3.Distance(transform.position, target.position);
		
			
		if (!renderer.isVisible) 
		{
			Destroy(gameObject);
		}
		
		if (distance <= 1) {
			Destroy(gameObject);
			hasHitTarget = true;
			Debug.Log("Hit Target");
		}
		
		transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
		

	}
	
	

	
}
