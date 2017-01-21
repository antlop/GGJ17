var scrollSpeed = 0.01;
var scrollSpeed2 = 0.01;

function FixedUpdate() {
var offset = Time.time * scrollSpeed;
var offset2 = Time.time * scrollSpeed2;
GetComponent.<Renderer>().material.mainTextureOffset = Vector2 (-offset2,0);
}