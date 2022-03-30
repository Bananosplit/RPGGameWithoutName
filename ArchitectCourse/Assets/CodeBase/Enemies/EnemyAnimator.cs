using CodeBase.Logic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Enemies
{
    class EnemyAnimator : MonoBehaviour, IAnimationStateReader
    {

        private static readonly int Attack = Animator.StringToHash("Attack_1");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Die = Animator.StringToHash("Die");

        private readonly int idleStateHash = Animator.StringToHash("idle");
        private readonly int attackStateHash = Animator.StringToHash("attack01");
        private readonly int MoveStateHash = Animator.StringToHash("Move");
        private readonly int dieStateHash = Animator.StringToHash("die");


        private Animator animator;

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        private void Awake() => animator = GetComponent<Animator>();

        public void PlayerHit() => animator.SetTrigger(Hit);
        public void PlayerDeath() => animator.SetTrigger(Die);
        public void Move(float speed)
        {
            animator.SetBool(IsMoving, true);
            animator.SetFloat(Speed, speed);
        }
        public void StopMoving() => animator.SetBool(IsMoving, false);


        public void EnteredState(int stateHash) {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) {
            StateExited?.Invoke(StateFor(stateHash));
        }

        private AnimatorState StateFor(int stateHash) {

            AnimatorState state;
            if (stateHash == idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == MoveStateHash)
                state = AnimatorState.Walking;
            else if (stateHash == dieStateHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}
