using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

// ps: For this to Work, Child with DMG on touch component must be the first. 

[AddComponentMenu("TopDown Engine/Character/AI/Actions/AIActionExplode")]
public class AIActionExplode : AIAction 
    {
    public override void Initialization() {
        base.Initialization();
        
    }

    public override void PerformAction() {
        SelfExplode();
    }

    void SelfExplode() {

        transform.GetChild(0).gameObject.SetActive(true);

    }

    public override void OnEnterState() {
        base.OnEnterState();
     
    }
}
