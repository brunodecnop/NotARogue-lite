using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printDebug : MonoBehaviour
{
    public int count = 0;


    public void print() {
        count++;
        Debug.Log(count);
    }


}
