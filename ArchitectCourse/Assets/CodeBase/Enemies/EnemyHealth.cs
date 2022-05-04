using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeBase.Logic;
using CodeBase.Enemy;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyHealth : MonoBehaviour, IHealth
{
    public EnemyAnimator Animator;

    public float Current {
        get{return current;}
        set{current = value;} 
    }
    public float Max {
        get{return max;}
        set{max = value;} 
    }

    [SerializeField]
    private float current;

    [SerializeField]
    private float max;


    public event Action HealthChanged;

    public void TakeDamage(float damage){

        Current -= damage;
        Animator.PlayHit();
        HealthChanged?.Invoke();
    }
}
