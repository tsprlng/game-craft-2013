var levelName : String;
var quitOnClick : boolean;
var mouseOverClip : AudioClip;
var normalColor : Color;
var highlightColor : Color;

function Start() {
	renderer.material.color = normalColor;
}

function OnMouseEnter() {
	renderer.material.color = highlightColor;
	audio.PlayOneShot(mouseOverClip);
}

function OnMouseExit() {
	renderer.material.color = normalColor;
}

function OnMouseUp() {
	if(quitOnClick) {
		Application.Quit();
	} else {
		Application.LoadLevel(levelName);
	}
}