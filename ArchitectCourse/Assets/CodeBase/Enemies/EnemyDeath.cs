using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Enemy;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
public class EnemyDeath : MonoBehaviour
{
    public EnemyAnimator Animator;
    public EnemyHealth Health;

    public GameObject DeathFX;

    public event Action Happened;

    //public Follow EnemyFollow;

    void Start() => Health.HealthChanged += HealthChanged;

    void OnDestroy() => Health.HealthChanged -= HealthChanged;

    private void HealthChanged()
    {
        if(Health.Current <= 0)
            Die();
        
    }

    private void  Die()
    {
        Health.HealthChanged -= HealthChanged;
        Animator.PlayDeath();
        CreateDeathFX();

        transform.GetComponent<Follow>().enabled = false;

        StartCoroutine(DeathTimer());
        Happened?.Invoke();
    }

    private void CreateDeathFX()
    {
        Instantiate(DeathFX, transform.position, Quaternion.identity);
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
