using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Enemies
{
    public class AgentMoveToPlayer: Follow
    {

        private const float minimalDistance = 1f;

        public NavMeshAgent Agent;

        private Transform positionHero;

        private IGameFactory gameFactory;


        private void Start() {
            gameFactory = ServiceLocator.Container.Single<IGameFactory>();

            if (gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else gameFactory.HeroCreated += HeroCreated;

        }


        private void Update() {

            if (Initialized() && HeroNotReached())
                Agent.destination = positionHero.position;
        }

        private void HeroCreated() {
            InitializeHeroTransform();
        }

        private void InitializeHeroTransform() {
            positionHero = gameFactory.HeroGameObject.transform;
        }

        private bool Initialized() => positionHero;

        private bool HeroNotReached() =>
            Vector3.Distance(Agent.transform.position, positionHero.position) > minimalDistance;
    }
}
