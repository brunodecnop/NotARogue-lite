using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine {
    [AddComponentMenu("TopDown Engine/Character/AI/Decisions/AIDecisionTimeInThisBrain")]
    public class AIDecisionTimeInThisBrain : AIDecision {

    [Tooltip("Returns True Every X Seconds")]

    public float _notRandonTime;

    /// <summary>
    /// On Decide we evaluate our time
    /// </summary>
    /// <returns></returns>
    public override bool Decide() {
        return EvaluateTime();
    }

    /// <summary>
    /// Returns true if enough time has passed since we entered the current state
    /// </summary>
    /// <returns></returns>
    protected virtual bool EvaluateTime() {
        if (_brain == null) { return false; }
        if (_brain.TimeInThisBrain >= _notRandonTime) {
                _brain.TimeInThisBrain = 0f;
                return true;           
            }
        else return false;
    }

    /// <summary>
    /// On init we randomize our next delay
    /// </summary>
    public override void Initialization() {
        base.Initialization();
    }

    /// <summary>
    /// On enter state we randomize our next delay
    /// </summary>
    public override void OnEnterState() {
        base.OnEnterState();
    }


}
}
