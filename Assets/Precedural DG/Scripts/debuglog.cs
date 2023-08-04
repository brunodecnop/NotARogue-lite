using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuglog : MonoBehaviour
{
   public void debuglogfunc() {
        RoomInstance roominstance = this.GetComponent<RoomInstance>();
        Debug.Log("Sala limpa!");
        Debug.Log(roominstance.gridPos);
        Debug.Log(this.name);
    }
}
