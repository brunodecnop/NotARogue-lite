using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAssigner : MonoBehaviour {
	[SerializeField]
	Texture2D[] sheetsNormal;
	[SerializeField]
	Texture2D[] sheetsSpawn;
	[SerializeField]
	Texture2D[] sheetsBoss;
	[SerializeField]
	GameObject RoomObj;
	public Vector2 roomDimensions = new Vector2(16*29,16*15);
	public Vector2 gutterSize = new Vector2(16*9,16*4);
	public void Assign(Room[,] rooms){
		foreach (Room room in rooms){
			//skip point where there is no room
			if (room == null){
				continue;
			}
			//pick a random index for the array
			int index = Mathf.RoundToInt(Random.value * (sheetsNormal.Length -1));
			int index2 = Mathf.RoundToInt(Random.value * (sheetsSpawn.Length - 1));
			int index3 = Mathf.RoundToInt(Random.value * (sheetsBoss.Length - 1));
			//find position to place room
			Vector3 pos = new Vector3(room.gridPos.x * (roomDimensions.x + gutterSize.x), room.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
			RoomInstance myRoom = Instantiate(RoomObj, pos, Quaternion.identity).GetComponent<RoomInstance>();
			if(room.type == 0)
				myRoom.Setup(sheetsNormal[index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
			else if (room.type == 1)
				myRoom.Setup(sheetsSpawn[index2], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
			else if (room.type == 2)
				myRoom.Setup(sheetsBoss[index3], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
			myRoom.name = $"Room {room.gridPos.x},{room.gridPos.y}";
		}

	}

	

}
