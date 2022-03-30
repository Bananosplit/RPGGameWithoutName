using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentRotateToPlayer : Follow
{
    public float Speed;

    private Transform heroTransform;
    private IGameFactory gameFactory;
    private Vector3 positionToLook;

    private void Start() {
        gameFactory = ServiceLocator.Container.Single<IGameFactory>();

        if (IsHeroExist())
            InitializeHeroTransform();
        else
            gameFactory.HeroCreated += HeroCreated;
    }

    private void Update() {
        if (IsInitialized())
            RotateTowardsHero();
    }

    private void OnDestroy() {
        if (gameFactory != null)
            gameFactory.HeroCreated -= HeroCreated;
    }

    private bool IsHeroExist() =>
      gameFactory.HeroGameObject != null;

    private void RotateTowardsHero() {
        UpdatePositionToLookAt();

        transform.rotation = SmoothedRotation(transform.rotation, positionToLook);
    }

    private void UpdatePositionToLookAt() {
        Vector3 positionDelta = heroTransform.position - transform.position;
        positionToLook = new Vector3(positionDelta.x, transform.position.y, positionDelta.z);
    }

    private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) =>
      Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());

    private Quaternion TargetRotation(Vector3 position) =>
      Quaternion.LookRotation(position);

    private float SpeedFactor() =>
      Speed * Time.deltaTime;

    private bool IsInitialized() =>
      heroTransform != null;

    private void HeroCreated() =>
      InitializeHeroTransform();

    private void InitializeHeroTransform() =>
      heroTransform = gameFactory.HeroGameObject.transform;
}


