using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {
	
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.transform);
	}
}
