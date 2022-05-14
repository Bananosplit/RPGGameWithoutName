using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Enemy {
[RequireComponent(typeof(Attack))]
public class CheckAttackRange : MonoBehaviour
{
    public Attack Attack;
    public TriggerObserver TriggerObserver;

    void Start()
    {
        TriggerObserver.TriggerEnter += TriggerEnter;
        TriggerObserver.TriggerExit += TriggerExit;

        Attack.DisableAttack();
    }

    private void TriggerEnter(Collider obj){
        Attack.EnableAttack();
    }

     private void TriggerExit(Collider obj){
         Attack.DisableAttack();
    }
}
}