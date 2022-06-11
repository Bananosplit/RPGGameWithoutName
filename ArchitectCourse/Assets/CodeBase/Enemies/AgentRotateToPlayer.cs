using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentRotateToPlayer : Follow
{
    public float Speed;

    private Transform heroTransform;
    private Vector3 positionToLook;


    private void Update() {
        if (IsInitialized())
            RotateTowardsHero();
    }

    public void Construct(Transform heroTransform) => this.heroTransform = heroTransform;

    private void RotateTowardsHero() {

        UpdatePositionToLookAt();

        transform.rotation = SmoothedRotation();
    }

    private void UpdatePositionToLookAt() {
        Vector3 positionDelta = heroTransform.position - transform.position;
        positionToLook = new Vector3(positionDelta.x, transform.position.y, positionDelta.z);
    }

    private Quaternion SmoothedRotation() =>
      Quaternion.Lerp(transform.rotation, TargetRotation(positionToLook), SpeedFactor());

    private Quaternion TargetRotation(Vector3 position) =>
      Quaternion.LookRotation(position);

    private float SpeedFactor() =>
      Speed * Time.deltaTime;

    private bool IsInitialized() =>
      heroTransform != null;
}


