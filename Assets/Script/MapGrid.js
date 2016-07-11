 #pragma strict

var prefab : GameObject;
var gridX = 5;
var gridY = 5;
var gridZ = 5;
var spacing =1;

function Start () {
	for(var y=0; y < gridY; y++){
		for(var x=0; x < gridX; x++){
				for(var z=0; z < gridZ; z++){
					var pos = Vector3(x,y,z) * spacing;
					Instantiate(prefab, pos, Quaternion.identity);	
			}		
		}
	}

}



