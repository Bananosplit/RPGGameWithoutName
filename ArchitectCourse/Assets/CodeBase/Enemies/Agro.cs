using Assets.CodeBase.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agro : MonoBehaviour
{
    public TriggerObserver TriggerObserver;
    public Follow AgentMove;

    private float CoolDown = 5;
    private Coroutine agroCorutine;
    private bool hasAgroCorutine;

    void Start() {
        SwitchFollowOff();
        TriggerObserver.TriggerEnter += TriggerEnter;
        TriggerObserver.TriggerExit += TriggerExit;
    }

    private void TriggerEnter(Collider obj) {
        if (!hasAgroCorutine) {
            hasAgroCorutine = true;
            StopAgroCorutine();
            SwitchFollowOn();
        }

    }

    private void TriggerExit(Collider obj) {
        if (hasAgroCorutine) {
            hasAgroCorutine = false;
            agroCorutine = StartCoroutine(SwitchFollowAfterCoolDown());
        }
    }

    private void StopAgroCorutine() {
        if (agroCorutine != null) {
            StopCoroutine(SwitchFollowAfterCoolDown());
            agroCorutine = null;
        }
    }


    private IEnumerator SwitchFollowAfterCoolDown() {
        
        yield return new WaitForSeconds(CoolDown);
        SwitchFollowOff();
    }

    private void SwitchFollowOn() =>
        AgentMove.enabled = true;

    private void SwitchFollowOff() =>
        AgentMove.enabled = false;
}
