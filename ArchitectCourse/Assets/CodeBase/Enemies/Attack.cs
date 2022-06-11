using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;
using CodeBase.Logic;
using Assets.CodeBase.Infrastructure.AllServices;
using System;

namespace CodeBase.Enemy {

[RequireComponent(typeof(EnemyAnimator))]
public class Attack : MonoBehaviour
{
    public EnemyAnimator Animator;
    public float AttackCooldown = 3f;
    public float Cleavage = 0.5f;
    public float EffectiveDistance = 0.5f;

    private Transform heroTransofrm;

    private float attackCooldown;
    private bool isAttacked;
    private bool attackIsActive = true;

    private int layerMask;
    private Collider[] hits = new Collider[1];
    private Vector3 startPoint;
    private Collider hit;
    public float Damage = 10;

    void Awake()
    {

        layerMask = 1 << LayerMask.NameToLayer("Player");
    }

        // Update is called once per frame
    void Update()
    {
        if(attackCooldown > 0)
            attackCooldown -= Time.deltaTime;

            //если не кд и можно атаковать
        if(attackCooldown <= 0 && !isAttacked && attackIsActive)
            StartAttack();
    }

    public void Construct(Transform positionHero) => heroTransofrm = positionHero;

    public void EnableAttack() => attackIsActive = true;

    public void DisableAttack() => attackIsActive = false;

    private void OnAttack()
    {

        if(Hit(out hit))
            hit.transform.GetComponent<IHealth>().TakeDamage(Damage);
    }

    private bool Hit(out Collider hiit)
    {
            //Метод возвращает имеются ли пересечения
        startPoint = new Vector3(
            transform.position.x,
            transform.position.y + 1,
            transform.position.z
        ) + (transform.forward * EffectiveDistance);

        int hitsCount = Physics.OverlapSphereNonAlloc(startPoint, Cleavage, hits, layerMask);

        hiit = hits[0];

        return hitsCount > 0;
    }

    private void OnAttackEnded(){
        attackCooldown = AttackCooldown;
        isAttacked = false;
    }

    private void StartAttack(){
        transform.LookAt(heroTransofrm);
        Animator.PlayAttack();
        isAttacked = true;
    }

    }
}
