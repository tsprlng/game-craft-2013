var from : Transform;
var to : Transform;
var speed = 0.1;

function Update () {
	transform.rotation =
	  Quaternion.Slerp (from.rotation, to.rotation, Time.time * speed);
}