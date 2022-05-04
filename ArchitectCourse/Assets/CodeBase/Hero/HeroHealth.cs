using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.CodeBase.Data;
using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using CodeBase.Hero;
using CodeBase.Logic;
using UnityEngine;

[RequireComponent(typeof(HeroAnimator))]
public class HeroHealth : MonoBehaviour, ISavedProgressReader, IHealth
{
    private State state;

    public HeroAnimator animator;
    public event Action HealthChanged; 

    public float Max {
     
    get => state.MaxHP; 
    set => state.MaxHP = value; 
    }

    public float Current {

     get => state.CurrentHP;
     set {
        if(value != state.CurrentHP)
            {
                state.CurrentHP = value;
                HealthChanged?.Invoke();
            }
     }
     }


    public void LoadProgress(PlayerProgress progress)
    {
        state = progress.HeroState;
        HealthChanged?.Invoke();
    }

    public void SaveProgress(PlayerProgress progress)
    {
        progress.HeroState.CurrentHP = Current;
        progress.HeroState.MaxHP = Max;

    }

    public void TakeDamage(float damage)
    {
        if (Current <= 0) return;
        Current -= damage;
        animator.PlayHit();
    }
}
