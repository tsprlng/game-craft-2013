var levelName : String;
var quitOnClick : boolean;
var mouseOverClip : AudioClip;

function OnMouseEnter() {
	renderer.material.color = Color.yellow;
	audio.PlayOneShot(mouseOverClip);
}

function OnMouseExit() {
	renderer.material.color = Color.white;
}

function OnMouseUp() {
	if(quitOnClick) {
		Application.Quit();
	} else {
		Application.LoadLevel(levelName);
	}
}