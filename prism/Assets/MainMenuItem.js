#pragma strict
var levelName : String;
var quitOnClick : boolean;

function OnMouseEnter() {
	renderer.material.color = Color.yellow;
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