using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;

public class SpawnUnderling : MonoBehaviour {
    public void SpawnUnderlings() {
    RoomManager.bossRoom.GetComponent<Loot>().SpawnLoot();

}
}
