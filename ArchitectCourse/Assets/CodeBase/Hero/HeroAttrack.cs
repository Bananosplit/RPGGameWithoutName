using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.CodeBase.Data;
using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.Input;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using CodeBase.Hero;
using CodeBase.Logic;
using UnityEngine;

public class HeroAttrack : MonoBehaviour, ISavedProgressReader
{
    public HeroAnimator Animator;
    public CharacterController Controller;
    private IInputService input;

    private static int layerMask;
    private Collider[] hits = new Collider[3];
    private Stats stats;

    private void Awake()
    {
        input = ServiceLocator.Container.Single<IInputService>();
        layerMask = 1 << LayerMask.NameToLayer("Hittable");
    }

    private void Update()
    {
        if(input.IsAttackButtonUp() && !Animator.IsAttacking)
        {
            Animator.PlayAttack();
        }
    }

    private void OnAttack()
    {
        for (int i = 0; i < Hit(); i++)
        {
            hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(stats.Damage);
        }
    }

    private int Hit() => Physics.OverlapSphereNonAlloc(
            StartPoint() + Vector3.forward,
            stats.RadiusDamage,
            hits,
            layerMask
            );

    private Vector3 StartPoint()
    {
        OverlapDebug.DrawDebug(transform.position, 5, 5);
        return new Vector3(
            transform.position.x,
            Controller.center.y / 2,
            transform.position.z
        );
    }

    public void LoadProgress(PlayerProgress progress)
    {
        stats = progress.HeroStats;
    }

    public void SaveProgress(PlayerProgress progress)
    {
        Debug.Log("from HerroAttack...");
    }
}
