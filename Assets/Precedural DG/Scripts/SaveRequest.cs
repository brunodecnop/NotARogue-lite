using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;

public class SaveRequest : MonoBehaviour
{
    // Start is called before the first frame update
    public void SaveRequestFunction()
    {
        MMEventManager.TriggerEvent(new MMGameEvent("Save"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
