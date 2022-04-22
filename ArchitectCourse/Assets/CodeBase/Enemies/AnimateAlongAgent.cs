using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using CodeBase.Enemy;

namespace Assets.CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimalDistance = 0.1f;

        public NavMeshAgent Agent;
        public EnemyAnimator Animator;

        private void Update() {
            if (ShouldMove())
                Animator.Move(Agent.velocity.magnitude);
            else
                Animator.StopMoving();
        }

        private bool ShouldMove() => 
            Agent.velocity.magnitude > MinimalDistance && Agent.remainingDistance > Agent.radius;
    }
}
