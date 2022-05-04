using System.Collections;
using System.Collections.Generic;
using CodeBase.Hero;
using UnityEngine;

[RequireComponent(typeof(HeroHealth))]
public class HeroDeath : MonoBehaviour
{
 public HeroAnimator Animator;
 public HeroHealth Health;
 public HeroMove HeroMove;
 public HeroAttrack HeroAttack;
 public GameObject DeathFX;
 public bool isDie;
 
 private void Start() => Health.HealthChanged += HealthChanged;
 private void OnDestroy() => Health.HealthChanged += HealthChanged;
 
 private void HealthChanged() {
     if(Health.Current <= 0 && !isDie)
        die();
 }

 private void die()
 {
        isDie = true;
        HeroMove.enabled = false;
        HeroAttack.enabled = false;
        Animator.PlayDeath();

        Instantiate(DeathFX, transform.position, Quaternion.identity);
 }
}
