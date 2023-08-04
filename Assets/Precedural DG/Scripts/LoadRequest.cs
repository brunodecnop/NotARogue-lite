using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;

public class LoadRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MMEventManager.TriggerEvent(new MMGameEvent("Load"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
