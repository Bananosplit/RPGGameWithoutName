using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Enemies
{
    public class AgentMoveToPlayer: Follow
    {
    
        public NavMeshAgent Agent;
        private const float minimalDistance = 1f;
        private Transform positionHero;

        private void Update() 
        {
            if (positionHero && IsHeroNotReached())
                Agent.destination = positionHero.position;
        }

        public void Construct(Transform follow) => positionHero = follow;

        public bool IsHeroNotReached() =>
            Agent.transform.position.sqrMagnitude >= minimalDistance;
    }
}
